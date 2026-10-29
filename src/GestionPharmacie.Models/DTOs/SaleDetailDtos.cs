namespace GestionPharmacie.Models.DTOs;

public class SaleItemDetailDto
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public int StockLotId { get; set; }
    public int ProductId { get; set; }
    public string ProductReference { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string LotNumber { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}

public class SaleDetailDto
{
    public int Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal NetAmount => TotalAmount - DiscountAmount;
    public decimal PaidAmount { get; set; }
    public decimal ChangeGiven { get; set; }
    public string Status { get; set; } = "Completed";
    public List<SaleItemDetailDto> Items { get; set; } = new();
}

public class ShiftSummaryDto
{
    public DateTime Date { get; set; } = DateTime.Today;
    public int TotalSalesCount { get; set; }
    public decimal TotalSalesAmount { get; set; }
    public decimal CashSalesAmount { get; set; }
    public decimal CardSalesAmount { get; set; }
    public decimal MobileSalesAmount { get; set; }
    public decimal OtherSalesAmount { get; set; }
    public decimal TotalDiscounts { get; set; }
}
