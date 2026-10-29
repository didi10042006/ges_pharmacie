using System.Data;
using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public class StockLotRepository : IStockLotRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public StockLotRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<StockLot?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM StockLots WHERE Id = @Id;";
        return await connection.QuerySingleOrDefaultAsync<StockLot>(sql, new { Id = id });
    }

    public async Task<IEnumerable<StockLot>> GetLotsByProductAsync(int productId, bool onlyAvailable = true)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = @"
            SELECT * FROM StockLots
            WHERE ProductId = @ProductId
              " + (onlyAvailable ? "AND Quantity > 0 AND IsBlocked = 0 AND date(ExpiryDate) >= date('now')" : "") + @"
            ORDER BY ExpiryDate ASC;
        ";
        return await connection.QueryAsync<StockLot>(sql, new { ProductId = productId });
    }

    public async Task<int> CreateAsync(StockLot lot, IDbConnection? connection = null, IDbTransaction? transaction = null)
    {
        var shouldDispose = false;
        if (connection == null)
        {
            connection = _connectionFactory.CreateConnection();
            shouldDispose = true;
        }

        try
        {
            const string sql = @"
                INSERT INTO StockLots (ProductId, SupplierId, LotNumber, ExpiryDate, Quantity, PurchaseCost, IsBlocked)
                VALUES (@ProductId, @SupplierId, @LotNumber, @ExpiryDate, @Quantity, @PurchaseCost, @IsBlocked);
                SELECT last_insert_rowid();
            ";

            return await connection.ExecuteScalarAsync<int>(sql, new
            {
                lot.ProductId,
                lot.SupplierId,
                lot.LotNumber,
                ExpiryDate = lot.ExpiryDate.ToString("yyyy-MM-dd"),
                lot.Quantity,
                lot.PurchaseCost,
                lot.IsBlocked
            }, transaction);
        }
        finally
        {
            if (shouldDispose)
            {
                connection.Dispose();
            }
        }
    }

    public async Task CreateBatchAsync(IEnumerable<StockLot> lots, IDbConnection connection, IDbTransaction transaction)
    {
        const string sql = @"
            INSERT INTO StockLots (ProductId, SupplierId, LotNumber, ExpiryDate, Quantity, PurchaseCost, IsBlocked)
            VALUES (@ProductId, @SupplierId, @LotNumber, @ExpiryDate, @Quantity, @PurchaseCost, @IsBlocked);
        ";

        foreach (var lot in lots)
        {
            await connection.ExecuteAsync(sql, new
            {
                lot.ProductId,
                lot.SupplierId,
                lot.LotNumber,
                ExpiryDate = lot.ExpiryDate.ToString("yyyy-MM-dd"),
                lot.Quantity,
                lot.PurchaseCost,
                lot.IsBlocked
            }, transaction);
        }
    }

    public async Task<bool> UpdateQuantityAsync(int lotId, int newQuantity, IDbConnection? connection = null, IDbTransaction? transaction = null)
    {
        var shouldDispose = false;
        if (connection == null)
        {
            connection = _connectionFactory.CreateConnection();
            shouldDispose = true;
        }

        try
        {
            const string sql = "UPDATE StockLots SET Quantity = @Quantity WHERE Id = @Id;";
            var rows = await connection.ExecuteAsync(sql, new { Id = lotId, Quantity = newQuantity }, transaction);
            return rows > 0;
        }
        finally
        {
            if (shouldDispose)
            {
                connection.Dispose();
            }
        }
    }

    /// <summary>
    /// Règle FIFO : Récupère les lots vendables triés par date de péremption croissante (les plus proches de périmer en premier).
    /// Filtre strictement : quantité > 0, lot non bloqué, et date de péremption >= aujourd'hui.
    /// </summary>
    public async Task<IEnumerable<StockLot>> GetAvailableLotsForSaleAsync(int productId, IDbConnection? connection = null, IDbTransaction? transaction = null)
    {
        var shouldDispose = false;
        if (connection == null)
        {
            connection = _connectionFactory.CreateConnection();
            shouldDispose = true;
        }

        try
        {
            const string sql = @"
                SELECT * FROM StockLots
                WHERE ProductId = @ProductId
                  AND Quantity > 0
                  AND IsBlocked = 0
                  AND date(ExpiryDate) >= date('now')
                ORDER BY date(ExpiryDate) ASC, Id ASC;
            ";

            return await connection.QueryAsync<StockLot>(sql, new { ProductId = productId }, transaction);
        }
        finally
        {
            if (shouldDispose)
            {
                connection.Dispose();
            }
        }
    }

    /// <summary>
    /// Décrémente la quantité d'un lot dans une transaction SQLite.
    /// Échoue si la quantité disponible est inférieure à la quantité demandée (protection concurrence/survente).
    /// </summary>
    public async Task<bool> DecrementLotQuantityAsync(int lotId, int quantityToDeduct, IDbConnection connection, IDbTransaction transaction)
    {
        const string sql = @"
            UPDATE StockLots
            SET Quantity = Quantity - @QuantityToDeduct
            WHERE Id = @LotId AND Quantity >= @QuantityToDeduct;
        ";

        var rows = await connection.ExecuteAsync(sql, new { LotId = lotId, QuantityToDeduct = quantityToDeduct }, transaction);
        return rows > 0;
    }
}
