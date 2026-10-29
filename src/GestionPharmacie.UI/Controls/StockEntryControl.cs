using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.UI.Controls;

public partial class StockEntryControl : UserControl
{
    private readonly IStockService _stockService;
    private readonly IProductService _productService;

    private List<Supplier> _suppliers = new();
    private List<ProductListItemDto> _availableProducts = new();
    private readonly List<StockReceptionLineItem> _receptionLines = new();

    public class StockReceptionLineItem
    {
        public int ProductId { get; set; }
        public string ProductReference { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string LotNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal LineTotal => Quantity * PurchaseCost;
        public string ExpiryDateFormatted => ExpiryDate.ToString("dd/MM/yyyy");
    }

    public StockEntryControl(IStockService stockService, IProductService productService)
    {
        _stockService = stockService ?? throw new ArgumentNullException(nameof(stockService));
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));

        InitializeComponent();
        SetupGridColumns();

        // Date de péremption par défaut : 2 ans à partir d'aujourd'hui
        dtpExpiryDate.MinDate = DateTime.Today.AddDays(1);
        dtpExpiryDate.Value = DateTime.Today.AddYears(2);

        this.Load += async (s, e) =>
        {
            await LoadSuppliersAsync();
            await LoadProductsDropdownAsync();
        };
    }

    private void SetupGridColumns()
    {
        dgvLines.AutoGenerateColumns = false;
        dgvLines.Columns.Clear();

        dgvLines.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(StockReceptionLineItem.ProductReference),
            HeaderText = "RÉFÉRENCE",
            FillWeight = 80
        });

        dgvLines.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(StockReceptionLineItem.ProductName),
            HeaderText = "MÉDICAMENT / PRODUIT",
            FillWeight = 160
        });

        dgvLines.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(StockReceptionLineItem.LotNumber),
            HeaderText = "N° DE LOT",
            FillWeight = 85
        });

        dgvLines.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(StockReceptionLineItem.ExpiryDateFormatted),
            HeaderText = "PÉREMPTION",
            FillWeight = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvLines.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(StockReceptionLineItem.Quantity),
            HeaderText = "QUANTITÉ",
            FillWeight = 60,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvLines.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(StockReceptionLineItem.PurchaseCost),
            HeaderText = "COÛT UNIT. TTC",
            FillWeight = 75,
            DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvLines.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(StockReceptionLineItem.LineTotal),
            HeaderText = "TOTAL LIGNE",
            FillWeight = 80,
            DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        var btnRemoveCol = new DataGridViewButtonColumn
        {
            HeaderText = "ACTION",
            Text = "❌ Retirer",
            UseColumnTextForButtonValue = true,
            FillWeight = 55
        };
        dgvLines.Columns.Add(btnRemoveCol);
    }

    public async Task RefreshDataAsync()
    {
        await LoadSuppliersAsync();
        await LoadProductsDropdownAsync();
    }

    private async Task LoadSuppliersAsync()
    {
        var suppliers = await _stockService.GetActiveSuppliersAsync();
        _suppliers = suppliers.ToList();

        cboSupplier.DataSource = null;
        cboSupplier.DisplayMember = nameof(Supplier.Name);
        cboSupplier.ValueMember = nameof(Supplier.Id);
        cboSupplier.DataSource = _suppliers;

        if (_suppliers.Count > 0)
        {
            cboSupplier.SelectedIndex = 0;
        }
    }

    private async Task LoadProductsDropdownAsync()
    {
        var products = await _productService.GetProductsAsync(includeArchived: false);
        _availableProducts = products.ToList();

        cboProduct.DataSource = null;
        cboProduct.DisplayMember = "DisplayName";
        cboProduct.ValueMember = nameof(ProductListItemDto.Id);

        // Crée une liste adaptée pour le combo
        var dropdownItems = _availableProducts.Select(p => new
        {
            Id = p.Id,
            DisplayName = $"[{p.Reference}] {p.Name} {(string.IsNullOrWhiteSpace(p.Dosage) ? "" : " - " + p.Dosage)}"
        }).ToList();

        cboProduct.DataSource = dropdownItems;
    }

    private void BtnAddLine_Click(object? sender, EventArgs e)
    {
        if (cboProduct.SelectedValue == null)
        {
            MessageBox.Show("Veuillez sélectionner un médicament dans la liste.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboProduct.Focus();
            return;
        }

        var productId = (int)cboProduct.SelectedValue;
        var product = _availableProducts.FirstOrDefault(p => p.Id == productId);
        if (product == null) return;

        var lotNumber = txtLotNumber.Text.Trim();
        if (string.IsNullOrWhiteSpace(lotNumber))
        {
            MessageBox.Show("Le numéro de lot est obligatoire pour garantir la traçabilité sanitaire.", "Numéro de lot manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtLotNumber.Focus();
            return;
        }

        var expiryDate = dtpExpiryDate.Value.Date;
        if (expiryDate <= DateTime.Today)
        {
            MessageBox.Show("La date de péremption doit obligatoirement être supérieure à aujourd'hui.", "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpExpiryDate.Focus();
            return;
        }

        var quantity = (int)nudQuantity.Value;
        if (quantity <= 0)
        {
            MessageBox.Show("La quantité reçue doit être supérieure à 0.", "Quantité invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudQuantity.Focus();
            return;
        }

        var purchaseCost = nudPurchaseCost.Value;

        // Vérification de doublon dans la réception en cours
        var existingLine = _receptionLines.FirstOrDefault(l => l.ProductId == productId && string.Equals(l.LotNumber, lotNumber, StringComparison.OrdinalIgnoreCase));
        if (existingLine != null)
        {
            var res = MessageBox.Show(
                $"Le lot '{lotNumber}' pour le produit '{product.Name}' est déjà présent dans la liste de réception.\n" +
                $"Souhaitez-vous cumuler la quantité (+{quantity}) ?",
                "Lot déjà listé",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.Yes)
            {
                existingLine.Quantity += quantity;
                existingLine.PurchaseCost = purchaseCost;
            }
        }
        else
        {
            _receptionLines.Add(new StockReceptionLineItem
            {
                ProductId = product.Id,
                ProductReference = product.Reference,
                ProductName = product.Name,
                LotNumber = lotNumber,
                ExpiryDate = expiryDate,
                Quantity = quantity,
                PurchaseCost = purchaseCost
            });
        }

        // Rafraîchir l'affichage
        RefreshLinesGrid();

        // Réinitialisation partielle pour la saisie suivante
        txtLotNumber.Clear();
        nudQuantity.Value = 10;
        txtLotNumber.Focus();
    }

    private void DgvLines_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        // Colonne de bouton supprimer
        if (e.RowIndex >= 0 && e.ColumnIndex == dgvLines.Columns.Count - 1)
        {
            _receptionLines.RemoveAt(e.RowIndex);
            RefreshLinesGrid();
        }
    }

    private void RefreshLinesGrid()
    {
        dgvLines.DataSource = null;
        dgvLines.DataSource = _receptionLines;

        var totalCount = _receptionLines.Count;
        var totalQty = _receptionLines.Sum(l => l.Quantity);
        var totalCost = _receptionLines.Sum(l => l.LineTotal);

        lblTotalSummary.Text = $"Lots en attente : {totalCount} | Quantité totale reçue : {totalQty} unités | Montant total : {totalCost:C2}";
        btnSubmitReception.Enabled = totalCount > 0;
    }

    private void BtnClear_Click(object? sender, EventArgs e)
    {
        if (_receptionLines.Count == 0) return;

        var confirm = MessageBox.Show(
            "Êtes-vous sûr de vouloir vider tous les lots en attente ?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            _receptionLines.Clear();
            RefreshLinesGrid();
        }
    }

    private async void BtnSubmitReception_Click(object? sender, EventArgs e)
    {
        if (_receptionLines.Count == 0)
        {
            MessageBox.Show("Veuillez ajouter au moins une ligne de lot avant de valider.", "Liste vide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var docNumber = txtDocNumber.Text.Trim();
        if (string.IsNullOrWhiteSpace(docNumber))
        {
            MessageBox.Show("Veuillez renseigner le numéro du bon de livraison ou de la facture.", "N° document obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDocNumber.Focus();
            return;
        }

        int? supplierId = cboSupplier.SelectedValue != null ? (int)cboSupplier.SelectedValue : null;
        var supplierName = cboSupplier.Text;

        var totalQty = _receptionLines.Sum(l => l.Quantity);
        var totalCost = _receptionLines.Sum(l => l.LineTotal);

        var confirm = MessageBox.Show(
            $"Confirmez-vous la validation de la réception [Doc: {docNumber}] ?\n\n" +
            $"• Fournisseur : {supplierName}\n" +
            $"• Nombre de lots : {_receptionLines.Count}\n" +
            $"• Total unités reçues : {totalQty}\n" +
            $"• Coût total : {totalCost:C2}\n\n" +
            "Cette action incrémentera immédiatement les stocks vendables de façon atomique.",
            "Confirmation de réception de stock",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm != DialogResult.Yes) return;

        btnSubmitReception.Enabled = false;
        btnSubmitReception.Text = "Enregistrement en cours...";

        try
        {
            // Conversion en entités StockLot
            var stockLots = _receptionLines.Select(l => new StockLot
            {
                ProductId = l.ProductId,
                SupplierId = supplierId,
                LotNumber = l.LotNumber,
                ExpiryDate = l.ExpiryDate,
                Quantity = l.Quantity,
                PurchaseCost = l.PurchaseCost,
                IsBlocked = false
            }).ToList();

            // Exécution atomique
            var success = await _stockService.ReceiveStockBatchAsync(supplierId, docNumber, stockLots);

            if (success)
            {
                MessageBox.Show(
                    $"La réception de stock ({totalQty} unités sur {_receptionLines.Count} lots) a été validée avec succès !",
                    "Entrée de stock confirmée",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Réinitialisation complète
                _receptionLines.Clear();
                txtDocNumber.Clear();
                RefreshLinesGrid();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'enregistrement de la réception : {ex.Message}", "Erreur critique", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSubmitReception.Enabled = true;
            btnSubmitReception.Text = "💾 Valider Réception Stock";
        }
    }
}
