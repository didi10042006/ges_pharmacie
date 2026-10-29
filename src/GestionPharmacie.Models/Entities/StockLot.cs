namespace GestionPharmacie.Models.Entities;

public class StockLot
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int? SupplierId { get; set; }
    public string LotNumber { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public int Quantity { get; set; }
    public decimal PurchaseCost { get; set; }
    public bool IsBlocked { get; set; } = false;

    // Navigation / Display helpers
    public Product? Product { get; set; }
    public Supplier? Supplier { get; set; }

    public bool IsExpired => ExpiryDate.Date < DateTime.Today;
    public bool IsNearExpiry(int daysThreshold = 90) =>
        !IsExpired && (ExpiryDate.Date - DateTime.Today).TotalDays <= daysThreshold;
}
