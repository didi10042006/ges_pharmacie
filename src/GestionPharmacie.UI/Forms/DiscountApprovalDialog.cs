using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;

namespace GestionPharmacie.UI.Forms;

public partial class DiscountApprovalDialog : Form
{
    private readonly ISaleService _saleService;
    private readonly decimal _maxTotal;

    public decimal ApprovedDiscount { get; private set; }

    public DiscountApprovalDialog(ISaleService saleService, decimal currentTotal)
    {
        _saleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
        _maxTotal = currentTotal;

        InitializeComponent();

        nudDiscountAmount.Maximum = _maxTotal;
        nudDiscountAmount.Value = Math.Min(1.00m, _maxTotal);

        // Si l'utilisateur connecté est déjà Admin, pré-remplir l'identifiant
        if (UserSession.Instance.IsAdmin)
        {
            txtSupervisorUsername.Text = UserSession.Instance.Username;
        }

        this.Shown += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(txtSupervisorUsername.Text))
            {
                txtSupervisorUsername.Focus();
            }
            else
            {
                txtSupervisorPassword.Focus();
            }
        };
    }

    private async void BtnApprove_Click(object? sender, EventArgs e)
    {
        var username = txtSupervisorUsername.Text.Trim();
        var password = txtSupervisorPassword.Text;
        var discount = nudDiscountAmount.Value;

        if (discount <= 0 || discount > _maxTotal)
        {
            ShowError($"Le montant de la remise doit être compris entre 0,01 € et {_maxTotal:C2}.");
            return;
        }

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ShowError("Veuillez renseigner les identifiants du responsable.");
            return;
        }

        btnApprove.Enabled = false;
        btnApprove.Text = "Validation...";

        try
        {
            var isApproved = await _saleService.ValidateDiscountApprovalAsync(username, password);
            if (!isApproved)
            {
                ShowError("Identifiants de responsable invalides ou droits insuffisants.");
                txtSupervisorPassword.Clear();
                txtSupervisorPassword.Focus();
                return;
            }

            ApprovedDiscount = discount;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            ShowError($"Erreur : {ex.Message}");
        }
        finally
        {
            btnApprove.Enabled = true;
            btnApprove.Text = "Valider Remise";
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void ShowError(string message)
    {
        lblError.Text = message;
        lblError.Visible = true;
    }
}
