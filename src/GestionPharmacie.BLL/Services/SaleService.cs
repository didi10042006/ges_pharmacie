using GestionPharmacie.BLL.Security;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;
using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.BLL.Services;

public class SaleService : ISaleService
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly ISaleRepository _saleRepository;
    private readonly IStockLotRepository _stockLotRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAuditLogService _auditLogService;

    public SaleService(
        IDbConnectionFactory connectionFactory,
        ISaleRepository saleRepository,
        IStockLotRepository stockLotRepository,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IAuditLogService auditLogService)
    {
        _connectionFactory = connectionFactory;
        _saleRepository = saleRepository;
        _stockLotRepository = stockLotRepository;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _auditLogService = auditLogService;
    }

    /// <summary>
    /// Règle FIFO : Récupère le lot prioritaire à vendre (date de péremption la plus proche, non bloqué, non périmé).
    /// </summary>
    public async Task<StockLot?> GetNextFifoLotForProductAsync(int productId)
    {
        var lots = await _stockLotRepository.GetAvailableLotsForSaleAsync(productId);
        return lots.FirstOrDefault();
    }

    public async Task<int> GetTotalSellableStockAsync(int productId)
    {
        var lots = await _stockLotRepository.GetAvailableLotsForSaleAsync(productId);
        return lots.Sum(l => l.Quantity);
    }

    /// <summary>
    /// Validation d'une remise par mot de passe d'un responsable (Admin ou Pharmacien).
    /// </summary>
    public async Task<bool> ValidateDiscountApprovalAsync(string supervisorUsername, string supervisorPassword)
    {
        if (string.IsNullOrWhiteSpace(supervisorUsername) || string.IsNullOrWhiteSpace(supervisorPassword))
            return false;

        var user = await _userRepository.GetByUsernameAsync(supervisorUsername.Trim());
        if (user == null || !user.IsActive)
            return false;

        // Seul un Admin ou un Pharmacien peut autoriser une remise
        var isSupervisor = string.Equals(user.Role, UserRole.Admin.ToString(), StringComparison.OrdinalIgnoreCase) ||
                           string.Equals(user.Role, UserRole.Pharmacist.ToString(), StringComparison.OrdinalIgnoreCase) ||
                           string.Equals(user.Role, "Pharmacien", StringComparison.OrdinalIgnoreCase);

        if (!isSupervisor) return false;

        var isValid = _passwordHasher.VerifyPassword(supervisorPassword, user.PasswordHash);
        if (isValid)
        {
            await _auditLogService.LogActionAsync(
                user.Id,
                "DISCOUNT_APPROVED",
                $"Remise autorisée par le responsable '{user.Username}' pour la session de '{UserSession.Instance.Username}'."
            );
        }

        return isValid;
    }

    /// <summary>
    /// Validation complète et atomique d'une vente en appliquant strictement la règle FIFO.
    /// </summary>
    public async Task<SaleDetailDto> ProcessSaleAsync(
        List<CartItemDto> cartItems, 
        PaymentMethod paymentMethod, 
        decimal discountAmount, 
        decimal paidAmount)
    {
        if (cartItems == null || cartItems.Count == 0)
            throw new ArgumentException("Le panier d'achat est vide.");

        var totalAmount = cartItems.Sum(c => c.SubTotal);

        if (discountAmount < 0 || discountAmount > totalAmount)
            throw new ArgumentException("Le montant de la remise est invalide.");

        var netAmount = totalAmount - discountAmount;
        decimal changeGiven = 0m;

        if (paymentMethod == PaymentMethod.Cash)
        {
            if (paidAmount < netAmount)
            {
                throw new InvalidOperationException($"Montant insuffisant. Reçu : {paidAmount:C2}, Net à payer : {netAmount:C2}.");
            }
            changeGiven = paidAmount - netAmount;
        }
        else
        {
            paidAmount = netAmount;
            changeGiven = 0m;
        }

        var currentUserId = UserSession.Instance.UserId ?? 1;

        using var connection = _connectionFactory.CreateConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            var saleItemsToInsert = new List<SaleItem>();

            // 1. Décrémentation FIFO pour chaque article du panier
            foreach (var item in cartItems)
            {
                var availableLots = (await _stockLotRepository.GetAvailableLotsForSaleAsync(item.ProductId, connection, transaction)).ToList();
                var totalAvailable = availableLots.Sum(l => l.Quantity);

                if (totalAvailable < item.Quantity)
                {
                    throw new InvalidOperationException(
                        $"Stock vendable insuffisant pour '{item.ProductName}'. Demandé : {item.Quantity}, Disponible non périmé : {totalAvailable}."
                    );
                }

                var remainingToFulfill = item.Quantity;
                foreach (var lot in availableLots)
                {
                    if (remainingToFulfill <= 0) break;

                    var qtyFromLot = Math.Min(remainingToFulfill, lot.Quantity);
                    var decremented = await _stockLotRepository.DecrementLotQuantityAsync(lot.Id, qtyFromLot, connection, transaction);

                    if (!decremented)
                    {
                        throw new InvalidOperationException($"Impossible de décrémenter le lot '{lot.LotNumber}' pour '{item.ProductName}'.");
                    }

                    saleItemsToInsert.Add(new SaleItem
                    {
                        StockLotId = lot.Id,
                        Quantity = qtyFromLot,
                        UnitPrice = item.UnitPrice,
                        LineTotal = qtyFromLot * item.UnitPrice
                    });

                    remainingToFulfill -= qtyFromLot;
                }
            }

            // 2. Génération du numéro de vente
            var saleNumber = await _saleRepository.GenerateNextSaleNumberAsync(connection, transaction);

            // 3. Enregistrement de la vente
            var sale = new Sale
            {
                SaleNumber = saleNumber,
                SaleDate = DateTime.Now,
                UserId = currentUserId,
                PaymentMethod = paymentMethod.ToString(),
                TotalAmount = totalAmount,
                DiscountAmount = discountAmount,
                PaidAmount = paidAmount,
                ChangeGiven = changeGiven,
                Status = "Completed"
            };

            var saleId = await _saleRepository.CreateSaleAsync(sale, saleItemsToInsert, connection, transaction);

            // 4. Validation de la transaction
            transaction.Commit();

            // 5. Journal d'Audit
            await _auditLogService.LogActionAsync(
                currentUserId,
                "SALE_COMPLETED",
                $"Vente #{saleNumber} complétée. Total: {totalAmount:C2}, Remise: {discountAmount:C2}, Net: {netAmount:C2}, Mode: {paymentMethod}."
            );

            // 6. Retourner le détail de la vente pour édition / ticket
            var createdSale = await _saleRepository.GetSaleByIdAsync(saleId);
            return createdSale ?? throw new InvalidOperationException("Vente introuvable après enregistrement.");
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<SaleDetailDto?> GetSaleByNumberAsync(string saleNumber)
    {
        return await _saleRepository.GetSaleByNumberAsync(saleNumber);
    }

    public async Task<ShiftSummaryDto> GetShiftSummaryAsync(DateTime date)
    {
        return await _saleRepository.GetShiftSummaryAsync(date);
    }

    public async Task<bool> RecordShiftCloseAsync(DateTime date, decimal countedCash, string? notes = null)
    {
        var summary = await _saleRepository.GetShiftSummaryAsync(date);
        var expectedCash = summary.CashSalesAmount;
        var discrepancy = countedCash - expectedCash;

        var currentUserId = UserSession.Instance.UserId ?? 1;
        var details = $"Clôture caisse du {date:dd/MM/yyyy}. Espèces attendues : {expectedCash:C2}, Espèces comptées : {countedCash:C2}, Écart : {discrepancy:C2}. {(string.IsNullOrWhiteSpace(notes) ? "" : "Notes : " + notes)}";

        await _auditLogService.LogActionAsync(currentUserId, "SHIFT_CLOSED", details);
        return true;
    }
}
