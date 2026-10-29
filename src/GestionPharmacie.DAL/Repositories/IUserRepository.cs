using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
    Task<IEnumerable<User>> GetAllAsync();
    Task<int> CreateAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> UpdatePasswordAsync(int userId, string newPasswordHash);
    Task<bool> SetActiveStatusAsync(int userId, bool isActive);
}
