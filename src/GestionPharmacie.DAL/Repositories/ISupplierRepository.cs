using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public interface ISupplierRepository
{
    Task<Supplier?> GetByIdAsync(int id);
    Task<IEnumerable<Supplier>> GetAllActiveAsync();
    Task<IEnumerable<Supplier>> GetAllAsync();
    Task<int> CreateAsync(Supplier supplier);
}
