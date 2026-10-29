using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Initialization;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;
using GestionPharmacie.Models.Enums;
using Microsoft.Data.Sqlite;
using Xunit;

namespace GestionPharmacie.Tests;

public class DashboardAndReportTests : IDisposable
{
    private readonly string _testDbPath;
    private readonly DbConnectionFactory _factory;
    private readonly InventoryRepository _inventoryRepo;
    private readonly ReportRepository _reportRepo;
    private readonly ProductRepository _productRepo;
    private readonly SupplierRepository _supplierRepo;
    private readonly StockLotRepository _stockLotRepo;
    private readonly SaleRepository _saleRepo;
    private readonly UserRepository _userRepo;
    private readonly AuditLogRepository _auditRepo;
    private readonly PasswordHasher _hasher;
    private readonly AuditLogService _auditService;
    private readonly DashboardService _dashboardService;
    private readonly InventoryService _inventoryService;
    private readonly ReportService _reportService;
    private readonly BackupService _backupService;
    private readonly SaleService _saleService;

    public DashboardAndReportTests()
    {
        _testDbPath = Path.Combine(Path.GetTempPath(), $"pharmacie_report_test_{Guid.NewGuid():N}.db");
        _factory = new DbConnectionFactory(_testDbPath);

        var initializer = new DatabaseInitializer(_factory);
        initializer.Initialize();

        _inventoryRepo = new InventoryRepository(_factory);
        _reportRepo = new ReportRepository(_factory);
        _productRepo = new ProductRepository(_factory);
        _supplierRepo = new SupplierRepository(_factory);
        _stockLotRepo = new StockLotRepository(_factory);
        _saleRepo = new SaleRepository(_factory);
        _userRepo = new UserRepository(_factory);
        _auditRepo = new AuditLogRepository(_factory);
        _hasher = new PasswordHasher();
        _auditService = new AuditLogService(_auditRepo);

        _dashboardService = new DashboardService(_reportRepo);
        _inventoryService = new InventoryService(_inventoryRepo, _auditService);
        _reportService = new ReportService(_reportRepo);
        _backupService = new BackupService(_factory, _auditService);
        _saleService = new SaleService(_factory, _saleRepo, _stockLotRepo, _userRepo, _hasher, _auditService);

        // Connexion Admin par défaut pour les tests
        var admin = _userRepo.GetByUsernameAsync("admin").GetAwaiter().GetResult();
        if (admin != null)
        {
            UserSession.Instance.StartSession(admin);
        }

        // Création de lots de test initiaux
        _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = 1,
            SupplierId = 1,
            LotNumber = "LOT-DASH-01",
            ExpiryDate = DateTime.Today.AddMonths(6),
            Quantity = 30,
            PurchaseCost = 1.10m,
            IsBlocked = false
        }).GetAwaiter().GetResult();

        _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = 2,
            SupplierId = 2,
            LotNumber = "LOT-DASH-02",
            ExpiryDate = DateTime.Today.AddDays(45), // Proche péremption (< 90j)
            Quantity = 15,
            PurchaseCost = 2.00m,
            IsBlocked = false
        }).GetAwaiter().GetResult();

        _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = 3,
            SupplierId = 1,
            LotNumber = "LOT-DASH-03",
            ExpiryDate = DateTime.Today.AddMonths(18),
            Quantity = 25,
            PurchaseCost = 2.50m,
            IsBlocked = false
        }).GetAwaiter().GetResult();
    }

    public void Dispose()
    {
        UserSession.Instance.EndSession();
        SqliteConnection.ClearAllPools();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        if (File.Exists(_testDbPath))
        {
            try { File.Delete(_testDbPath); } catch { }
        }

        var wal = _testDbPath + "-wal";
        var shm = _testDbPath + "-shm";
        if (File.Exists(wal)) { try { File.Delete(wal); } catch { } }
        if (File.Exists(shm)) { try { File.Delete(shm); } catch { } }

        // Nettoyage dossier de backup créé pour le test
        if (Directory.Exists(_backupService.DefaultBackupFolder))
        {
            try
            {
                foreach (var file in Directory.GetFiles(_backupService.DefaultBackupFolder, "*.db"))
                {
                    try { File.Delete(file); } catch { }
                }
            }
            catch { }
        }
    }

    [Fact]
    public async Task DashboardMetrics_ShouldComputeCorrectKPIs()
    {
        // Act
        var metrics = await _dashboardService.GetMetricsAsync();

        // Assert
        Assert.NotNull(metrics);
        Assert.True(metrics.OutOfStockCount >= 0);
        Assert.True(metrics.LowStockCount >= 0);
        Assert.NotNull(metrics.StockAlerts);
        Assert.NotNull(metrics.ExpiryAlerts);
    }

    [Fact]
    public async Task InventoryAdjustment_WithMandatoryReason_ShouldAdjustStockAndLogAudit()
    {
        // Arrange
        var lots = (await _inventoryService.GetInventoryLotsAsync()).ToList();
        Assert.NotEmpty(lots);
        var targetLot = lots.First(l => l.TheoreticalQuantity > 5);

        int originalQty = targetLot.TheoreticalQuantity;
        int countedQty = originalQty - 2; // Écart de -2 unités
        string reason = "Casse accidentelle d'un flacon en rayon";

        // Act
        bool adjusted = await _inventoryService.AdjustLotStockAsync(targetLot.LotId, countedQty, reason);

        // Assert
        Assert.True(adjusted);

        var updatedLots = (await _inventoryService.GetInventoryLotsAsync()).ToList();
        var updatedLot = updatedLots.First(l => l.LotId == targetLot.LotId);
        Assert.Equal(countedQty, updatedLot.TheoreticalQuantity);

        // Vérification de la trace d'audit
        var auditLogs = await _auditRepo.GetRecentLogsAsync(10);
        Assert.Contains(auditLogs, a => a.Action == "STOCK_ADJUSTMENT" && a.Details != null && a.Details.Contains(reason));
    }

    [Fact]
    public async Task InventoryAdjustment_WithoutReason_ShouldThrowArgumentException()
    {
        // Arrange
        var lots = (await _inventoryService.GetInventoryLotsAsync()).ToList();
        Assert.NotEmpty(lots);
        var targetLot = lots.First();

        // Act & Assert : Motif obligatoire non renseigné
        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await _inventoryService.AdjustLotStockAsync(targetLot.LotId, targetLot.TheoreticalQuantity + 1, "   ");
        });
    }

    [Fact]
    public async Task ToggleBlockLot_AdminCanBlockAndUnblockLot()
    {
        // Arrange
        var lots = (await _inventoryService.GetInventoryLotsAsync()).ToList();
        Assert.NotEmpty(lots);
        var targetLot = lots.First();
        bool initialStatus = targetLot.IsBlocked;

        // Act : Bloquer le lot
        bool blocked = await _inventoryService.ToggleBlockLotAsync(targetLot.LotId, !initialStatus);
        Assert.True(blocked);

        var refreshed = (await _inventoryService.GetInventoryLotsAsync()).First(l => l.LotId == targetLot.LotId);
        Assert.Equal(!initialStatus, refreshed.IsBlocked);

        // Act : Débloquer le lot
        bool unblocked = await _inventoryService.ToggleBlockLotAsync(targetLot.LotId, initialStatus);
        Assert.True(unblocked);

        var restored = (await _inventoryService.GetInventoryLotsAsync()).First(l => l.LotId == targetLot.LotId);
        Assert.Equal(initialStatus, restored.IsBlocked);
    }

    [Fact]
    public async Task SalesReport_ShouldCalculateAccurateGrossMarginAndRates()
    {
        // Arrange : Réalisons une vente contrôlée pour vérifier la marge brute
        var products = (await _productRepo.GetProductsListAsync()).ToList();
        Assert.NotEmpty(products);
        var product = products.First();

        var cart = new List<CartItemDto>
        {
            new CartItemDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductReference = product.Reference,
                Quantity = 2,
                UnitPrice = product.SellingPrice
            }
        };

        decimal expectedTotal = product.SellingPrice * 2;
        var saleDetail = await _saleService.ProcessSaleAsync(cart, PaymentMethod.Cash, 0.00m, expectedTotal + 10m);
        Assert.NotNull(saleDetail);

        // Act : Récupération du rapport sur aujourd'hui
        var startDate = DateTime.Today;
        var endDate = DateTime.Today.AddDays(1).AddTicks(-1);
        var report = await _reportService.GetSalesReportAsync(startDate, endDate);

        // Assert
        Assert.NotNull(report);
        Assert.True(report.TotalSalesCount >= 1);
        Assert.True(report.TotalNetAmount >= expectedTotal);
        Assert.True(report.TotalPurchaseCost > 0);
        // Marge brute = Net - Coût d'achat
        Assert.Equal(report.TotalNetAmount - report.TotalPurchaseCost, report.TotalGrossMargin);
        Assert.True(report.MarginRatePercentage > 0);

        // Vérification du produit vendu dans le tableau
        var productMargin = report.ProductSales.FirstOrDefault(p => p.ProductReference == product.Reference);
        Assert.NotNull(productMargin);
        Assert.Equal(productMargin.TotalRevenue - productMargin.TotalCost, productMargin.GrossMargin);
    }

    [Fact]
    public async Task CsvExport_ShouldGenerateValidCsvFiles()
    {
        // Arrange
        var lots = await _inventoryService.GetInventoryLotsAsync();
        var report = await _reportService.GetSalesReportAsync(DateTime.Today.AddDays(-30), DateTime.Today.AddDays(1));

        // Act
        string inventoryCsv = _reportService.ExportInventoryToCsv(lots);
        string reportCsv = _reportService.ExportSalesReportToCsv(report);

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(inventoryCsv));
        Assert.Contains("Référence;Désignation;Catégorie;N° de Lot;Péremption;Quantité en Stock;Coût Achat (€);Prix Vente (€);Statut", inventoryCsv);

        Assert.False(string.IsNullOrWhiteSpace(reportCsv));
        Assert.Contains("Marge Brute Indicative", reportCsv);
        Assert.Contains("Taux de Marge Brute", reportCsv);
        Assert.Contains("Référence;Désignation;Quantité Vendue;Chiffre d'Affaires (€);Coût d'Achat (€);Marge Brute (€);Taux de Marge (%)", reportCsv);
    }

    [Fact]
    public async Task BackupService_VacuumInto_ShouldCreateValidBackup()
    {
        // Act
        string backupFilePath = await _backupService.CreateBackupAsync();

        // Assert
        Assert.True(File.Exists(backupFilePath));
        var fileInfo = new FileInfo(backupFilePath);
        Assert.True(fileInfo.Length > 0);

        // Vérification de la liste des backups
        var existing = _backupService.GetExistingBackups();
        Assert.Contains(existing, f => f.FullName == backupFilePath);

        // Vérification de la trace d'audit
        var auditLogs = await _auditRepo.GetRecentLogsAsync(10);
        Assert.Contains(auditLogs, a => a.Action == "BACKUP_CREATED");
    }
}
