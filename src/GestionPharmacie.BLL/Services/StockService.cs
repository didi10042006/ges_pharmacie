using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public class StockService : IStockService
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly IStockLotRepository _stockLotRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IAuditLogService _auditLogService;

    public StockService(
        IDbConnectionFactory connectionFactory,
        IStockLotRepository stockLotRepository,
        ISupplierRepository supplierRepository,
        IAuditLogService auditLogService)
    {
        _connectionFactory = connectionFactory;
        _stockLotRepository = stockLotRepository;
        _supplierRepository = supplierRepository;
        _auditLogService = auditLogService;
    }

    public async Task<IEnumerable<Supplier>> GetActiveSuppliersAsync()
    {
        return await _supplierRepository.GetAllActiveAsync();
    }

    public async Task<IEnumerable<StockLot>> GetLotsByProductAsync(int productId)
    {
        return await _stockLotRepository.GetLotsByProductAsync(productId);
    }

    /// <summary>
    /// Enregistre une réception de stock atomiquement au sein d'une transaction SQLite.
    /// </summary>
    public async Task<bool> ReceiveStockBatchAsync(int? supplierId, string documentNumber, List<StockLot> lots)
    {
        if (lots == null || lots.Count == 0)
            throw new ArgumentException("La réception doit contenir au moins une ligne de lot.");

        if (string.IsNullOrWhiteSpace(documentNumber))
            throw new ArgumentException("Le numéro de bon de livraison / document de réception est obligatoire.");

        foreach (var lot in lots)
        {
            if (lot.ProductId <= 0)
                throw new ArgumentException("Chaque ligne doit avoir un produit valide sélectionné.");

            if (string.IsNullOrWhiteSpace(lot.LotNumber))
                throw new ArgumentException("Le numéro de lot est obligatoire pour tous les produits.");

            if (lot.Quantity <= 0)
                throw new ArgumentException($"La quantité du lot '{lot.LotNumber}' doit être supérieure à 0.");

            if (lot.PurchaseCost < 0)
                throw new ArgumentException($"Le coût d'achat du lot '{lot.LotNumber}' ne peut pas être négatif.");

            if (lot.ExpiryDate.Date <= DateTime.Today)
                throw new ArgumentException($"La date d'expiration du lot '{lot.LotNumber}' doit être ultérieure à aujourd'hui.");

            lot.SupplierId = supplierId;
            lot.IsBlocked = false;
        }

        using var connection = _connectionFactory.CreateConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            // Insertion atomique de tous les lots
            await _stockLotRepository.CreateBatchAsync(lots, connection, transaction);

            // Validation de la transaction
            transaction.Commit();

            var totalUnits = lots.Sum(l => l.Quantity);
            var totalCost = lots.Sum(l => l.Quantity * l.PurchaseCost);

            await _auditLogService.LogCurrentSessionActionAsync(
                "STOCK_ENTRY",
                $"Réception de stock [Doc: {documentNumber}] : {lots.Count} lot(s), {totalUnits} unités reçues (Montant total achat : {totalCost:C2})."
            );

            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
