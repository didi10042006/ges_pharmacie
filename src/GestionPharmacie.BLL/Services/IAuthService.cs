using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public interface IAuthService
{
    Task<User?> LoginAsync(string username, string password);
    void Logout();
    Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    Task<int> CreateUserAsync(string username, string password, string role);
}
