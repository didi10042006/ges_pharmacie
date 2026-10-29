using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<Product?> GetByReferenceAsync(string reference);
    Task<IEnumerable<ProductListItemDto>> GetProductsListAsync(string? searchTerm = null, string? category = null, bool includeArchived = false);
    Task<IEnumerable<string>> GetCategoriesAsync();
    Task<int> CreateAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> SetArchiveStatusAsync(int id, bool isArchived);
    Task<bool> HasTransactionsHistoryAsync(int id);
    Task<bool> DeleteAsync(int id);
}
