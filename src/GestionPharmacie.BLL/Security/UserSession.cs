using GestionPharmacie.Models.Entities;
using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.BLL.Security;

/// <summary>
/// Singleton gérant la session de l'utilisateur actuellement connecté et le contrôle d'accès (RBAC).
/// </summary>
public sealed class UserSession
{
    private static readonly Lazy<UserSession> _lazyInstance = new(() => new UserSession());
    private readonly object _lock = new();

    public static UserSession Instance => _lazyInstance.Value;

    public User? CurrentUser { get; private set; }
    public DateTime? LoginTime { get; private set; }

    public bool IsAuthenticated => CurrentUser != null;

    public int? UserId => CurrentUser?.Id;
    public string Username => CurrentUser?.Username ?? string.Empty;
    public string Role => CurrentUser?.Role ?? string.Empty;

    public event Action? SessionChanged;

    private UserSession()
    {
    }

    /// <summary>
    /// Initialise la session avec l'utilisateur authentifié.
    /// </summary>
    public void StartSession(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        lock (_lock)
        {
            CurrentUser = user;
            LoginTime = DateTime.Now;
        }

        SessionChanged?.Invoke();
    }

    /// <summary>
    /// Termine la session courante (Déconnexion).
    /// </summary>
    public void EndSession()
    {
        lock (_lock)
        {
            CurrentUser = null;
            LoginTime = null;
        }

        SessionChanged?.Invoke();
    }

    // =========================================================================
    // Contrôle d'accès basé sur les rôles (RBAC)
    // =========================================================================

    public bool IsAdmin =>
        IsAuthenticated && string.Equals(CurrentUser?.Role, UserRole.Admin.ToString(), StringComparison.OrdinalIgnoreCase);

    public bool IsVendeur =>
        IsAuthenticated && string.Equals(CurrentUser?.Role, UserRole.Vendeur.ToString(), StringComparison.OrdinalIgnoreCase);

    public bool IsPharmacist =>
        IsAuthenticated && (string.Equals(CurrentUser?.Role, UserRole.Pharmacist.ToString(), StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(CurrentUser?.Role, "Pharmacien", StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Règles d'accès strictes :
    /// - Le 'Vendeur' n'a pas accès aux coûts d'achat.
    /// </summary>
    public bool CanViewPurchaseCosts => IsAdmin || IsPharmacist;

    /// <summary>
    /// Consultation des rapports financiers et analyse des marges (réservé Admin).
    /// </summary>
    public bool CanViewFinancials => IsAdmin;

    /// <summary>
    /// - Le 'Vendeur' ne peut pas modifier les stocks (réservé Admin / Pharmacien).
    /// </summary>
    public bool CanManageStock => IsAdmin || IsPharmacist;

    public bool CanModifyStock => CanManageStock;

    /// <summary>
    /// - Le 'Vendeur' ne peut pas accéder aux paramètres (réservé Admin).
    /// </summary>
    public bool CanManageSettings => IsAdmin;

    /// <summary>
    /// Gestion des comptes utilisateurs (réservé Admin).
    /// </summary>
    public bool CanManageUsers => IsAdmin;

    /// <summary>
    /// Consultation des logs d'audit (réservé Admin).
    /// </summary>
    public bool CanViewAuditLogs => IsAdmin;

    /// <summary>
    /// Effectuer une vente au comptoir (Vendeur, Pharmacien, Admin).
    /// </summary>
    public bool CanPerformSales => IsAuthenticated;

    /// <summary>
    /// Annuler ou rembourser une vente validée.
    /// </summary>
    public bool CanCancelSales => IsAdmin || IsPharmacist;

    /// <summary>
    /// Vérifie si l'utilisateur actif possède une permission donnée.
    /// </summary>
    public bool HasPermission(Permission permission)
    {
        if (!IsAuthenticated)
            return false;

        return permission switch
        {
            Permission.PerformSales => CanPerformSales,
            Permission.CancelSales => CanCancelSales,
            Permission.ViewSalesHistory => IsAuthenticated,
            Permission.ViewProducts => IsAuthenticated,
            Permission.ViewPurchaseCosts => CanViewPurchaseCosts,
            Permission.ManageProducts => CanManageStock,
            Permission.ManageStock => CanManageStock,
            Permission.PerformStockAdjustment => CanManageStock,
            Permission.ManageSuppliers => IsAdmin || IsPharmacist,
            Permission.ManageUsers => CanManageUsers,
            Permission.ManageSettings => CanManageSettings,
            Permission.ViewAuditLogs => CanViewAuditLogs,
            _ => false
        };
    }
}
