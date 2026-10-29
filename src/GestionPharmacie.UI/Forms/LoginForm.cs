using GestionPharmacie.BLL.Services;

namespace GestionPharmacie.UI.Forms;

public partial class LoginForm : Form
{
    private readonly IAuthService _authService;
    private bool _isPasswordRevealed = false;

    public LoginForm(IAuthService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        InitializeComponent();

        // Focus initial sur l'identifiant
        this.Shown += (s, e) => txtUsername.Focus();
    }

    private async void BtnLogin_Click(object? sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(username))
        {
            ShowError("Veuillez saisir votre nom d'utilisateur.");
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            ShowError("Veuillez saisir votre mot de passe.");
            txtPassword.Focus();
            return;
        }

        SetLoadingState(true);

        try
        {
            var user = await _authService.LoginAsync(username, password);

            if (user == null)
            {
                // Message sécurisé évitant l'énumération de comptes
                ShowError("Identifiant ou mot de passe incorrect.");
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Authentification réussie
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            ShowError($"Une erreur inattendue est survenue : {ex.Message}");
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    private void BtnTogglePassword_Click(object? sender, EventArgs e)
    {
        _isPasswordRevealed = !_isPasswordRevealed;
        txtPassword.UseSystemPasswordChar = !_isPasswordRevealed;
        btnTogglePassword.Text = _isPasswordRevealed ? "🔒" : "👁";
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void ShowError(string message)
    {
        lblErrorMessage.Text = message;
        lblErrorMessage.Visible = true;
    }

    private void SetLoadingState(bool isLoading)
    {
        btnLogin.Enabled = !isLoading;
        btnLogin.Text = isLoading ? "Connexion en cours..." : "Se connecter";
        txtUsername.Enabled = !isLoading;
        txtPassword.Enabled = !isLoading;
        btnTogglePassword.Enabled = !isLoading;

        if (isLoading)
        {
            lblErrorMessage.Visible = false;
        }
    }
}
