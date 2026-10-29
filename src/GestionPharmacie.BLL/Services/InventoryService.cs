using GestionPharmacie.BLL.Security;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.BLL.Services;

public interface IInventoryService
{
    Task<IEnumerable<InventoryLotItemDto>> GetInventoryLotsAsync(string? searchTerm = null, bool includeZeroStock = false);
    Task<bool> AdjustLotStockAsync(int lotId, int newQuantity, string reason);
    Task<bool> ToggleBlockLotAsync(int lotId, bool isBlocked);
}

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IAuditLogService _auditLogService;

    public InventoryService(IInventoryRepository inventoryRepository, IAuditLogService auditLogService)
    {
        _inventoryRepository = inventoryRepository;
        _auditLogService = auditLogService;
    }

    public async Task<IEnumerable<InventoryLotItemDto>> GetInventoryLotsAsync(string? searchTerm = null, bool includeZeroStock = false)
    {
        return await _inventoryRepository.GetInventoryLotsAsync(searchTerm, includeZeroStock);
    }

    public async Task<bool> AdjustLotStockAsync(int lotId, int newQuantity, string reason)
    {
        if (newQuantity < 0)
            throw new ArgumentException("La quantité réelle en stock ne peut pas être négative.");

        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Le motif de l'ajustement est obligatoire pour justifier l'écart d'inventaire.");

        var userId = UserSession.Instance.UserId ?? 1;
        var success = await _inventoryRepository.AdjustLotStockAsync(lotId, newQuantity, reason.Trim(), userId);

        if (success)
        {
            await _auditLogService.LogCurrentSessionActionAsync(
                "STOCK_ADJUSTMENT",
                $"Ajustement d'inventaire pour le lot #{lotId} : Nouveau stock fixé à {newQuantity}. Motif : {reason}."
            );
        }

        return success;
    }

    public async Task<bool> ToggleBlockLotAsync(int lotId, bool isBlocked)
    {
        // Seul l'administrateur ou pharmacien peut bloquer/débloquer un lot
        if (!UserSession.Instance.CanManageStock)
            throw new UnauthorizedAccessException("Droits insuffisants pour modifier le blocage d'un lot.");

        var userId = UserSession.Instance.UserId ?? 1;
        var success = await _inventoryRepository.ToggleBlockLotAsync(lotId, isBlocked, userId);

        if (success)
        {
            var actionName = isBlocked ? "LOT_BLOCKED" : "LOT_UNBLOCKED";
            var details = isBlocked 
                ? $"Blocage sanitaire manuel du lot #{lotId} (retiré de la vente)." 
                : $"Déblocage manuel du lot #{lotId} (remis en vente).";

            await _auditLogService.LogCurrentSessionActionAsync(actionName, details);
        }

        return success;
    }
}
