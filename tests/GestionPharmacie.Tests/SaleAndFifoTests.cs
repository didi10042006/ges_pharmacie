using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Initialization;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;
using GestionPharmacie.Models.Enums;
using Xunit;

namespace GestionPharmacie.Tests;

public class SaleAndFifoTests : IDisposable
{
    private readonly string _testDbPath;
    private readonly DbConnectionFactory _factory;
    private readonly ProductRepository _productRepo;
    private readonly SupplierRepository _supplierRepo;
    private readonly StockLotRepository _stockLotRepo;
    private readonly SaleRepository _saleRepo;
    private readonly AppSettingRepository _settingRepo;
    private readonly UserRepository _userRepo;
    private readonly AuditLogRepository _auditRepo;
    private readonly PasswordHasher _hasher;
    private readonly AuditLogService _auditService;
    private readonly SaleService _saleService;
    private readonly ReceiptService _receiptService;

    public SaleAndFifoTests()
    {
        _testDbPath = Path.Combine(Path.GetTempPath(), $"pharmacie_pos_test_{Guid.NewGuid():N}.db");
        _factory = new DbConnectionFactory(_testDbPath);

        var initializer = new DatabaseInitializer(_factory);
        initializer.Initialize();

        _productRepo = new ProductRepository(_factory);
        _supplierRepo = new SupplierRepository(_factory);
        _stockLotRepo = new StockLotRepository(_factory);
        _saleRepo = new SaleRepository(_factory);
        _settingRepo = new AppSettingRepository(_factory);
        _userRepo = new UserRepository(_factory);
        _auditRepo = new AuditLogRepository(_factory);
        _hasher = new PasswordHasher();
        _auditService = new AuditLogService(_auditRepo);

        _saleService = new SaleService(_factory, _saleRepo, _stockLotRepo, _userRepo, _hasher, _auditService);
        _receiptService = new ReceiptService(_settingRepo);

        // Connexion de session pour le test
        var adminUser = _userRepo.GetByUsernameAsync("admin").GetAwaiter().GetResult();
        if (adminUser != null)
        {
            UserSession.Instance.StartSession(adminUser);
        }
    }

    public void Dispose()
    {
        UserSession.Instance.EndSession();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        if (File.Exists(_testDbPath))
        {
            try { File.Delete(_testDbPath); } catch { /* Ignore temp cleanup */ }
        }
    }

    [Fact]
    public async Task FifoRule_ShouldPrioritizeNearExpiryLot_And_IgnoreExpiredOrBlockedLots()
    {
        // 1. Créer un produit
        var product = new Product
        {
            Reference = "MED-FIFO-01",
            Name = "Sirop Antitussif",
            SellingPrice = 5.00m
        };
        var productId = await _productRepo.CreateAsync(product);

        // 2. Créer 4 lots distincts :
        // Lot 1 : Périmé hier (NE DOIT PAS ÊTRE VENDU)
        await _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = productId,
            LotNumber = "LOT-EXPIRED",
            ExpiryDate = DateTime.Today.AddDays(-1),
            Quantity = 10,
            PurchaseCost = 2.00m,
            IsBlocked = false
        });

        // Lot 2 : Bloqué (NE DOIT PAS ÊTRE VENDU)
        await _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = productId,
            LotNumber = "LOT-BLOCKED",
            ExpiryDate = DateTime.Today.AddMonths(6),
            Quantity = 15,
            PurchaseCost = 2.00m,
            IsBlocked = true
        });

        // Lot 3 : Valide dans 3 mois (PRIORITAIRE FIFO)
        var lotNearId = await _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = productId,
            LotNumber = "LOT-NEAR",
            ExpiryDate = DateTime.Today.AddMonths(3),
            Quantity = 5,
            PurchaseCost = 2.00m,
            IsBlocked = false
        });

        // Lot 4 : Valide dans 12 mois (SECONDAIRE FIFO)
        var lotLaterId = await _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = productId,
            LotNumber = "LOT-LATER",
            ExpiryDate = DateTime.Today.AddMonths(12),
            Quantity = 10,
            PurchaseCost = 2.00m,
            IsBlocked = false
        });

        // Act 1 : Vérifier la priorité FIFO
        var nextLot = await _saleService.GetNextFifoLotForProductAsync(productId);
        Assert.NotNull(nextLot);
        Assert.Equal("LOT-NEAR", nextLot.LotNumber);

        // Act 2 : Vérifier le stock vendable total (uniquement lots 3 et 4 = 5 + 10 = 15)
        var sellableStock = await _saleService.GetTotalSellableStockAsync(productId);
        Assert.Equal(15, sellableStock);

        // Act 3 : Vendre 7 unités (doit vider Lot 3 de 5 et prendre 2 dans Lot 4)
        var cart = new List<CartItemDto>
        {
            new CartItemDto
            {
                ProductId = productId,
                ProductName = product.Name,
                ProductReference = product.Reference,
                Quantity = 7,
                UnitPrice = product.SellingPrice
            }
        };

        var saleDetail = await _saleService.ProcessSaleAsync(cart, PaymentMethod.Cash, 0m, 50m);
        Assert.NotNull(saleDetail);
        Assert.Equal(35.00m, saleDetail.TotalAmount);
        Assert.Equal(15.00m, saleDetail.ChangeGiven); // 50 - 35 = 15 rendu

        // Vérifier les quantités restantes des lots
        var lotNearUpdated = await _stockLotRepo.GetByIdAsync(lotNearId);
        var lotLaterUpdated = await _stockLotRepo.GetByIdAsync(lotLaterId);

        Assert.Equal(0, lotNearUpdated!.Quantity); // Totalement épuisé
        Assert.Equal(8, lotLaterUpdated!.Quantity); // 10 - 2 = 8
    }

    [Fact]
    public async Task ProcessSale_ShouldRollbackCompletelyOnInsufficientStock()
    {
        // 1. Produit avec 5 unités
        var product = new Product { Reference = "MED-RB-01", Name = "Collyre", SellingPrice = 4.00m };
        var productId = await _productRepo.CreateAsync(product);

        var lotId = await _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = productId,
            LotNumber = "LOT-RB-5",
            ExpiryDate = DateTime.Today.AddMonths(6),
            Quantity = 5,
            PurchaseCost = 1.50m
        });

        // 2. Tenter de vendre 10 unités (dépassement)
        var cart = new List<CartItemDto>
        {
            new CartItemDto { ProductId = productId, ProductName = product.Name, Quantity = 10, UnitPrice = product.SellingPrice }
        };

        // Assert : Doit lancer une exception
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _saleService.ProcessSaleAsync(cart, PaymentMethod.Cash, 0m, 40m)
        );

        // Vérifier que le lot n'a pas été modifié (Rollback)
        var lot = await _stockLotRepo.GetByIdAsync(lotId);
        Assert.Equal(5, lot!.Quantity);
    }

    [Fact]
    public async Task ValidateDiscountApproval_ShouldRequireAdminOrPharmacist()
    {
        // Admin valide
        var adminOk = await _saleService.ValidateDiscountApprovalAsync("admin", "admin123");
        Assert.True(adminOk);

        // Mot de passe admin erroné
        var adminBad = await _saleService.ValidateDiscountApprovalAsync("admin", "mauvais_pass");
        Assert.False(adminBad);

        // Vendeur (n'a pas les droits de responsable pour autoriser des remises)
        var vendeurBad = await _saleService.ValidateDiscountApprovalAsync("vendeur", "vendeur123");
        Assert.False(vendeurBad);
    }

    [Fact]
    public async Task ReceiptService_ShouldGenerateCompleteFormattedTicket()
    {
        var product = new Product { Reference = "MED-RCP-01", Name = "Aspirine Protect", SellingPrice = 6.00m };
        var productId = await _productRepo.CreateAsync(product);

        await _stockLotRepo.CreateAsync(new StockLot
        {
            ProductId = productId,
            LotNumber = "LOT-ASP-01",
            ExpiryDate = DateTime.Today.AddYears(1),
            Quantity = 50,
            PurchaseCost = 2.00m
        });

        var cart = new List<CartItemDto>
        {
            new CartItemDto { ProductId = productId, ProductName = product.Name, ProductReference = product.Reference, Quantity = 2, UnitPrice = 6.00m }
        };

        var saleDetail = await _saleService.ProcessSaleAsync(cart, PaymentMethod.Cash, 2.00m, 20.00m);
        var receiptText = await _receiptService.GenerateReceiptTextAsync(saleDetail);

        Assert.NotEmpty(receiptText);
        Assert.Contains(saleDetail.SaleNumber, receiptText);
        Assert.Contains("Aspirine Protect", receiptText);
        Assert.Contains("LOT-ASP-01", receiptText);
        Assert.Contains("TOTAL NET", receiptText);
        Assert.Contains("MONNAIE RENDUE", receiptText);
    }

    [Fact]
    public async Task ShiftClose_ShouldCalculateDiscrepancyAndAudit()
    {
        var date = DateTime.Today;
        var summary = await _saleService.GetShiftSummaryAsync(date);
        Assert.NotNull(summary);

        var countedCash = summary.CashSalesAmount + 10.00m; // 10 € d'excédent
        var recorded = await _saleService.RecordShiftCloseAsync(date, countedCash, "Fond de caisse contrôlé.");
        Assert.True(recorded);

        var recentLogs = (await _auditRepo.GetRecentLogsAsync(5)).ToList();
        Assert.Contains(recentLogs, l => l.Action == "SHIFT_CLOSED");
    }
}
