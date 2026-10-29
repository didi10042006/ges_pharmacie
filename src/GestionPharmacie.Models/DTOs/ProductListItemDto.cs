namespace GestionPharmacie.Models.DTOs;

public class ProductListItemDto
{
    public int Id { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string? Dosage { get; set; }
    public string? Form { get; set; }
    public decimal SellingPrice { get; set; }
    public int MinStockThreshold { get; set; }
    public int CurrentStock { get; set; }
    public bool IsArchived { get; set; }

    public bool IsLowStock => !IsArchived && CurrentStock <= MinStockThreshold;
    public string StatusDisplay => IsArchived ? "Archivé" : (IsLowStock ? "⚠️ Stock Bas" : "✅ Normal");
}
