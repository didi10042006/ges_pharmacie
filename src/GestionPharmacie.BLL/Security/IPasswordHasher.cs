namespace GestionPharmacie.BLL.Security;

public interface IPasswordHasher
{
    string HashPassword(string plainPassword);
    bool VerifyPassword(string plainPassword, string passwordHash);
}
