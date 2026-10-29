using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.DAL.Repositories;

public interface IInventoryRepository
{
    Task<IEnumerable<InventoryLotItemDto>> GetInventoryLotsAsync(string? searchTerm = null, bool includeZeroStock = false);
    Task<bool> AdjustLotStockAsync(int lotId, int newQuantity, string reason, int userId);
    Task<bool> ToggleBlockLotAsync(int lotId, bool isBlocked, int userId);
}
