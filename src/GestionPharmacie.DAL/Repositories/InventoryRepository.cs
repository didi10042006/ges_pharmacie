using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.DAL.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public InventoryRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<InventoryLotItemDto>> GetInventoryLotsAsync(string? searchTerm = null, bool includeZeroStock = false)
    {
        using var connection = _connectionFactory.CreateConnection();
        var searchPattern = string.IsNullOrWhiteSpace(searchTerm) ? null : $"%{searchTerm.Trim()}%";

        var sql = @"
            SELECT 
                l.Id AS LotId,
                l.ProductId,
                p.Reference AS ProductReference,
                p.Name AS ProductName,
                p.Category,
                l.LotNumber,
                l.ExpiryDate,
                l.Quantity AS TheoreticalQuantity,
                (l.PurchaseCost * 1.0) AS PurchaseCost,
                (p.SellingPrice * 1.0) AS SellingPrice,
                l.IsBlocked
            FROM StockLots l
            JOIN Products p ON l.ProductId = p.Id
            WHERE (@IncludeZeroStock = 1 OR l.Quantity > 0)
              AND (@SearchPattern IS NULL OR p.Name LIKE @SearchPattern OR p.Reference LIKE @SearchPattern OR l.LotNumber LIKE @SearchPattern)
            ORDER BY p.Name ASC, date(l.ExpiryDate) ASC;
        ";

        return await connection.QueryAsync<InventoryLotItemDto>(sql, new
        {
            IncludeZeroStock = includeZeroStock ? 1 : 0,
            SearchPattern = searchPattern
        });
    }

    public async Task<bool> AdjustLotStockAsync(int lotId, int newQuantity, string reason, int userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            const string getLotSql = "SELECT ProductId, Quantity FROM StockLots WHERE Id = @LotId;";
            var lotInfo = await connection.QuerySingleOrDefaultAsync<(int ProductId, int CurrentQuantity)>(getLotSql, new { LotId = lotId }, transaction);

            if (lotInfo.ProductId <= 0) return false;

            var quantityChange = newQuantity - lotInfo.CurrentQuantity;

            // 1. Insertion de la ligne d'ajustement
            const string insertAdjustmentSql = @"
                INSERT INTO StockAdjustments (ProductId, StockLotId, QuantityChange, Reason, UserId, AdjustmentDate)
                VALUES (@ProductId, @StockLotId, @QuantityChange, @Reason, @UserId, @AdjustmentDate);
            ";

            await connection.ExecuteAsync(insertAdjustmentSql, new
            {
                ProductId = lotInfo.ProductId,
                StockLotId = lotId,
                QuantityChange = quantityChange,
                Reason = reason,
                UserId = userId,
                AdjustmentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            }, transaction);

            // 2. Mise à jour de la quantité du lot
            const string updateLotSql = "UPDATE StockLots SET Quantity = @NewQuantity WHERE Id = @LotId;";
            await connection.ExecuteAsync(updateLotSql, new { LotId = lotId, NewQuantity = newQuantity }, transaction);

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<bool> ToggleBlockLotAsync(int lotId, bool isBlocked, int userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "UPDATE StockLots SET IsBlocked = @IsBlocked WHERE Id = @LotId;";
        var rows = await connection.ExecuteAsync(sql, new { LotId = lotId, IsBlocked = isBlocked ? 1 : 0 });
        return rows > 0;
    }
}
