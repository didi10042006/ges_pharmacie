using System.Drawing;
using System.Windows.Forms;
using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.UI.Controls;

public partial class ReportsControl : UserControl
{
    private readonly IReportService _reportService;
    private SalesPeriodReportDto? _currentReport;

    public ReportsControl(IReportService reportService)
    {
        _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));

        InitializeComponent();
        ConfigureGridColumns();
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // RBAC Check : seuls les Administrateurs/Gestionnaires financiers accèdent aux marges
        if (!UserSession.Instance.CanViewFinancials)
        {
            MessageBox.Show("Accès restreint. Seuls les Administrateurs ont accès aux rapports financiers et aux calculs de marge brute.",
                "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Enabled = false;
            return;
        }

        // Par défaut : du 1er jour du mois courant à aujourd'hui
        DateTime now = DateTime.Now;
        dtpStartDate.Value = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
        dtpEndDate.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

        await LoadReportAsync();
    }

    private void ConfigureGridColumns()
    {
        dgvProductMargins.AutoGenerateColumns = false;
        dgvProductMargins.Columns.Clear();

        dgvProductMargins.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductSaleMarginDto.ProductReference),
            HeaderText = "RÉFÉRENCE",
            FillWeight = 80
        });

        dgvProductMargins.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductSaleMarginDto.ProductName),
            HeaderText = "MÉDICAMENT",
            FillWeight = 160
        });

        dgvProductMargins.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductSaleMarginDto.TotalQuantitySold),
            HeaderText = "QTÉ VENDUE",
            FillWeight = 65,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvProductMargins.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductSaleMarginDto.TotalRevenue),
            HeaderText = "CA TOTAL (€)",
            FillWeight = 85,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
        });

        dgvProductMargins.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductSaleMarginDto.TotalCost),
            HeaderText = "COÛT ACHAT (€)",
            FillWeight = 85,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
        });

        dgvProductMargins.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductSaleMarginDto.GrossMargin),
            HeaderText = "MARGE BRUTE (€)",
            FillWeight = 95,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(13, 110, 87),
                Format = "N2"
            }
        });

        dgvProductMargins.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductSaleMarginDto.MarginRate),
            HeaderText = "TAUX MARGE (%)",
            FillWeight = 80,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
        });

        dgvProductMargins.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvProductMargins.Rows.Count) return;
            var item = dgvProductMargins.Rows[e.RowIndex].DataBoundItem as ProductSaleMarginDto;
            if (item == null) return;

            // Alerte si marge négative
            if (item.GrossMargin < 0)
            {
                dgvProductMargins.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.FromArgb(220, 38, 38);
            }
        };
    }

    public async Task LoadReportAsync()
    {
        try
        {
            Cursor = Cursors.WaitCursor;

            DateTime start = dtpStartDate.Value.Date;
            DateTime end = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

            _currentReport = await _reportService.GetSalesReportAsync(start, end);

            lblCardGrossRevenueValue.Text = $"{_currentReport.TotalGrossAmount:N2} €";
            lblCardNetRevenueValue.Text = $"{_currentReport.TotalNetAmount:N2} €";
            lblCardPurchaseCostValue.Text = $"{_currentReport.TotalPurchaseCost:N2} €";
            lblCardGrossMarginValue.Text = $"{(_currentReport.TotalGrossMargin >= 0 ? "+" : "")}{_currentReport.TotalGrossMargin:N2} €";
            lblCardMarginRateValue.Text = $"{_currentReport.MarginRatePercentage:F1} %";

            if (_currentReport.TotalGrossMargin < 0)
            {
                lblCardGrossMarginValue.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                lblCardGrossMarginValue.ForeColor = Color.FromArgb(13, 110, 87);
            }

            dgvProductMargins.DataSource = null;
            dgvProductMargins.DataSource = _currentReport.ProductSales;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de la génération du rapport : {ex.Message}", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async void BtnFilter_Click(object? sender, EventArgs e)
    {
        if (dtpStartDate.Value > dtpEndDate.Value)
        {
            MessageBox.Show("La date de début ne peut pas être postérieure à la date de fin.", "Période invalide",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await LoadReportAsync();
    }

    private async void BtnQuickToday_Click(object? sender, EventArgs e)
    {
        dtpStartDate.Value = DateTime.Today;
        dtpEndDate.Value = DateTime.Today;
        await LoadReportAsync();
    }

    private async void BtnQuickThisMonth_Click(object? sender, EventArgs e)
    {
        DateTime now = DateTime.Today;
        dtpStartDate.Value = new DateTime(now.Year, now.Month, 1);
        dtpEndDate.Value = now;
        await LoadReportAsync();
    }

    private async void BtnQuickThisYear_Click(object? sender, EventArgs e)
    {
        DateTime now = DateTime.Today;
        dtpStartDate.Value = new DateTime(now.Year, 1, 1);
        dtpEndDate.Value = now;
        await LoadReportAsync();
    }

    private async void BtnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadReportAsync();
    }

    private void BtnExportCsv_Click(object? sender, EventArgs e)
    {
        if (_currentReport == null)
        {
            MessageBox.Show("Aucune donnée de rapport à exporter.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var sfd = new SaveFileDialog
        {
            Filter = "Fichier CSV (*.csv)|*.csv",
            FileName = $"Rapport_Ventes_Marges_{DateTime.Now:yyyyMMdd_HHmm}.csv",
            Title = "Exporter le rapport de ventes et marges en CSV"
        };

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string csv = _reportService.ExportSalesReportToCsv(_currentReport);
                File.WriteAllText(sfd.FileName, csv, System.Text.Encoding.UTF8);

                MessageBox.Show($"Rapport exporté avec succès !\n{sfd.FileName}",
                    "Exportation réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'export CSV : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
