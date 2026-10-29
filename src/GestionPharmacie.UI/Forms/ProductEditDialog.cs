using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.UI.Forms;

public partial class ProductEditDialog : Form
{
    private readonly IProductService _productService;
    private readonly Product _product;
    private readonly bool _isEditMode;

    public Product Product => _product;

    public ProductEditDialog(IProductService productService, Product? existingProduct = null, IEnumerable<string>? existingCategories = null)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _isEditMode = existingProduct != null;
        _product = existingProduct ?? new Product();

        InitializeComponent();

        // Remplissage des catégories suggérées
        if (existingCategories != null)
        {
            foreach (var cat in existingCategories.Where(c => !string.IsNullOrWhiteSpace(c)))
            {
                if (!cboCategory.Items.Contains(cat))
                {
                    cboCategory.Items.Add(cat);
                }
            }
        }

        // Si modification, charger les valeurs existantes
        if (_isEditMode)
        {
            lblTitle.Text = $"Modifier : {_product.Name}";
            txtReference.Text = _product.Reference;
            txtName.Text = _product.Name;
            cboCategory.Text = _product.Category ?? string.Empty;
            txtDosage.Text = _product.Dosage ?? string.Empty;
            cboForm.Text = _product.Form ?? string.Empty;
            nudSellingPrice.Value = _product.SellingPrice;
            nudMinStock.Value = _product.MinStockThreshold;
            chkIsArchived.Checked = _product.IsArchived;
        }
        else
        {
            lblTitle.Text = "Nouveau Médicament / Produit";
            cboForm.SelectedIndex = 0; // Comprimé par défaut
            nudSellingPrice.Value = 1.00m;
            nudMinStock.Value = 5;
        }
    }

    private async void BtnSave_Click(object? sender, EventArgs e)
    {
        var reference = txtReference.Text.Trim();
        var name = txtName.Text.Trim();
        var category = cboCategory.Text.Trim();
        var dosage = txtDosage.Text.Trim();
        var form = cboForm.Text.Trim();
        var price = nudSellingPrice.Value;
        var minStock = (int)nudMinStock.Value;
        var isArchived = chkIsArchived.Checked;

        if (string.IsNullOrWhiteSpace(reference))
        {
            ShowError("La référence du médicament est obligatoire.");
            txtReference.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowError("La désignation du médicament est obligatoire.");
            txtName.Focus();
            return;
        }

        btnSave.Enabled = false;
        btnSave.Text = "Enregistrement...";
        lblError.Visible = false;

        try
        {
            _product.Reference = reference;
            _product.Name = name;
            _product.Category = string.IsNullOrWhiteSpace(category) ? null : category;
            _product.Dosage = string.IsNullOrWhiteSpace(dosage) ? null : dosage;
            _product.Form = string.IsNullOrWhiteSpace(form) ? null : form;
            _product.SellingPrice = price;
            _product.MinStockThreshold = minStock;
            _product.IsArchived = isArchived;

            await _productService.SaveProductAsync(_product);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
        finally
        {
            btnSave.Enabled = true;
            btnSave.Text = "Enregistrer";
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
