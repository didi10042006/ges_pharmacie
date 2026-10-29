using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.Models.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = UserRole.Pharmacist.ToString();
    public bool IsActive { get; set; } = true;

    // Helper for strongly-typed role access
    public UserRole UserRole
    {
        get => Enum.TryParse<UserRole>(Role, true, out var parsedRole) ? parsedRole : UserRole.Cashier;
        set => Role = value.ToString();
    }
}
