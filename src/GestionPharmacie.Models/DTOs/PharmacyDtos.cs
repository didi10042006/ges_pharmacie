using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.Models.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class ProductStockOverviewDto
{
    public int ProductId { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string? Dosage { get; set; }
    public string? Form { get; set; }
    public decimal SellingPrice { get; set; }
    public int MinStockThreshold { get; set; }
    public int TotalAvailableQuantity { get; set; }
    public int ActiveLotsCount { get; set; }
    public bool IsLowStock => TotalAvailableQuantity <= MinStockThreshold;
}

public class SaleItemDto
{
    public int StockLotId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string LotNumber { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => Quantity * UnitPrice;
}

public class SaleCreateDto
{
    public int UserId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public List<SaleItemDto> Items { get; set; } = new();
}

public class DashboardStatsDto
{
    public decimal TodayRevenue { get; set; }
    public int TodaySalesCount { get; set; }
    public int LowStockProductsCount { get; set; }
    public int ExpiringLotsCount { get; set; }
}
