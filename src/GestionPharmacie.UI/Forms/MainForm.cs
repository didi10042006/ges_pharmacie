using System.Drawing;
using System.Windows.Forms;
using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.UI.Controls;

namespace GestionPharmacie.UI.Forms;

public partial class MainForm : Form
{
    private readonly IAuthService _authService;
    private readonly IProductService _productService;
    private readonly IStockService _stockService;
    private readonly ISaleService _saleService;
    private readonly IReceiptService _receiptService;
    private readonly IDashboardService _dashboardService;
    private readonly IInventoryService _inventoryService;
    private readonly IReportService _reportService;
    private readonly IBackupService _backupService;

    private DashboardControl? _dashboardControl;
    private PosControl? _posControl;
    private ProductsControl? _productsControl;
    private StockEntryControl? _stockEntryControl;
    private InventoryControl? _inventoryControl;
    private ReportsControl? _reportsControl;
    private BackupControl? _backupControl;

    public MainForm(
        IAuthService authService,
        IProductService productService,
        IStockService stockService,
        ISaleService saleService,
        IReceiptService receiptService,
        IDashboardService dashboardService,
        IInventoryService inventoryService,
        IReportService reportService,
        IBackupService backupService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _stockService = stockService ?? throw new ArgumentNullException(nameof(stockService));
        _saleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
        _receiptService = receiptService ?? throw new ArgumentNullException(nameof(receiptService));
        _dashboardService = dashboardService ?? throw new ArgumentNullException(nameof(dashboardService));
        _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
        _backupService = backupService ?? throw new ArgumentNullException(nameof(backupService));

        InitializeComponent();

        ApplyRbacRestrictions();
        UpdateClock();

        // Vue par défaut selon le rôle
        if (UserSession.Instance.IsVendeur)
        {
            ShowPosView();
        }
        else
        {
            ShowDashboardView();
        }
    }

    private void UpdateClock()
    {
        lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private void TmrClock_Tick(object? sender, EventArgs e)
    {
        UpdateClock();
    }

    private void ApplyRbacRestrictions()
    {
        var session = UserSession.Instance;

        if (!session.IsAuthenticated)
        {
            lblUserBadge.Text = "Non connecté";
            return;
        }

        lblUserBadge.Text = $"👤 {session.Username} ({session.Role})";

        // Application stricte RBAC
        btnNavDashboard.Visible = session.IsAdmin;
        btnNavStock.Visible = session.CanManageStock;
        btnNavInventory.Visible = session.CanManageStock;
        btnNavReports.Visible = session.CanViewFinancials;
        btnNavBackup.Visible = session.IsAdmin;
        btnNavAudit.Visible = session.CanViewAuditLogs;
        btnNavSettings.Visible = session.CanManageSettings;
    }

    private void SetActiveButton(Button activeButton)
    {
        var navButtons = new[]
        {
            btnNavDashboard,
            btnNavSales,
            btnNavProducts,
            btnNavStock,
            btnNavInventory,
            btnNavReports,
            btnNavBackup,
            btnNavAudit,
            btnNavSettings
        };

        foreach (var btn in navButtons)
        {
            if (btn == activeButton)
            {
                btn.BackColor = Color.FromArgb(37, 51, 64);
                btn.ForeColor = Color.White;
                btn.Font = new Font(btn.Font, FontStyle.Bold);
                pnlActiveIndicator.Top = btn.Top;
                pnlActiveIndicator.Visible = true;
            }
            else
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(200, 210, 220);
                btn.Font = new Font(btn.Font, FontStyle.Regular);
            }
        }
    }

    private void LoadView(UserControl control, Button activeButton)
    {
        pnlContent.SuspendLayout();

        pnlContent.Controls.Clear();
        control.Dock = DockStyle.Fill;
        pnlContent.Controls.Add(control);

        SetActiveButton(activeButton);

        pnlContent.ResumeLayout();
    }

    private void ShowDashboardView()
    {
        _dashboardControl ??= new DashboardControl(_dashboardService);
        LoadView(_dashboardControl, btnNavDashboard);
        _ = _dashboardControl.RefreshDashboardAsync();
    }

    private void ShowPosView()
    {
        _posControl ??= new PosControl(_saleService, _productService, _receiptService);
        LoadView(_posControl, btnNavSales);
    }

    private void ShowProductsView()
    {
        _productsControl ??= new ProductsControl(_productService);
        LoadView(_productsControl, btnNavProducts);
        _ = _productsControl.LoadProductsAsync();
    }

    private void ShowStockEntryView()
    {
        if (!UserSession.Instance.CanManageStock)
        {
            MessageBox.Show("Accès refusé : la gestion des réceptions est réservée aux pharmaciens et administrateurs.",
                "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _stockEntryControl ??= new StockEntryControl(_stockService, _productService);
        LoadView(_stockEntryControl, btnNavStock);
        _ = _stockEntryControl.RefreshDataAsync();
    }

    private void ShowInventoryView()
    {
        if (!UserSession.Instance.CanManageStock)
        {
            MessageBox.Show("Accès refusé : les inventaires et ajustements de stock sont réservés aux gestionnaires.",
                "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _inventoryControl ??= new InventoryControl(_inventoryService, _reportService);
        LoadView(_inventoryControl, btnNavInventory);
        _ = _inventoryControl.LoadLotsAsync();
    }

    private void ShowReportsView()
    {
        if (!UserSession.Instance.CanViewFinancials)
        {
            MessageBox.Show("Accès refusé : les rapports financiers et marges brutes sont réservés aux administrateurs.",
                "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _reportsControl ??= new ReportsControl(_reportService);
        LoadView(_reportsControl, btnNavReports);
        _ = _reportsControl.LoadReportAsync();
    }

    private void ShowBackupView()
    {
        if (!UserSession.Instance.IsAdmin)
        {
            MessageBox.Show("Accès refusé : les sauvegardes et restaurations SQLite sont réservées exclusivement à l'administrateur.",
                "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _backupControl ??= new BackupControl(_backupService);
        LoadView(_backupControl, btnNavBackup);
        _backupControl.LoadBackups();
    }

    private void BtnNavDashboard_Click(object? sender, EventArgs e)
    {
        ShowDashboardView();
    }

    private void BtnNavSales_Click(object? sender, EventArgs e)
    {
        ShowPosView();
    }

    private void BtnNavProducts_Click(object? sender, EventArgs e)
    {
        ShowProductsView();
    }

    private void BtnNavStock_Click(object? sender, EventArgs e)
    {
        ShowStockEntryView();
    }

    private void BtnNavInventory_Click(object? sender, EventArgs e)
    {
        ShowInventoryView();
    }

    private void BtnNavReports_Click(object? sender, EventArgs e)
    {
        ShowReportsView();
    }

    private void BtnNavBackup_Click(object? sender, EventArgs e)
    {
        ShowBackupView();
    }

    private void BtnNavAudit_Click(object? sender, EventArgs e)
    {
        SetActiveButton(btnNavAudit);
        ShowPlaceholderView("📋 Journal d'Audit", "Consultation des opérations sensibles et traçabilité des modifications.");
    }

    private void BtnNavSettings_Click(object? sender, EventArgs e)
    {
        SetActiveButton(btnNavSettings);
        ShowPlaceholderView("⚙️ Paramètres Officine", "Configuration de l'officine (Nom, coordonnées, seuils d'alertes).");
    }

    private void ShowPlaceholderView(string title, string message)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(248, 250, 252)
        };

        var lbl = new Label
        {
            Text = $"{title}\n\n{message}",
            Font = new Font("Segoe UI", 12F, FontStyle.Regular),
            ForeColor = Color.FromArgb(80, 90, 100),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill
        };

        panel.Controls.Add(lbl);

        pnlContent.SuspendLayout();
        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(panel);
        pnlContent.ResumeLayout();
    }

    private void BtnAbout_Click(object? sender, EventArgs e)
    {
        using var aboutForm = new AboutForm();
        aboutForm.ShowDialog(this);
    }

    private void BtnLogout_Click(object? sender, EventArgs e)
    {
        var confirm = MessageBox.Show(
            "Êtes-vous sûr de vouloir vous déconnecter de la session actuelle ?",
            "Confirmation de déconnexion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            _authService.Logout();
            this.DialogResult = DialogResult.Retry; // Permet à Program.cs de réafficher l'écran de connexion
            this.Close();
        }
    }
}
