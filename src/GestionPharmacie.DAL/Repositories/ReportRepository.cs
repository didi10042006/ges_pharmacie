using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.DAL.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ReportRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<DashboardMetricsDto> GetDashboardMetricsAsync(int expiryDaysThreshold = 90)
    {
        using var connection = _connectionFactory.CreateConnection();
        var metrics = new DashboardMetricsDto();

        // 1. Ventes du jour
        const string todaySalesSql = @"
            SELECT 
                COUNT(1) AS SalesCount,
                COALESCE(SUM(TotalAmount - DiscountAmount), 0) AS SalesTotal
            FROM Sales
            WHERE date(SaleDate) = date('now')
              AND Status = 'Completed';
        ";
        var todaySales = await connection.QuerySingleAsync<(int SalesCount, decimal SalesTotal)>(todaySalesSql);
        metrics.TodaySalesCount = todaySales.SalesCount;
        metrics.TodaySalesAmount = todaySales.SalesTotal;

        // 2. Alertes Stock (Ruptures & Sous le seuil)
        const string stockSql = @"
            SELECT 
                p.Id AS ProductId,
                p.Reference,
                p.Name,
                p.MinStockThreshold,
                COALESCE(SUM(CASE WHEN l.IsBlocked = 0 AND date(l.ExpiryDate) >= date('now') THEN l.Quantity ELSE 0 END), 0) AS CurrentStock
            FROM Products p
            LEFT JOIN StockLots l ON p.Id = l.ProductId
            WHERE p.IsArchived = 0
            GROUP BY p.Id
            HAVING CurrentStock <= p.MinStockThreshold
            ORDER BY CurrentStock ASC, p.Name ASC;
        ";

        var stockAlerts = (await connection.QueryAsync<ProductStockAlertDto>(stockSql)).ToList();
        metrics.StockAlerts = stockAlerts;
        metrics.OutOfStockCount = stockAlerts.Count(a => a.IsOutOfStock);
        metrics.LowStockCount = stockAlerts.Count(a => !a.IsOutOfStock);

        // 3. Alertes Péremption
        const string expirySql = @"
            SELECT 
                l.Id AS LotId,
                p.Reference AS ProductReference,
                p.Name AS ProductName,
                l.LotNumber,
                l.ExpiryDate,
                l.Quantity
            FROM StockLots l
            JOIN Products p ON l.ProductId = p.Id
            WHERE l.Quantity > 0
              AND date(l.ExpiryDate) <= date('now', '+' || @Days || ' days')
            ORDER BY date(l.ExpiryDate) ASC;
        ";

        var expiryAlerts = (await connection.QueryAsync<LotExpiryAlertDto>(expirySql, new { Days = expiryDaysThreshold })).ToList();
        metrics.ExpiryAlerts = expiryAlerts;
        metrics.ExpiringLotsCount = expiryAlerts.Count(a => !a.IsExpired);
        metrics.ExpiredLotsCount = expiryAlerts.Count(a => a.IsExpired);

        return metrics;
    }

    public async Task<SalesPeriodReportDto> GetSalesReportByPeriodAsync(DateTime startDate, DateTime endDate)
    {
        using var connection = _connectionFactory.CreateConnection();
        var startStr = startDate.ToString("yyyy-MM-dd");
        var endStr = endDate.ToString("yyyy-MM-dd");

        var report = new SalesPeriodReportDto
        {
            StartDate = startDate.Date,
            EndDate = endDate.Date
        };

        // 1. Synthèse globale de la période
        const string totalSql = @"
            SELECT 
                COUNT(1) AS SalesCount,
                COALESCE(SUM(TotalAmount), 0) AS GrossTotal,
                COALESCE(SUM(DiscountAmount), 0) AS DiscountTotal,
                COALESCE(SUM(TotalAmount - DiscountAmount), 0) AS NetTotal
            FROM Sales
            WHERE date(SaleDate) BETWEEN @Start AND @End
              AND Status = 'Completed';
        ";

        var totals = await connection.QuerySingleAsync<(int SalesCount, decimal GrossTotal, decimal DiscountTotal, decimal NetTotal)>(
            totalSql, 
            new { Start = startStr, End = endStr }
        );

        report.TotalSalesCount = totals.SalesCount;
        report.TotalGrossAmount = totals.GrossTotal;
        report.TotalDiscountAmount = totals.DiscountTotal;
        report.TotalNetAmount = totals.NetTotal;

        // 2. Détail par produit et calcul de la marge brute
        const string marginSql = @"
            SELECT 
                p.Reference AS ProductReference,
                p.Name AS ProductName,
                SUM(si.Quantity) AS TotalQuantitySold,
                SUM(si.LineTotal) AS TotalRevenue,
                SUM(si.Quantity * l.PurchaseCost) AS TotalCost
            FROM SaleItems si
            JOIN Sales s ON si.SaleId = s.Id
            JOIN StockLots l ON si.StockLotId = l.Id
            JOIN Products p ON l.ProductId = p.Id
            WHERE date(s.SaleDate) BETWEEN @Start AND @End
              AND s.Status = 'Completed'
            GROUP BY p.Id
            ORDER BY TotalRevenue DESC;
        ";

        var productMargins = (await connection.QueryAsync<ProductSaleMarginDto>(marginSql, new { Start = startStr, End = endStr })).ToList();
        report.ProductSales = productMargins;
        report.TotalPurchaseCost = productMargins.Sum(p => p.TotalCost);

        return report;
    }
}
