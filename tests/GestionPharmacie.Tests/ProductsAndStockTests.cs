using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Initialization;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.Entities;
using Xunit;

namespace GestionPharmacie.Tests;

public class ProductsAndStockTests : IDisposable
{
    private readonly string _testDbPath;
    private readonly DbConnectionFactory _factory;
    private readonly ProductRepository _productRepo;
    private readonly SupplierRepository _supplierRepo;
    private readonly StockLotRepository _stockLotRepo;
    private readonly AuditLogRepository _auditRepo;
    private readonly AuditLogService _auditService;
    private readonly ProductService _productService;
    private readonly StockService _stockService;

    public ProductsAndStockTests()
    {
        _testDbPath = Path.Combine(Path.GetTempPath(), $"pharmacie_prod_test_{Guid.NewGuid():N}.db");
        _factory = new DbConnectionFactory(_testDbPath);

        var initializer = new DatabaseInitializer(_factory);
        initializer.Initialize();

        _productRepo = new ProductRepository(_factory);
        _supplierRepo = new SupplierRepository(_factory);
        _stockLotRepo = new StockLotRepository(_factory);
        _auditRepo = new AuditLogRepository(_factory);
        _auditService = new AuditLogService(_auditRepo);
        _productService = new ProductService(_productRepo, _auditService);
        _stockService = new StockService(_factory, _stockLotRepo, _supplierRepo, _auditService);
    }

    public void Dispose()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();

        if (File.Exists(_testDbPath))
        {
            try { File.Delete(_testDbPath); } catch { /* Ignore temp cleanup */ }
        }
    }

    [Fact]
    public async Task CreateProduct_And_CheckUniqueReference()
    {
        var product = new Product
        {
            Reference = "TEST-REF-01",
            Name = "Médicament Test Unitaire",
            Category = "Test",
            SellingPrice = 12.50m,
            MinStockThreshold = 4
        };

        var id = await _productService.SaveProductAsync(product);
        Assert.True(id > 0);

        // Tentative d'insertion d'un doublon de référence
        var duplicate = new Product
        {
            Reference = "test-ref-01", // casse différente
            Name = "Autre médicament",
            SellingPrice = 5.00m
        };

        await Assert.ThrowsAsync<InvalidOperationException>(() => _productService.SaveProductAsync(duplicate));
    }

    [Fact]
    public async Task DeleteOrArchive_ShouldArchiveWhenTransactionsHistoryExists()
    {
        // 1. Créer un produit
        var product = new Product
        {
            Reference = "MED-HIST-01",
            Name = "Produit avec Historique",
            SellingPrice = 9.90m
        };
        var productId = await _productService.SaveProductAsync(product);

        // 2. Créer un lot rattaché
        var lot = new StockLot
        {
            ProductId = productId,
            LotNumber = "LOT-H1",
            ExpiryDate = DateTime.Today.AddYears(1),
            Quantity = 20,
            PurchaseCost = 5.00m
        };
        await _stockLotRepo.CreateAsync(lot);

        // 3. Tenter de supprimer le produit
        var (success, wasArchived, message) = await _productService.DeleteOrArchiveProductAsync(productId);

        // Assert : Doit être archivé et non supprimé
        Assert.True(success);
        Assert.True(wasArchived, "Le produit avec historique doit être archivé au lieu d'être supprimé.");

        var reloadedProduct = await _productService.GetByIdAsync(productId);
        Assert.NotNull(reloadedProduct);
        Assert.True(reloadedProduct.IsArchived);
    }

    [Fact]
    public async Task DeleteOrArchive_ShouldPhysicallyDeleteWhenNoHistory()
    {
        // 1. Créer un produit sans aucun lot
        var product = new Product
        {
            Reference = "MED-NOHIST-01",
            Name = "Produit Sans Historique",
            SellingPrice = 4.50m
        };
        var productId = await _productService.SaveProductAsync(product);

        // 2. Supprimer
        var (success, wasArchived, message) = await _productService.DeleteOrArchiveProductAsync(productId);

        // Assert
        Assert.True(success);
        Assert.False(wasArchived, "Le produit sans historique doit être supprimé physiquement.");

        var reloaded = await _productService.GetByIdAsync(productId);
        Assert.Null(reloaded);
    }

    [Fact]
    public async Task ReceiveStockBatch_ShouldInsertLotsAtomicallyAndIncrementStock()
    {
        // 1. Récupérer un produit de démo
        var products = (await _productService.GetProductsAsync()).ToList();
        Assert.NotEmpty(products);
        var targetProduct = products.First();

        var initialStock = targetProduct.CurrentStock;

        // 2. Créer 2 lots pour ce produit
        var lots = new List<StockLot>
        {
            new StockLot
            {
                ProductId = targetProduct.Id,
                LotNumber = "LOT-ATOM-01",
                ExpiryDate = DateTime.Today.AddMonths(18),
                Quantity = 50,
                PurchaseCost = 1.20m
            },
            new StockLot
            {
                ProductId = targetProduct.Id,
                LotNumber = "LOT-ATOM-02",
                ExpiryDate = DateTime.Today.AddMonths(24),
                Quantity = 30,
                PurchaseCost = 1.30m
            }
        };

        // 3. Réception atomique
        var result = await _stockService.ReceiveStockBatchAsync(1, "BL-TEST-999", lots);
        Assert.True(result);

        // 4. Vérifier l'incrémentation du stock vendable
        var updatedProducts = (await _productService.GetProductsAsync()).ToList();
        var reloadedProduct = updatedProducts.First(p => p.Id == targetProduct.Id);

        Assert.Equal(initialStock + 80, reloadedProduct.CurrentStock);
    }
}
