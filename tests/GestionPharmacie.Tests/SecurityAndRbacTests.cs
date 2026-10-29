using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.DAL.Initialization;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.Entities;
using GestionPharmacie.Models.Enums;
using Xunit;

namespace GestionPharmacie.Tests;

public class SecurityAndRbacTests : IDisposable
{
    private readonly string _testDbPath;
    private readonly DbConnectionFactory _factory;
    private readonly UserRepository _userRepo;
    private readonly AuditLogRepository _auditRepo;
    private readonly PasswordHasher _hasher;
    private readonly AuditLogService _auditService;
    private readonly AuthService _authService;

    public SecurityAndRbacTests()
    {
        _testDbPath = Path.Combine(Path.GetTempPath(), $"pharmacie_sec_test_{Guid.NewGuid():N}.db");
        _factory = new DbConnectionFactory(_testDbPath);

        var initializer = new DatabaseInitializer(_factory);
        initializer.Initialize();

        _userRepo = new UserRepository(_factory);
        _auditRepo = new AuditLogRepository(_factory);
        _hasher = new PasswordHasher();
        _auditService = new AuditLogService(_auditRepo);
        _authService = new AuthService(_userRepo, _hasher, _auditService);

        // Reset session before each test
        UserSession.Instance.EndSession();
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
    public void PasswordHasher_ShouldHashAndVerifyCorrectly()
    {
        var password = "SecurePassword!123";
        var hash = _hasher.HashPassword(password);

        Assert.NotEmpty(hash);
        Assert.NotEqual(password, hash);
        Assert.True(_hasher.VerifyPassword(password, hash));
        Assert.False(_hasher.VerifyPassword("WrongPassword", hash));
    }

    [Fact]
    public void UserSession_Vendeur_ShouldHaveStrictlyRestrictedAccess()
    {
        // Arrange
        var vendeurUser = new User
        {
            Id = 2,
            Username = "vendeur1",
            Role = UserRole.Vendeur.ToString(),
            IsActive = true
        };

        // Act
        UserSession.Instance.StartSession(vendeurUser);

        // Assert : RBAC requirements
        Assert.True(UserSession.Instance.IsAuthenticated);
        Assert.True(UserSession.Instance.IsVendeur);
        Assert.False(UserSession.Instance.IsAdmin);

        // Exigence spécifique du cahier des charges :
        // "Un utilisateur 'Vendeur' ne doit pas avoir accès aux coûts d'achat, aux paramètres ni à la modification des stocks."
        Assert.False(UserSession.Instance.CanViewPurchaseCosts, "Le vendeur ne doit PAS voir les coûts d'achat.");
        Assert.False(UserSession.Instance.CanManageStock, "Le vendeur ne doit PAS modifier les stocks.");
        Assert.False(UserSession.Instance.CanManageSettings, "Le vendeur ne doit PAS accéder aux paramètres.");
        Assert.False(UserSession.Instance.CanManageUsers, "Le vendeur ne doit PAS gérer les utilisateurs.");

        // Par contre, le vendeur peut effectuer des ventes et consulter les produits au comptoir
        Assert.True(UserSession.Instance.CanPerformSales, "Le vendeur doit pouvoir effectuer des ventes.");
        Assert.True(UserSession.Instance.HasPermission(Permission.ViewProducts), "Le vendeur doit pouvoir voir les produits.");
    }

    [Fact]
    public void UserSession_Admin_ShouldHaveFullAccess()
    {
        // Arrange
        var adminUser = new User
        {
            Id = 1,
            Username = "admin",
            Role = UserRole.Admin.ToString(),
            IsActive = true
        };

        // Act
        UserSession.Instance.StartSession(adminUser);

        // Assert
        Assert.True(UserSession.Instance.IsAdmin);
        Assert.True(UserSession.Instance.CanViewPurchaseCosts);
        Assert.True(UserSession.Instance.CanManageStock);
        Assert.True(UserSession.Instance.CanManageSettings);
        Assert.True(UserSession.Instance.CanManageUsers);
        Assert.True(UserSession.Instance.CanViewAuditLogs);
        Assert.True(UserSession.Instance.CanPerformSales);
    }

    [Fact]
    public async Task AuthService_Login_ShouldCreateAuditLog()
    {
        // Act - Connexion valide
        var user = await _authService.LoginAsync("admin", "admin123");
        Assert.NotNull(user);

        // Act - Tentative erronée
        var badUser = await _authService.LoginAsync("admin", "wrong_pass");
        Assert.Null(badUser);

        // Assert Audit Logs
        var logs = (await _auditRepo.GetRecentLogsAsync(10)).ToList();
        Assert.Contains(logs, l => l.Action == "AUTH_LOGIN_SUCCESS");
        Assert.Contains(logs, l => l.Action == "AUTH_LOGIN_FAILED");
    }
}
