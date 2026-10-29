using Dapper;
using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Initialization;
using GestionPharmacie.DAL.Repositories;
using Xunit;

namespace GestionPharmacie.Tests;

public class DatabaseInitializerTests : IDisposable
{
    private readonly string _testDbPath;
    private readonly DbConnectionFactory _factory;

    public DatabaseInitializerTests()
    {
        _testDbPath = Path.Combine(Path.GetTempPath(), $"pharmacie_test_{Guid.NewGuid():N}.db");
        _factory = new DbConnectionFactory(_testDbPath);
    }

    public void Dispose()
    {
        // Give SQLite a moment to release handles if any
        GC.Collect();
        GC.WaitForPendingFinalizers();

        if (File.Exists(_testDbPath))
        {
            try { File.Delete(_testDbPath); } catch { /* Ignore temp cleanup issues */ }
        }
    }

    [Fact]
    public void Initialize_ShouldCreateTablesAndIndexesSuccessfully()
    {
        // Arrange
        var initializer = new DatabaseInitializer(_factory);

        // Act
        initializer.Initialize();

        // Assert
        using var conn = _factory.CreateConnection();
        var tableCount = conn.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';"
        );

        // We expect at least 9 tables: Users, Products, Suppliers, StockLots, Sales, SaleItems, StockAdjustments, AuditLogs, AppSettings
        Assert.True(tableCount >= 9, $"Expected at least 9 tables, found {tableCount}");
    }

    [Fact]
    public async Task Initialize_ShouldSeedDefaultAdminAndVerifyCredentials()
    {
        // Arrange
        var initializer = new DatabaseInitializer(_factory);
        initializer.Initialize();

        var userRepo = new UserRepository(_factory);
        var auditRepo = new AuditLogRepository(_factory);
        var hasher = new PasswordHasher();
        var auditService = new AuditLogService(auditRepo);
        var authService = new AuthService(userRepo, hasher, auditService);

        // Act
        var adminUser = await userRepo.GetByUsernameAsync("admin");
        var loginResult = await authService.LoginAsync("admin", "admin123");
        var badLoginResult = await authService.LoginAsync("admin", "wrongpassword");

        // Assert
        Assert.NotNull(adminUser);
        Assert.Equal("admin", adminUser.Username);
        Assert.Equal("Admin", adminUser.Role);
        Assert.True(adminUser.IsActive);

        Assert.NotNull(loginResult);
        Assert.Equal("admin", loginResult.Username);

        Assert.Null(badLoginResult);
    }

    [Fact]
    public void Initialize_ShouldSeedAppSettings()
    {
        // Arrange
        var initializer = new DatabaseInitializer(_factory);
        initializer.Initialize();

        // Act
        using var conn = _factory.CreateConnection();
        var pharmacyName = conn.ExecuteScalar<string>("SELECT Value FROM AppSettings WHERE Key = 'Pharmacy_Name';");
        var taxRate = conn.ExecuteScalar<string>("SELECT Value FROM AppSettings WHERE Key = 'Pharmacy_TaxRate';");

        // Assert
        Assert.Equal("Pharmacie Centrale", pharmacyName);
        Assert.Equal("0.20", taxRate);
    }
}
