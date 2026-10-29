namespace GestionPharmacie.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string? Dosage { get; set; }
    public string? Form { get; set; } // Comprimé, Sirop, Pommade, Gélule, etc.
    public decimal SellingPrice { get; set; }
    public int MinStockThreshold { get; set; } = 5;
    public bool IsArchived { get; set; } = false;

    // Navigation / Display property
    public List<StockLot> StockLots { get; set; } = new();
}
