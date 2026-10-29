using GestionPharmacie.BLL.Security;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IAuditLogService _auditLogService;

    public ProductService(IProductRepository productRepository, IAuditLogService auditLogService)
    {
        _productRepository = productRepository;
        _auditLogService = auditLogService;
    }

    public async Task<IEnumerable<ProductListItemDto>> GetProductsAsync(
        string? searchTerm = null, 
        string? category = null, 
        bool includeArchived = false)
    {
        return await _productRepository.GetProductsListAsync(searchTerm, category, includeArchived);
    }

    public async Task<IEnumerable<string>> GetCategoriesAsync()
    {
        return await _productRepository.GetCategoriesAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<int> SaveProductAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (string.IsNullOrWhiteSpace(product.Reference))
            throw new ArgumentException("La référence du médicament est obligatoire.");

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Le nom du médicament est obligatoire.");

        if (product.SellingPrice < 0)
            throw new ArgumentException("Le prix de vente ne peut pas être négatif.");

        if (product.MinStockThreshold < 0)
            throw new ArgumentException("Le seuil minimum de stock ne peut pas être négatif.");

        // Vérification de l'unicité de la référence
        var existingWithRef = await _productRepository.GetByReferenceAsync(product.Reference);
        if (existingWithRef != null && existingWithRef.Id != product.Id)
        {
            throw new InvalidOperationException($"La référence '{product.Reference}' est déjà attribuée au produit '{existingWithRef.Name}'.");
        }

        if (product.Id == 0)
        {
            var id = await _productRepository.CreateAsync(product);
            await _auditLogService.LogCurrentSessionActionAsync(
                "PRODUCT_CREATED",
                $"Nouveau produit ajouté : [{product.Reference}] {product.Name} (Prix: {product.SellingPrice:C2})"
            );
            return id;
        }
        else
        {
            await _productRepository.UpdateAsync(product);
            await _auditLogService.LogCurrentSessionActionAsync(
                "PRODUCT_UPDATED",
                $"Mise à jour du produit #{product.Id} : [{product.Reference}] {product.Name} (Prix: {product.SellingPrice:C2})"
            );
            return product.Id;
        }
    }

    public async Task<(bool Success, bool WasArchived, string Message)> DeleteOrArchiveProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return (false, false, "Produit introuvable.");

        // Règle métier : Vérifier si le produit a un historique
        var hasHistory = await _productRepository.HasTransactionsHistoryAsync(id);

        if (hasHistory)
        {
            // Archivage obligatoire pour préserver l'intégrité de la traçabilité
            await _productRepository.SetArchiveStatusAsync(id, true);
            await _auditLogService.LogCurrentSessionActionAsync(
                "PRODUCT_ARCHIVED",
                $"Produit archivé car lié à un historique de stocks/ventes : [{product.Reference}] {product.Name}"
            );
            return (true, true, $"Le produit '{product.Name}' possède un historique de lots/mouvements. Il a été archivé pour préserver l'intégrité comptable.");
        }
        else
        {
            // Suppression physique autorisée
            var deleted = await _productRepository.DeleteAsync(id);
            if (deleted)
            {
                await _auditLogService.LogCurrentSessionActionAsync(
                    "PRODUCT_DELETED",
                    $"Produit sans historique supprimé définitivement : [{product.Reference}] {product.Name}"
                );
            }
            return (deleted, false, $"Le produit '{product.Name}' a été supprimé avec succès.");
        }
    }

    public async Task<bool> ToggleArchiveAsync(int id, bool archive)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return false;

        var success = await _productRepository.SetArchiveStatusAsync(id, archive);
        if (success)
        {
            var action = archive ? "PRODUCT_ARCHIVED" : "PRODUCT_RESTORED";
            var details = archive 
                ? $"Produit archivé : [{product.Reference}] {product.Name}" 
                : $"Produit restauré : [{product.Reference}] {product.Name}";
            await _auditLogService.LogCurrentSessionActionAsync(action, details);
        }
        return success;
    }
}
