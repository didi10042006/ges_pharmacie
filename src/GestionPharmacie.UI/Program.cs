using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Initialization;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.UI.Forms;

namespace GestionPharmacie.UI;

static class Program
{
    /// <summary>
    /// Point d'entrée principal de l'application de gestion de pharmacie.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Initialisation de l'infrastructure SQLite
        IDbConnectionFactory connectionFactory;
        try
        {
            connectionFactory = new DbConnectionFactory();
            var dbInitializer = new DatabaseInitializer(connectionFactory);
            dbInitializer.Initialize();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Erreur critique lors de l'initialisation de la base de données SQLite :\n\n{ex.Message}",
                "Erreur d'initialisation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            return;
        }

        // 2. Composition des dépendances DAL / BLL
        var userRepo = new UserRepository(connectionFactory);
        var auditRepo = new AuditLogRepository(connectionFactory);
        var productRepo = new ProductRepository(connectionFactory);
        var supplierRepo = new SupplierRepository(connectionFactory);
        var stockLotRepo = new StockLotRepository(connectionFactory);
        var saleRepo = new SaleRepository(connectionFactory);
        var settingRepo = new AppSettingRepository(connectionFactory);
        var inventoryRepo = new InventoryRepository(connectionFactory);
        var reportRepo = new ReportRepository(connectionFactory);

        var passwordHasher = new PasswordHasher();
        var auditLogService = new AuditLogService(auditRepo);
        var authService = new AuthService(userRepo, passwordHasher, auditLogService);
        var productService = new ProductService(productRepo, auditLogService);
        var stockService = new StockService(connectionFactory, stockLotRepo, supplierRepo, auditLogService);
        var saleService = new SaleService(connectionFactory, saleRepo, stockLotRepo, userRepo, passwordHasher, auditLogService);
        var receiptService = new ReceiptService(settingRepo);
        var dashboardService = new DashboardService(reportRepo);
        var inventoryService = new InventoryService(inventoryRepo, auditLogService);
        var reportService = new ReportService(reportRepo);
        var backupService = new BackupService(connectionFactory, auditLogService);

        // 3. Boucle d'authentification et session utilisateur
        while (true)
        {
            using var loginForm = new LoginForm(authService);
            var loginResult = loginForm.ShowDialog();

            // Si l'utilisateur annule ou ferme le formulaire de connexion
            if (loginResult != DialogResult.OK)
            {
                break;
            }

            // Lancement du formulaire principal avec navigation complète et restrictions RBAC
            using var mainForm = new MainForm(
                authService,
                productService,
                stockService,
                saleService,
                receiptService,
                dashboardService,
                inventoryService,
                reportService,
                backupService
            );
            var mainResult = mainForm.ShowDialog();

            // Si l'utilisateur clique sur "Déconnexion", mainResult vaut DialogResult.Retry,
            // la boucle recommence donc pour afficher un nouveau LoginForm.
            if (mainResult != DialogResult.Retry)
            {
                break;
            }
        }
    }    
}