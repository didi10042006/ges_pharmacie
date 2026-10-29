using System.Text;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.BLL.Services;

public class ReceiptService : IReceiptService
{
    private readonly IAppSettingRepository _settingRepository;

    public ReceiptService(IAppSettingRepository settingRepository)
    {
        _settingRepository = settingRepository;
    }

    public async Task<string> GenerateReceiptTextAsync(SaleDetailDto sale)
    {
        var settings = await _settingRepository.GetAllSettingsAsync();

        var pharmacyName = settings.GetValueOrDefault("Pharmacy_Name", "PHARMACIE CENTRALE");
        var pharmacyAddress = settings.GetValueOrDefault("Pharmacy_Address", "123 Avenue de la Santé, Paris");
        var pharmacyPhone = settings.GetValueOrDefault("Pharmacy_Phone", "+33 1 23 45 67 89");

        var sb = new StringBuilder();
        const int width = 42;
        var separator = new string('-', width);
        var doubleSeparator = new string('=', width);

        // En-tête
        sb.AppendLine(CenterText(pharmacyName.ToUpper(), width));
        sb.AppendLine(CenterText(pharmacyAddress, width));
        sb.AppendLine(CenterText($"Tél : {pharmacyPhone}", width));
        sb.AppendLine(doubleSeparator);

        // Métadonnées du ticket
        sb.AppendLine($"TICKET : {sale.SaleNumber}");
        sb.AppendLine($"DATE   : {sale.SaleDate:dd/MM/yyyy HH:mm:ss}");
        sb.AppendLine($"VENDEUR: {sale.UserName}");
        sb.AppendLine(separator);

        // Entête des colonnes
        sb.AppendLine(string.Format("{0,-20} {1,4} {2,7} {3,8}", "ARTICLE", "QTÉ", "P.U", "TOTAL"));
        sb.AppendLine(separator);

        // Articles
        foreach (var item in sale.Items)
        {
            var shortName = item.ProductName.Length > 20 ? item.ProductName.Substring(0, 19) + "." : item.ProductName;
            sb.AppendLine(string.Format("{0,-20} {1,4} {2,7:F2} {3,8:F2}", shortName, item.Quantity, item.UnitPrice, item.LineTotal));
            
            // Traçabilité du lot médical
            sb.AppendLine($"  └ Lot: {item.LotNumber} (Pér: {item.ExpiryDate:MM/yyyy})");
        }

        sb.AppendLine(separator);

        // Totaux
        sb.AppendLine(string.Format("{0,-25} {1,15:C2}", "SOUS-TOTAL BRUT :", sale.TotalAmount));

        if (sale.DiscountAmount > 0)
        {
            sb.AppendLine(string.Format("{0,-25} {1,15:C2}", "REMISE ACCORDÉE :", -sale.DiscountAmount));
        }

        sb.AppendLine(doubleSeparator);
        sb.AppendLine(string.Format("{0,-25} {1,15:C2}", "TOTAL NET À PAYER :", sale.NetAmount));
        sb.AppendLine(doubleSeparator);

        // Règlements
        sb.AppendLine(string.Format("{0,-25} {1,15}", "MODE DE RÈGLEMENT :", FormatPaymentMethod(sale.PaymentMethod)));
        sb.AppendLine(string.Format("{0,-25} {1,15:C2}", "MONTANT REÇU :", sale.PaidAmount));

        if (sale.ChangeGiven > 0)
        {
            sb.AppendLine(string.Format("{0,-25} {1,15:C2}", "MONNAIE RENDUE :", sale.ChangeGiven));
        }

        sb.AppendLine(doubleSeparator);
        sb.AppendLine(CenterText("Merci de votre visite !", width));
        sb.AppendLine(CenterText("Conservez votre ticket pour échange.", width));

        return sb.ToString();
    }

    private static string CenterText(string text, int width)
    {
        if (text.Length >= width) return text;
        var pad = (width - text.Length) / 2;
        return new string(' ', pad) + text;
    }

    private static string FormatPaymentMethod(string method)
    {
        return method switch
        {
            "Cash" => "Espèces",
            "CreditCard" => "Carte Bancaire",
            "MobilePayment" => "Paiement Mobile",
            "Check" => "Chèque",
            _ => method
        };
    }
}
