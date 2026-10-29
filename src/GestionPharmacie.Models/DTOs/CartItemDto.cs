namespace GestionPharmacie.Models.DTOs;

public class CartItemDto
{
    public int ProductId { get; set; }
    public string ProductReference { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal => Quantity * UnitPrice;

    // Informations du lot sélectionné par FIFO
    public int? AllocatedLotId { get; set; }
    public string? AllocatedLotNumber { get; set; }
    public DateTime? AllocatedLotExpiry { get; set; }
    public int AvailableStock { get; set; }
}
