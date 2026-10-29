namespace GestionPharmacie.Models.Entities;

public class SaleItem
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public int StockLotId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }

    // Navigation / Related entities
    public Sale? Sale { get; set; }
    public StockLot? StockLot { get; set; }
}
