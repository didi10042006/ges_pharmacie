namespace GestionPharmacie.Models.Entities;

public class AuditLog
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string Action { get; set; } = string.Empty; // e.g. "LOGIN", "PRODUCT_CREATE", "STOCK_ADJUSTMENT", "SALE_COMPLETE"
    public string? Details { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;

    // Navigation / Related entities
    public User? User { get; set; }
}
