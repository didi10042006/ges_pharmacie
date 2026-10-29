using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.Models.Entities;

public class Sale
{
    public int Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; } = DateTime.Now;
    public int UserId { get; set; }
    public string PaymentMethod { get; set; } = Enums.PaymentMethod.Cash.ToString();
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; } = 0m;
    public decimal PaidAmount { get; set; }
    public decimal ChangeGiven { get; set; } = 0m;
    public string Status { get; set; } = SaleStatus.Completed.ToString();

    // Navigation / Related entities
    public User? User { get; set; }
    public List<SaleItem> Items { get; set; } = new();

    // Helper enums
    public SaleStatus SaleStatus
    {
        get => Enum.TryParse<SaleStatus>(Status, true, out var s) ? s : SaleStatus.Completed;
        set => Status = value.ToString();
    }

    public PaymentMethod PaymentMethodEnum
    {
        get => Enum.TryParse<PaymentMethod>(PaymentMethod, true, out var p) ? p : Enums.PaymentMethod.Cash;
        set => PaymentMethod = value.ToString();
    }

    public decimal FinalAmount => TotalAmount - DiscountAmount;
}
