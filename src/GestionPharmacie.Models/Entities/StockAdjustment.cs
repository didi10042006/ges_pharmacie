using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.Models.Entities;

public class StockAdjustment
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int StockLotId { get; set; }
    public int QuantityChange { get; set; } // Can be negative (deduction) or positive (addition)
    public string Reason { get; set; } = StockAdjustmentReason.InventoryCorrection.ToString();
    public int UserId { get; set; }
    public DateTime AdjustmentDate { get; set; } = DateTime.Now;

    // Navigation / Related entities
    public Product? Product { get; set; }
    public StockLot? StockLot { get; set; }
    public User? User { get; set; }

    public StockAdjustmentReason ReasonEnum
    {
        get => Enum.TryParse<StockAdjustmentReason>(Reason, true, out var r) ? r : StockAdjustmentReason.Other;
        set => Reason = value.ToString();
    }
}
