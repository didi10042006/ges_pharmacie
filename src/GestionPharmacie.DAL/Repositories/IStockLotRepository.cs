using System.Data;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public interface IStockLotRepository
{
    Task<StockLot?> GetByIdAsync(int id);
    Task<IEnumerable<StockLot>> GetLotsByProductAsync(int productId, bool onlyAvailable = true);
    Task<int> CreateAsync(StockLot lot, IDbConnection? connection = null, IDbTransaction? transaction = null);
    Task CreateBatchAsync(IEnumerable<StockLot> lots, IDbConnection connection, IDbTransaction transaction);
    Task<bool> UpdateQuantityAsync(int lotId, int newQuantity, IDbConnection? connection = null, IDbTransaction? transaction = null);
    Task<IEnumerable<StockLot>> GetAvailableLotsForSaleAsync(int productId, IDbConnection? connection = null, IDbTransaction? transaction = null);
    Task<bool> DecrementLotQuantityAsync(int lotId, int quantityToDeduct, IDbConnection connection, IDbTransaction transaction);
}
