using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.UI.Forms;

public partial class ShiftCloseForm : Form
{
    private readonly ISaleService _saleService;
    private readonly DateTime _date;
    private ShiftSummaryDto? _summary;

    public ShiftCloseForm(ISaleService saleService, DateTime? date = null)
    {
        _saleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
        _date = date ?? DateTime.Today;

        InitializeComponent();

        this.Load += async (s, e) => await LoadSummaryAsync();
    }

    private async Task LoadSummaryAsync()
    {
        _summary = await _saleService.GetShiftSummaryAsync(_date);

        lblSalesCount.Text = $"Transactions : {_summary.TotalSalesCount}";
        lblTotalNet.Text = $"Total Net Encaissé : {_summary.TotalSalesAmount:C2}";
        lblExpectedCash.Text = $"Espèces attendues : {_summary.CashSalesAmount:C2}";
        lblCardSales.Text = $"Carte Bancaire : {_summary.CardSalesAmount:C2}";
        lblMobileSales.Text = $"Paiement Mobile : {_summary.MobileSalesAmount:C2}";
        lblTotalDiscounts.Text = $"Remises accordées : {_summary.TotalDiscounts:C2}";

        // Valeur initiale = montant attendu
        nudCountedCash.Value = _summary.CashSalesAmount;
        CalculateDiscrepancy();
    }

    private void CalculateDiscrepancy()
    {
        if (_summary == null) return;

        var expected = _summary.CashSalesAmount;
        var counted = nudCountedCash.Value;
        var diff = counted - expected;

        if (diff == 0)
        {
            lblDifferenceValue.Text = "0,00 € (Équilibré)";
            lblDifferenceValue.ForeColor = Color.FromArgb(13, 110, 87); // Vert
        }
        else if (diff < 0)
        {
            lblDifferenceValue.Text = $"{diff:C2} (Déficit / Manquant)";
            lblDifferenceValue.ForeColor = Color.FromArgb(200, 35, 51); // Rouge
        }
        else
        {
            lblDifferenceValue.Text = $"+{diff:C2} (Excédent)";
            lblDifferenceValue.ForeColor = Color.FromArgb(194, 65, 12); // Ambre / Orange
        }
    }

    private void NudCountedCash_ValueChanged(object? sender, EventArgs e)
    {
        CalculateDiscrepancy();
    }

    private async void BtnConfirmClose_Click(object? sender, EventArgs e)
    {
        if (_summary == null) return;

        var counted = nudCountedCash.Value;
        var diff = counted - _summary.CashSalesAmount;
        var notes = txtNotes.Text.Trim();

        var message = $"Confirmez-vous la clôture de caisse du {_date:dd/MM/yyyy} ?\n\n" +
                      $"• Espèces attendues : {_summary.CashSalesAmount:C2}\n" +
                      $"• Espèces comptées : {counted:C2}\n" +
                      $"• Écart de trésorerie : {diff:C2}\n\n" +
                      "Un rapport d'audit sera immédiatement enregistré.";

        if (MessageBox.Show(message, "Confirmation de Clôture", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        btnConfirmClose.Enabled = false;
        try
        {
            await _saleService.RecordShiftCloseAsync(_date, counted, notes);
            MessageBox.Show("La clôture de caisse a été validée et enregistrée avec succès dans le journal d'audit.", "Clôture enregistrée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnConfirmClose.Enabled = true;
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
