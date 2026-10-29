using GestionPharmacie.BLL.Security;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAuditLogService _auditLogService;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IAuditLogService auditLogService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _auditLogService = auditLogService;
    }

    public async Task<User?> LoginAsync(string username, string password)
    {
        var trimmedUsername = username?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(trimmedUsername) || string.IsNullOrWhiteSpace(password))
        {
            await _auditLogService.LogActionAsync(
                null,
                "AUTH_LOGIN_FAILED",
                "Tentative de connexion avec identifiant ou mot de passe vide."
            );
            return null;
        }

        var user = await _userRepository.GetByUsernameAsync(trimmedUsername);
        if (user == null)
        {
            await _auditLogService.LogActionAsync(
                null,
                "AUTH_LOGIN_FAILED",
                $"Tentative de connexion avec un identifiant inexistant : '{trimmedUsername}'."
            );
            return null;
        }

        if (!user.IsActive)
        {
            await _auditLogService.LogActionAsync(
                user.Id,
                "AUTH_LOGIN_FAILED",
                $"Tentative de connexion sur un compte désactivé : '{user.Username}'."
            );
            return null;
        }

        bool isPasswordValid = _passwordHasher.VerifyPassword(password, user.PasswordHash);
        if (!isPasswordValid)
        {
            await _auditLogService.LogActionAsync(
                user.Id,
                "AUTH_LOGIN_FAILED",
                $"Mot de passe erroné pour l'utilisateur '{user.Username}'."
            );
            return null;
        }

        // Connexion réussie : démarrage de la session globale
        UserSession.Instance.StartSession(user);

        await _auditLogService.LogActionAsync(
            user.Id,
            "AUTH_LOGIN_SUCCESS",
            $"Connexion réussie de l'utilisateur '{user.Username}' (Rôle: {user.Role})."
        );

        return user;
    }

    public void Logout()
    {
        var currentUser = UserSession.Instance.CurrentUser;
        if (currentUser != null)
        {
            _auditLogService.LogAction(
                currentUser.Id,
                "AUTH_LOGOUT",
                $"Déconnexion de l'utilisateur '{currentUser.Username}'."
            );
        }

        UserSession.Instance.EndSession();
    }

    public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            return false;

        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            return false;

        if (!_passwordHasher.VerifyPassword(currentPassword, user.PasswordHash))
        {
            await _auditLogService.LogActionAsync(
                userId,
                "AUTH_PASSWORD_CHANGE_FAILED",
                "Échec de changement de mot de passe : mot de passe actuel invalide."
            );
            return false;
        }

        var newHash = _passwordHasher.HashPassword(newPassword);
        var success = await _userRepository.UpdatePasswordAsync(userId, newHash);

        if (success)
        {
            await _auditLogService.LogActionAsync(
                userId,
                "AUTH_PASSWORD_CHANGE_SUCCESS",
                "Mot de passe modifié avec succès."
            );
        }

        return success;
    }

    public async Task<int> CreateUserAsync(string username, string password, string role)
    {
        var trimmedUsername = username.Trim();
        var existing = await _userRepository.GetByUsernameAsync(trimmedUsername);
        if (existing != null)
        {
            throw new InvalidOperationException($"L'identifiant '{trimmedUsername}' est déjà utilisé.");
        }

        var user = new User
        {
            Username = trimmedUsername,
            PasswordHash = _passwordHasher.HashPassword(password),
            Role = role,
            IsActive = true
        };

        var id = await _userRepository.CreateAsync(user);

        await _auditLogService.LogCurrentSessionActionAsync(
            "USER_CREATED",
            $"Création du compte '{user.Username}' avec le rôle '{user.Role}' (Id: {id})."
        );

        return id;
    }
}
