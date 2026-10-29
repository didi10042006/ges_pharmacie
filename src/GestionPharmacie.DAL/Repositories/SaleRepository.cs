using System.Data;
using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public SaleRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> CreateSaleAsync(Sale sale, IEnumerable<SaleItem> items, IDbConnection connection, IDbTransaction transaction)
    {
        const string insertSaleSql = @"
            INSERT INTO Sales (SaleNumber, SaleDate, UserId, PaymentMethod, TotalAmount, DiscountAmount, PaidAmount, ChangeGiven, Status)
            VALUES (@SaleNumber, @SaleDate, @UserId, @PaymentMethod, @TotalAmount, @DiscountAmount, @PaidAmount, @ChangeGiven, @Status);
            SELECT last_insert_rowid();
        ";

        var saleId = await connection.ExecuteScalarAsync<int>(insertSaleSql, new
        {
            sale.SaleNumber,
            SaleDate = sale.SaleDate.ToString("yyyy-MM-dd HH:mm:ss"),
            sale.UserId,
            sale.PaymentMethod,
            sale.TotalAmount,
            sale.DiscountAmount,
            sale.PaidAmount,
            sale.ChangeGiven,
            sale.Status
        }, transaction);

        const string insertItemSql = @"
            INSERT INTO SaleItems (SaleId, StockLotId, Quantity, UnitPrice, LineTotal)
            VALUES (@SaleId, @StockLotId, @Quantity, @UnitPrice, @LineTotal);
        ";

        foreach (var item in items)
        {
            item.SaleId = saleId;
            await connection.ExecuteAsync(insertItemSql, item, transaction);
        }

        return saleId;
    }

    public async Task<string> GenerateNextSaleNumberAsync(IDbConnection? connection = null, IDbTransaction? transaction = null)
    {
        var shouldDispose = false;
        if (connection == null)
        {
            connection = _connectionFactory.CreateConnection();
            shouldDispose = true;
        }

        try
        {
            var datePrefix = DateTime.Now.ToString("yyyyMMdd");
            var prefixPattern = $"VTE-{datePrefix}-%";

            const string sql = @"
                SELECT SaleNumber 
                FROM Sales 
                WHERE SaleNumber LIKE @Pattern 
                ORDER BY Id DESC 
                LIMIT 1;
            ";

            var lastNumber = await connection.ExecuteScalarAsync<string>(sql, new { Pattern = prefixPattern }, transaction);
            int nextSeq = 1;

            if (!string.IsNullOrWhiteSpace(lastNumber))
            {
                var parts = lastNumber.Split('-');
                if (parts.Length == 3 && int.TryParse(parts[2], out var lastSeq))
                {
                    nextSeq = lastSeq + 1;
                }
            }

            return $"VTE-{datePrefix}-{nextSeq:D4}";
        }
        finally
        {
            if (shouldDispose)
            {
                connection.Dispose();
            }
        }
    }

    public async Task<SaleDetailDto?> GetSaleByIdAsync(int saleId)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string saleSql = @"
            SELECT s.Id, s.SaleNumber, s.SaleDate, s.UserId, s.PaymentMethod,
                   s.TotalAmount, s.DiscountAmount, s.PaidAmount, s.ChangeGiven, s.Status,
                   COALESCE(u.Username, 'Inconnu') AS UserName
            FROM Sales s
            LEFT JOIN Users u ON s.UserId = u.Id
            WHERE s.Id = @Id;
        ";

        var sale = await connection.QuerySingleOrDefaultAsync<SaleDetailDto>(saleSql, new { Id = saleId });
        if (sale == null) return null;

        sale.Items = (await GetSaleItemsAsync(connection, sale.Id)).ToList();
        return sale;
    }

    public async Task<SaleDetailDto?> GetSaleByNumberAsync(string saleNumber)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string saleSql = @"
            SELECT s.Id, s.SaleNumber, s.SaleDate, s.UserId, s.PaymentMethod,
                   s.TotalAmount, s.DiscountAmount, s.PaidAmount, s.ChangeGiven, s.Status,
                   COALESCE(u.Username, 'Inconnu') AS UserName
            FROM Sales s
            LEFT JOIN Users u ON s.UserId = u.Id
            WHERE s.SaleNumber = @SaleNumber;
        ";

        var sale = await connection.QuerySingleOrDefaultAsync<SaleDetailDto>(saleSql, new { SaleNumber = saleNumber });
        if (sale == null) return null;

        sale.Items = (await GetSaleItemsAsync(connection, sale.Id)).ToList();
        return sale;
    }

    private async Task<IEnumerable<SaleItemDetailDto>> GetSaleItemsAsync(IDbConnection connection, int saleId)
    {
        const string itemsSql = @"
            SELECT si.Id, si.SaleId, si.StockLotId, si.Quantity, si.UnitPrice, si.LineTotal,
                   l.ProductId, l.LotNumber, l.ExpiryDate,
                   p.Reference AS ProductReference, p.Name AS ProductName
            FROM SaleItems si
            JOIN StockLots l ON si.StockLotId = l.Id
            JOIN Products p ON l.ProductId = p.Id
            WHERE si.SaleId = @SaleId
            ORDER BY si.Id ASC;
        ";

        return await connection.QueryAsync<SaleItemDetailDto>(itemsSql, new { SaleId = saleId });
    }

    public async Task<ShiftSummaryDto> GetShiftSummaryAsync(DateTime date)
    {
        using var connection = _connectionFactory.CreateConnection();
        var dateStr = date.ToString("yyyy-MM-dd");

        const string sql = @"
            SELECT 
                COUNT(1) AS TotalSalesCount,
                COALESCE(SUM(TotalAmount - DiscountAmount), 0) AS TotalSalesAmount,
                COALESCE(SUM(DiscountAmount), 0) AS TotalDiscounts,
                COALESCE(SUM(CASE WHEN PaymentMethod = 'Cash' THEN (TotalAmount - DiscountAmount) ELSE 0 END), 0) AS CashSalesAmount,
                COALESCE(SUM(CASE WHEN PaymentMethod = 'CreditCard' THEN (TotalAmount - DiscountAmount) ELSE 0 END), 0) AS CardSalesAmount,
                COALESCE(SUM(CASE WHEN PaymentMethod = 'MobilePayment' THEN (TotalAmount - DiscountAmount) ELSE 0 END), 0) AS MobileSalesAmount,
                COALESCE(SUM(CASE WHEN PaymentMethod NOT IN ('Cash', 'CreditCard', 'MobilePayment') THEN (TotalAmount - DiscountAmount) ELSE 0 END), 0) AS OtherSalesAmount
            FROM Sales
            WHERE date(SaleDate) = @DateStr
              AND Status = 'Completed';
        ";

        var summary = await connection.QuerySingleAsync<ShiftSummaryDto>(sql, new { DateStr = dateStr });
        summary.Date = date.Date;
        return summary;
    }

    public async Task<IEnumerable<SaleDetailDto>> GetRecentSalesAsync(int count = 50)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
            SELECT s.Id, s.SaleNumber, s.SaleDate, s.UserId, s.PaymentMethod,
                   s.TotalAmount, s.DiscountAmount, s.PaidAmount, s.ChangeGiven, s.Status,
                   COALESCE(u.Username, 'Inconnu') AS UserName
            FROM Sales s
            LEFT JOIN Users u ON s.UserId = u.Id
            ORDER BY s.Id DESC
            LIMIT @Count;
        ";

        return await connection.QueryAsync<SaleDetailDto>(sql, new { Count = count });
    }
}
