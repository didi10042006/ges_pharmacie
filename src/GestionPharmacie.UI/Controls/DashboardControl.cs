using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.UI.Controls;

public partial class DashboardControl : UserControl
{
    private readonly IDashboardService _dashboardService;

    public DashboardControl(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService ?? throw new ArgumentNullException(nameof(dashboardService));
        InitializeComponent();

        SetupGrids();

        this.Load += async (s, e) => await RefreshDashboardAsync();
    }

    private void SetupGrids()
    {
        // 1. Grille Alertes Niveaux de Stock
        dgvStockAlerts.AutoGenerateColumns = false;
        dgvStockAlerts.Columns.Clear();

        dgvStockAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductStockAlertDto.Reference),
            HeaderText = "RÉFÉRENCE",
            FillWeight = 70
        });

        dgvStockAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductStockAlertDto.Name),
            HeaderText = "MÉDICAMENT",
            FillWeight = 140
        });

        dgvStockAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductStockAlertDto.CurrentStock),
            HeaderText = "STOCK DISPO",
            FillWeight = 65,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
        });

        dgvStockAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductStockAlertDto.MinStockThreshold),
            HeaderText = "SEUIL",
            FillWeight = 50,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvStockAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductStockAlertDto.AlertType),
            HeaderText = "STATUT D'ALERTE",
            FillWeight = 95,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold) }
        });

        dgvStockAlerts.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvStockAlerts.Rows.Count) return;
            var item = dgvStockAlerts.Rows[e.RowIndex].DataBoundItem as ProductStockAlertDto;
            if (item == null) return;

            if (item.IsOutOfStock)
            {
                dgvStockAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                dgvStockAlerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            }
            else
            {
                dgvStockAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 235);
                dgvStockAlerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(180, 83, 9);
            }
        };

        // 2. Grille Alertes Péremption des Lots
        dgvExpiryAlerts.AutoGenerateColumns = false;
        dgvExpiryAlerts.Columns.Clear();

        dgvExpiryAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(LotExpiryAlertDto.ProductName),
            HeaderText = "MÉDICAMENT",
            FillWeight = 120
        });

        dgvExpiryAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(LotExpiryAlertDto.LotNumber),
            HeaderText = "N° LOT",
            FillWeight = 65
        });

        dgvExpiryAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "DATE EXPIRATION",
            FillWeight = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvExpiryAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(LotExpiryAlertDto.Quantity),
            HeaderText = "QTÉ",
            FillWeight = 45,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
        });

        dgvExpiryAlerts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(LotExpiryAlertDto.ExpiryStatus),
            HeaderText = "DÉLAI",
            FillWeight = 80,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold) }
        });

        dgvExpiryAlerts.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvExpiryAlerts.Rows.Count) return;
            var item = dgvExpiryAlerts.Rows[e.RowIndex].DataBoundItem as LotExpiryAlertDto;
            if (item == null) return;

            // Colonne Date (index 2)
            if (e.ColumnIndex == 2)
            {
                e.Value = item.ExpiryDate.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (item.IsExpired)
            {
                dgvExpiryAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                dgvExpiryAlerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            }
            else if (item.DaysRemaining <= 30)
            {
                dgvExpiryAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
                dgvExpiryAlerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(180, 83, 9);
            }
        };
    }

    public async Task RefreshDashboardAsync()
    {
        btnRefresh.Enabled = false;

        try
        {
            var metrics = await _dashboardService.GetMetricsAsync();

            // 1. KPI Ventes du jour
            lblKpiSalesValue.Text = metrics.TodaySalesAmount.ToString("C2");
            lblKpiSalesSub.Text = $"{metrics.TodaySalesCount} transaction(s) validée(s)";

            // 2. KPI Ruptures de stock (Urgence Rouge)
            lblKpiOutOfStockValue.Text = metrics.OutOfStockCount.ToString();
            lblKpiOutOfStockSub.Text = metrics.OutOfStockCount > 0 
                ? "Vente au comptoir impossible" 
                : "Aucune rupture";

            // 3. KPI Stock Faible (Ambre)
            lblKpiLowStockValue.Text = metrics.LowStockCount.ToString();

            // 4. KPI Péremption Imminente (< 90j)
            lblKpiExpiringValue.Text = metrics.ExpiringLotsCount.ToString();
            lblKpiExpiringSub.Text = metrics.ExpiredLotsCount > 0 
                ? $"⚠️ {metrics.ExpiredLotsCount} lot(s) déjà périmé(s) !" 
                : "Aucun lot périmé en rayon";

            // Alimentation des grilles
            dgvStockAlerts.DataSource = null;
            dgvStockAlerts.DataSource = metrics.StockAlerts;

            dgvExpiryAlerts.DataSource = null;
            dgvExpiryAlerts.DataSource = metrics.ExpiryAlerts;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement des indicateurs : {ex.Message}", "Erreur Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRefresh.Enabled = true;
        }
    }

    private async void BtnRefresh_Click(object? sender, EventArgs e)
    {
        await RefreshDashboardAsync();
    }
}
