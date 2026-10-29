using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.UI.Forms;

namespace GestionPharmacie.UI.Controls;

public partial class ProductsControl : UserControl
{
    private readonly IProductService _productService;
    private List<ProductListItemDto> _products = new();
    private readonly System.Windows.Forms.Timer _searchDebounceTimer;

    public ProductsControl(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        InitializeComponent();

        _searchDebounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
        _searchDebounceTimer.Tick += (s, e) =>
        {
            _searchDebounceTimer.Stop();
            _ = LoadProductsAsync();
        };

        SetupGridColumns();
        ApplyRbacPermissions();

        this.Load += async (s, e) =>
        {
            await LoadCategoriesAsync();
            await LoadProductsAsync();
        };
    }

    private void ApplyRbacPermissions()
    {
        var canManage = UserSession.Instance.CanManageStock;
        btnNewProduct.Visible = canManage;
        btnEdit.Visible = canManage;
        btnDelete.Visible = canManage;
        btnToggleArchive.Visible = canManage;
    }

    private void SetupGridColumns()
    {
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.Columns.Clear();

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.Id),
            HeaderText = "ID",
            FillWeight = 30,
            Visible = false
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.Reference),
            HeaderText = "RÉFÉRENCE",
            FillWeight = 70
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.Name),
            HeaderText = "DÉSIGNATION",
            FillWeight = 160
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.Category),
            HeaderText = "CATÉGORIE",
            FillWeight = 90
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.Dosage),
            HeaderText = "DOSAGE",
            FillWeight = 70
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.Form),
            HeaderText = "FORME",
            FillWeight = 70
        });

        var priceCol = new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.SellingPrice),
            HeaderText = "PRIX TTC",
            FillWeight = 60,
            DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        };
        dgvProducts.Columns.Add(priceCol);

        var stockCol = new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.CurrentStock),
            HeaderText = "STOCK DISPO",
            FillWeight = 65,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvProducts.Columns.Add(stockCol);

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.MinStockThreshold),
            HeaderText = "SEUIL MIN",
            FillWeight = 55,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductListItemDto.StatusDisplay),
            HeaderText = "ÉTAT",
            FillWeight = 65,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvProducts.CellFormatting += DgvProducts_CellFormatting;
    }

    private void DgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvProducts.Rows.Count) return;

        var item = dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductListItemDto;
        if (item == null) return;

        if (item.IsArchived)
        {
            dgvProducts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
            dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }
        else if (item.IsLowStock)
        {
            dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205); // Alerte douce ambrée
            dgvProducts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(133, 100, 4);
        }
    }

    private async Task LoadCategoriesAsync()
    {
        var categories = await _productService.GetCategoriesAsync();
        cboCategoryFilter.Items.Clear();
        cboCategoryFilter.Items.Add("Toutes");

        foreach (var cat in categories)
        {
            cboCategoryFilter.Items.Add(cat);
        }

        cboCategoryFilter.SelectedIndex = 0;
    }

    public async Task LoadProductsAsync()
    {
        var searchTerm = txtSearch.Text;
        var category = cboCategoryFilter.SelectedItem?.ToString();
        var includeArchived = chkIncludeArchived.Checked;

        var results = await _productService.GetProductsAsync(searchTerm, category, includeArchived);
        _products = results.ToList();

        dgvProducts.DataSource = null;
        dgvProducts.DataSource = _products;

        lblStats.Text = $"Total : {_products.Count} produit(s) listé(s) • {_products.Count(p => p.IsLowStock)} en alerte stock bas";
        UpdateButtonsState();
    }

    private void UpdateButtonsState()
    {
        var hasSelection = dgvProducts.CurrentRow != null;
        var canManage = UserSession.Instance.CanManageStock;

        btnEdit.Enabled = hasSelection && canManage;
        btnDelete.Enabled = hasSelection && canManage;
        btnToggleArchive.Enabled = hasSelection && canManage;

        if (hasSelection)
        {
            var item = dgvProducts.CurrentRow?.DataBoundItem as ProductListItemDto;
            if (item != null)
            {
                btnToggleArchive.Text = item.IsArchived ? "🔓 Réactiver" : "📁 Archiver";
            }
        }
    }

    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        _searchDebounceTimer.Stop();
        _searchDebounceTimer.Start();
    }

    private void Filter_Changed(object? sender, EventArgs e)
    {
        _ = LoadProductsAsync();
    }

    private async void BtnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadCategoriesAsync();
        await LoadProductsAsync();
    }

    private ProductListItemDto? GetSelectedItem()
    {
        return dgvProducts.CurrentRow?.DataBoundItem as ProductListItemDto;
    }

    private async void BtnNewProduct_Click(object? sender, EventArgs e)
    {
        var categories = await _productService.GetCategoriesAsync();
        using var dialog = new ProductEditDialog(_productService, null, categories);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await LoadCategoriesAsync();
            await LoadProductsAsync();
        }
    }

    private async void BtnEdit_Click(object? sender, EventArgs e)
    {
        await EditCurrentProductAsync();
    }

    private async void DgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && UserSession.Instance.CanManageStock)
        {
            await EditCurrentProductAsync();
        }
    }

    private async Task EditCurrentProductAsync()
    {
        var selected = GetSelectedItem();
        if (selected == null) return;

        var product = await _productService.GetByIdAsync(selected.Id);
        if (product == null) return;

        var categories = await _productService.GetCategoriesAsync();
        using var dialog = new ProductEditDialog(_productService, product, categories);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await LoadProductsAsync();
        }
    }

    private async void BtnDelete_Click(object? sender, EventArgs e)
    {
        var selected = GetSelectedItem();
        if (selected == null) return;

        var confirm = MessageBox.Show(
            $"Souhaitez-vous supprimer le produit '{selected.Name}' (Réf: {selected.Reference}) ?\n\n" +
            "Note : Si ce médicament possède un historique d'entrées en stock ou de ventes, il sera automatiquement archivé afin de préserver l'intégrité de la traçabilité.",
            "Confirmation de suppression / archivage",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm != DialogResult.Yes) return;

        try
        {
            var (success, wasArchived, message) = await _productService.DeleteOrArchiveProductAsync(selected.Id);
            if (success)
            {
                MessageBox.Show(
                    message,
                    wasArchived ? "Produit Archivé" : "Produit Supprimé",
                    MessageBoxButtons.OK,
                    wasArchived ? MessageBoxIcon.Information : MessageBoxIcon.Information
                );
                await LoadProductsAsync();
            }
            else
            {
                MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnToggleArchive_Click(object? sender, EventArgs e)
    {
        var selected = GetSelectedItem();
        if (selected == null) return;

        var newArchivedState = !selected.IsArchived;
        var actionName = newArchivedState ? "archiver" : "réactiver";

        var confirm = MessageBox.Show(
            $"Voulez-vous vraiment {actionName} le produit '{selected.Name}' ?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            await _productService.ToggleArchiveAsync(selected.Id, newArchivedState);
            await LoadProductsAsync();
        }
    }

    private void DgvProducts_SelectionChanged(object? sender, EventArgs e)
    {
        UpdateButtonsState();
    }
}
