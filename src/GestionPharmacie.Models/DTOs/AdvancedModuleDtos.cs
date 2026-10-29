namespace GestionPharmacie.Models.DTOs;

public class DashboardMetricsDto
{
    public decimal TodaySalesAmount { get; set; }
    public int TodaySalesCount { get; set; }
    public int OutOfStockCount { get; set; } // stock == 0
    public int LowStockCount { get; set; }    // stock > 0 and stock <= seuil
    public int ExpiringLotsCount { get; set; } // < 90 jours
    public int ExpiredLotsCount { get; set; }  // date < now
    public List<ProductStockAlertDto> StockAlerts { get; set; } = new();
    public List<LotExpiryAlertDto> ExpiryAlerts { get; set; } = new();
}

public class ProductStockAlertDto
{
    public int ProductId { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int CurrentStock { get; set; }
    public int MinStockThreshold { get; set; }
    public bool IsOutOfStock => CurrentStock == 0;
    public string AlertType => IsOutOfStock ? "🚨 RUPTURE TOTALE" : "⚠️ STOCK FAIBLE";
}

public class LotExpiryAlertDto
{
    public int LotId { get; set; }
    public string ProductReference { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string LotNumber { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public int Quantity { get; set; }
    public int DaysRemaining => (int)(ExpiryDate.Date - DateTime.Today).TotalDays;
    public bool IsExpired => DaysRemaining < 0;
    public string ExpiryStatus => IsExpired 
        ? $"PÉRIMÉ ({Math.Abs(DaysRemaining)}j)" 
        : $"Expire dans {DaysRemaining}j";
}

public class InventoryLotItemDto
{
    public int LotId { get; set; }
    public int ProductId { get; set; }
    public string ProductReference { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string LotNumber { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public int TheoreticalQuantity { get; set; }
    public decimal PurchaseCost { get; set; }
    public decimal SellingPrice { get; set; }
    public bool IsBlocked { get; set; }
    public string ExpiryFormatted => ExpiryDate.ToString("dd/MM/yyyy");
    public string StatusDisplay => IsBlocked ? "🔒 Bloqué" : (ExpiryDate.Date < DateTime.Today ? "⚠️ Périmé" : "✅ Actif");
}

public class SalesPeriodReportDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalSalesCount { get; set; }
    public decimal TotalGrossAmount { get; set; }
    public decimal TotalDiscountAmount { get; set; }
    public decimal TotalNetAmount { get; set; }
    public decimal TotalPurchaseCost { get; set; }
    public decimal TotalGrossMargin => TotalNetAmount - TotalPurchaseCost;
    public decimal MarginRatePercentage => TotalNetAmount > 0 ? (TotalGrossMargin / TotalNetAmount) * 100 : 0;
    public List<ProductSaleMarginDto> ProductSales { get; set; } = new();
}

public class ProductSaleMarginDto
{
    public string ProductReference { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int TotalQuantitySold { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal TotalCost { get; set; }
    public decimal GrossMargin => TotalRevenue - TotalCost;
    public decimal MarginRate => TotalRevenue > 0 ? (GrossMargin / TotalRevenue) * 100 : 0;
}
