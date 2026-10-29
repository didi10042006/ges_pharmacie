using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public interface IProductService
{
    Task<IEnumerable<ProductListItemDto>> GetProductsAsync(string? searchTerm = null, string? category = null, bool includeArchived = false);
    Task<IEnumerable<string>> GetCategoriesAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<int> SaveProductAsync(Product product);
    Task<(bool Success, bool WasArchived, string Message)> DeleteOrArchiveProductAsync(int id);
    Task<bool> ToggleArchiveAsync(int id, bool archive);
}
