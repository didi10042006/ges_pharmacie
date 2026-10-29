using BCrypt.Net;

namespace GestionPharmacie.BLL.Security;

public class PasswordHasher : IPasswordHasher
{
    private const int WorkFactor = 11;

    public string HashPassword(string plainPassword)
    {
        if (string.IsNullOrEmpty(plainPassword))
        {
            throw new ArgumentException("Le mot de passe ne peut pas être vide.", nameof(plainPassword));
        }

        return BCrypt.Net.BCrypt.HashPassword(plainPassword, WorkFactor);
    }

    public bool VerifyPassword(string plainPassword, string passwordHash)
    {
        if (string.IsNullOrEmpty(plainPassword) || string.IsNullOrEmpty(passwordHash))
        {
            return false;
        }

        try
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, passwordHash);
        }
        catch
        {
            // En cas de hash malformé ou non reconnu
            return false;
        }
    }
}
