using System.Text;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.BLL.Services;

public interface IReportService
{
    Task<SalesPeriodReportDto> GetSalesReportAsync(DateTime startDate, DateTime endDate);
    string ExportSalesReportToCsv(SalesPeriodReportDto report);
    string ExportInventoryToCsv(IEnumerable<InventoryLotItemDto> lots);
}

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<SalesPeriodReportDto> GetSalesReportAsync(DateTime startDate, DateTime endDate)
    {
        return await _reportRepository.GetSalesReportByPeriodAsync(startDate, endDate);
    }

    public string ExportSalesReportToCsv(SalesPeriodReportDto report)
    {
        var sb = new StringBuilder();

        // Synthèse
        sb.AppendLine($"Rapport des Ventes du {report.StartDate:dd/MM/yyyy} au {report.EndDate:dd/MM/yyyy};;;;");
        sb.AppendLine($"Nombre total de ventes;{report.TotalSalesCount};;;");
        sb.AppendLine($"Chiffre d'affaires Brut;{report.TotalGrossAmount:F2} €;;;");
        sb.AppendLine($"Remises accordées;{report.TotalDiscountAmount:F2} €;;;");
        sb.AppendLine($"Chiffre d'affaires Net;{report.TotalNetAmount:F2} €;;;");
        sb.AppendLine($"Coût total d'achat des produits soldés;{report.TotalPurchaseCost:F2} €;;;");
        sb.AppendLine($"Marge Brute Indicative;{report.TotalGrossMargin:F2} €;;;");
        sb.AppendLine($"Taux de Marge Brute;{report.MarginRatePercentage:F2} %;;;");
        sb.AppendLine(";;;;");

        // En-tête des produits
        sb.AppendLine("Référence;Désignation;Quantité Vendue;Chiffre d'Affaires (€);Coût d'Achat (€);Marge Brute (€);Taux de Marge (%)");

        foreach (var p in report.ProductSales)
        {
            sb.AppendLine(
                $"\"{EscapeCsv(p.ProductReference)}\";" +
                $"\"{EscapeCsv(p.ProductName)}\";" +
                $"{p.TotalQuantitySold};" +
                $"{p.TotalRevenue:F2};" +
                $"{p.TotalCost:F2};" +
                $"{p.GrossMargin:F2};" +
                $"{p.MarginRate:F2}"
            );
        }

        return sb.ToString();
    }

    public string ExportInventoryToCsv(IEnumerable<InventoryLotItemDto> lots)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"État des Stocks & Lots au {DateTime.Now:dd/MM/yyyy HH:mm:ss};;;;;;;");
        sb.AppendLine("Référence;Désignation;Catégorie;N° de Lot;Péremption;Quantité en Stock;Coût Achat (€);Prix Vente (€);Statut");

        foreach (var lot in lots)
        {
            sb.AppendLine(
                $"\"{EscapeCsv(lot.ProductReference)}\";" +
                $"\"{EscapeCsv(lot.ProductName)}\";" +
                $"\"{EscapeCsv(lot.Category ?? "")}\";" +
                $"\"{EscapeCsv(lot.LotNumber)}\";" +
                $"{lot.ExpiryFormatted};" +
                $"{lot.TheoreticalQuantity};" +
                $"{lot.PurchaseCost:F2};" +
                $"{lot.SellingPrice:F2};" +
                $"\"{EscapeCsv(lot.StatusDisplay)}\""
            );
        }

        return sb.ToString();
    }

    private static string EscapeCsv(string text)
    {
        return text?.Replace("\"", "\"\"") ?? string.Empty;
    }
}
