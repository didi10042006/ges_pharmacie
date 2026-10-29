namespace GestionPharmacie.Models.Enums;

public enum Permission
{
    // Ventes et caisse
    PerformSales,
    CancelSales,
    ViewSalesHistory,

    // Consultation produits
    ViewProducts,

    // Stocks et achats (réservé Admin / Pharmacien)
    ViewPurchaseCosts,
    ManageProducts,
    ManageStock,
    PerformStockAdjustment,

    // Administration et configuration (réservé Admin)
    ManageSuppliers,
    ManageUsers,
    ManageSettings,
    ViewAuditLogs
}
