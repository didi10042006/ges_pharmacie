using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public interface IStockService
{
    Task<IEnumerable<Supplier>> GetActiveSuppliersAsync();
    Task<IEnumerable<StockLot>> GetLotsByProductAsync(int productId);
    Task<bool> ReceiveStockBatchAsync(int? supplierId, string documentNumber, List<StockLot> lots);
}
