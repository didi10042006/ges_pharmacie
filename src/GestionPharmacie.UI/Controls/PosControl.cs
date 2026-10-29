using System.ComponentModel;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Enums;
using GestionPharmacie.UI.Forms;

namespace GestionPharmacie.UI.Controls;

public partial class PosControl : UserControl
{
    private readonly ISaleService _saleService;
    private readonly IProductService _productService;
    private readonly IReceiptService _receiptService;

    private readonly BindingList<CartItemDto> _cartItems = new();
    private decimal _discountAmount = 0m;
    private List<ProductListItemDto> _matchedProducts = new();

    public PosControl(
        ISaleService saleService,
        IProductService productService,
        IReceiptService receiptService)
    {
        _saleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _receiptService = receiptService ?? throw new ArgumentNullException(nameof(receiptService));

        InitializeComponent();
        SetupCartGrid();

        this.Load += (s, e) =>
        {
            txtProductSearch.Focus();
            UpdateTotals();
        };
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Raccourcis clavier POS
        switch (keyData)
        {
            case Keys.F2:
                txtProductSearch.Focus();
                txtProductSearch.SelectAll();
                return true;
            case Keys.F4:
                BtnApplyDiscount_Click(this, EventArgs.Empty);
                return true;
            case Keys.F5:
                BtnCheckout_Click(this, EventArgs.Empty);
                return true;
            case Keys.Escape:
                BtnClearCart_Click(this, EventArgs.Empty);
                return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void SetupCartGrid()
    {
        dgvCart.AutoGenerateColumns = false;
        dgvCart.Columns.Clear();

        dgvCart.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(CartItemDto.ProductReference),
            HeaderText = "RÉFÉRENCE",
            FillWeight = 70,
            ReadOnly = true
        });

        dgvCart.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(CartItemDto.ProductName),
            HeaderText = "MÉDICAMENT",
            FillWeight = 160,
            ReadOnly = true
        });

        dgvCart.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(CartItemDto.AllocatedLotNumber),
            HeaderText = "LOT FIFO",
            FillWeight = 75,
            ReadOnly = true,
            DefaultCellStyle = { ForeColor = Color.FromArgb(13, 110, 87), Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
        });

        dgvCart.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "PÉREMPTION",
            FillWeight = 75,
            ReadOnly = true,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvCart.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(CartItemDto.UnitPrice),
            HeaderText = "P.U TTC",
            FillWeight = 60,
            ReadOnly = true,
            DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvCart.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(CartItemDto.Quantity),
            HeaderText = "QTÉ",
            FillWeight = 50,
            ReadOnly = false,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
        });

        dgvCart.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(CartItemDto.SubTotal),
            HeaderText = "TOTAL",
            FillWeight = 70,
            ReadOnly = true,
            DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
        });

        var btnRemoveCol = new DataGridViewButtonColumn
        {
            HeaderText = "ACTION",
            Text = "❌",
            UseColumnTextForButtonValue = true,
            FillWeight = 40
        };
        dgvCart.Columns.Add(btnRemoveCol);

        dgvCart.DataSource = _cartItems;
        dgvCart.CellFormatting += DgvCart_CellFormatting;
    }

    private void DgvCart_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _cartItems.Count) return;
        var item = _cartItems[e.RowIndex];

        // Colonne Péremption (index 3)
        if (e.ColumnIndex == 3 && item.AllocatedLotExpiry.HasValue)
        {
            e.Value = item.AllocatedLotExpiry.Value.ToString("MM/yyyy");
            e.FormattingApplied = true;
        }
    }

    private async void TxtProductSearch_TextChanged(object? sender, EventArgs e)
    {
        var query = txtProductSearch.Text.Trim();
        if (query.Length < 2)
        {
            lstSearchResults.Visible = false;
            return;
        }

        var results = await _productService.GetProductsAsync(query, includeArchived: false);
        _matchedProducts = results.ToList();

        lstSearchResults.Items.Clear();
        foreach (var p in _matchedProducts)
        {
            lstSearchResults.Items.Add($"[{p.Reference}] {p.Name} - {p.SellingPrice:C2} (Stock dispo: {p.CurrentStock})");
        }

        lstSearchResults.Visible = _matchedProducts.Count > 0;
        lstSearchResults.BringToFront();
    }

    private async void TxtProductSearch_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            var query = txtProductSearch.Text.Trim();

            if (lstSearchResults.Visible && lstSearchResults.SelectedIndex >= 0)
            {
                var selectedProduct = _matchedProducts[lstSearchResults.SelectedIndex];
                await AddProductToCartAsync(selectedProduct);
            }
            else if (!string.IsNullOrWhiteSpace(query))
            {
                var results = await _productService.GetProductsAsync(query, includeArchived: false);
                var productList = results.ToList();

                if (productList.Count == 1)
                {
                    await AddProductToCartAsync(productList[0]);
                }
                else if (productList.Count > 1)
                {
                    lstSearchResults.Visible = true;
                    lstSearchResults.SelectedIndex = 0;
                    lstSearchResults.Focus();
                }
                else
                {
                    MessageBox.Show($"Aucun médicament actif correspondant à '{query}'.", "Produit introuvable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        else if (e.KeyCode == Keys.Down && lstSearchResults.Visible && lstSearchResults.Items.Count > 0)
        {
            lstSearchResults.Focus();
            lstSearchResults.SelectedIndex = 0;
        }
    }

    private async void LstSearchResults_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && lstSearchResults.SelectedIndex >= 0)
        {
            e.SuppressKeyPress = true;
            var selectedProduct = _matchedProducts[lstSearchResults.SelectedIndex];
            await AddProductToCartAsync(selectedProduct);
        }
        else if (e.KeyCode == Keys.Escape)
        {
            lstSearchResults.Visible = false;
            txtProductSearch.Focus();
        }
    }

    private async void LstSearchResults_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        if (lstSearchResults.SelectedIndex >= 0)
        {
            var selectedProduct = _matchedProducts[lstSearchResults.SelectedIndex];
            await AddProductToCartAsync(selectedProduct);
        }
    }

    /// <summary>
    /// Ajoute un produit au panier en appliquant scrupuleusement la règle FIFO d'expiration.
    /// </summary>
    private async Task AddProductToCartAsync(ProductListItemDto product)
    {
        lstSearchResults.Visible = false;
        txtProductSearch.Clear();

        // RÈGLE FIFO : Récupérer le lot ayant la péremption la plus proche
        var fifoLot = await _saleService.GetNextFifoLotForProductAsync(product.Id);
        var totalSellable = await _saleService.GetTotalSellableStockAsync(product.Id);

        // Blocage absolu si aucun lot vendable (périmé ou bloqué)
        if (fifoLot == null || totalSellable <= 0)
        {
            MessageBox.Show(
                $"VENTE IMPOSSIBLE : Le produit '{product.Name}' n'a aucun lot vendable non périmé en stock.\n\n" +
                "Les lots périmés ou bloqués ne peuvent pas être vendus au comptoir.",
                "Règle sanitaire - Stock indisponible",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            txtProductSearch.Focus();
            return;
        }

        // Vérification si déjà dans le panier
        var existingInCart = _cartItems.FirstOrDefault(c => c.ProductId == product.Id);
        if (existingInCart != null)
        {
            if (existingInCart.Quantity + 1 > totalSellable)
            {
                MessageBox.Show(
                    $"Stock vendable maximum atteint ({totalSellable} boîte(s)) pour '{product.Name}'.",
                    "Limite de stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            existingInCart.Quantity += 1;
        }
        else
        {
            _cartItems.Add(new CartItemDto
            {
                ProductId = product.Id,
                ProductReference = product.Reference,
                ProductName = product.Name,
                UnitPrice = product.SellingPrice,
                Quantity = 1,
                AllocatedLotId = fifoLot.Id,
                AllocatedLotNumber = fifoLot.LotNumber,
                AllocatedLotExpiry = fifoLot.ExpiryDate,
                AvailableStock = totalSellable
            });
        }

        dgvCart.Refresh();
        UpdateTotals();
        txtProductSearch.Focus();
    }

    private void DgvCart_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        // Bouton supprimer (dernière colonne)
        if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns.Count - 1)
        {
            _cartItems.RemoveAt(e.RowIndex);
            UpdateTotals();
            txtProductSearch.Focus();
        }
    }

    private void DgvCart_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        // Modification de la quantité
        if (e.RowIndex >= 0 && e.ColumnIndex == 5)
        {
            var item = _cartItems[e.RowIndex];
            if (item.Quantity <= 0)
            {
                _cartItems.RemoveAt(e.RowIndex);
            }
            else if (item.Quantity > item.AvailableStock)
            {
                MessageBox.Show(
                    $"Quantité demandée ({item.Quantity}) supérieure au stock vendable disponible ({item.AvailableStock}).",
                    "Alerte stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                item.Quantity = item.AvailableStock;
            }

            dgvCart.Refresh();
            UpdateTotals();
        }
    }

    private void UpdateTotals()
    {
        var grossTotal = _cartItems.Sum(c => c.SubTotal);

        if (_discountAmount > grossTotal)
        {
            _discountAmount = grossTotal;
        }

        var netTotal = grossTotal - _discountAmount;

        lblGrossTotalValue.Text = grossTotal.ToString("C2");
        lblDiscountValue.Text = (-_discountAmount).ToString("C2");
        lblNetTotalValue.Text = netTotal.ToString("C2");

        if (rdoCash.Checked)
        {
            // Ajustement auto du montant versé si nécessaire
            if (nudCashReceived.Value < netTotal)
            {
                nudCashReceived.Value = netTotal;
            }
            CalculateChange();
        }
        else
        {
            nudCashReceived.Value = netTotal;
            lblChangeValue.Text = "0,00 €";
            lblChangeValue.ForeColor = Color.FromArgb(13, 110, 87);
        }

        btnCheckout.Enabled = _cartItems.Count > 0 && netTotal >= 0;
    }

    private void CalculateChange()
    {
        var netTotal = _cartItems.Sum(c => c.SubTotal) - _discountAmount;
        var received = nudCashReceived.Value;
        var change = received - netTotal;

        if (change >= 0)
        {
            lblChangeValue.Text = change.ToString("C2");
            lblChangeValue.ForeColor = Color.FromArgb(13, 110, 87); // Vert
        }
        else
        {
            lblChangeValue.Text = "Manque : " + (-change).ToString("C2");
            lblChangeValue.ForeColor = Color.FromArgb(200, 35, 51); // Rouge
        }
    }

    private void NudCashReceived_ValueChanged(object? sender, EventArgs e)
    {
        if (rdoCash.Checked)
        {
            CalculateChange();
        }
    }

    private void PaymentMethod_Changed(object? sender, EventArgs e)
    {
        pnlCashSection.Visible = rdoCash.Checked;
        UpdateTotals();
    }

    private void BtnApplyDiscount_Click(object? sender, EventArgs e)
    {
        var grossTotal = _cartItems.Sum(c => c.SubTotal);
        if (grossTotal <= 0)
        {
            MessageBox.Show("Veuillez d'abord ajouter des articles au panier.", "Panier vide", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new DiscountApprovalDialog(_saleService, grossTotal);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _discountAmount = dialog.ApprovedDiscount;
            UpdateTotals();
            MessageBox.Show($"Remise de {_discountAmount:C2} appliquée avec succès !", "Remise accordée", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void BtnClearCart_Click(object? sender, EventArgs e)
    {
        if (_cartItems.Count == 0) return;

        if (MessageBox.Show("Souhaitez-vous annuler la saisie et vider le panier en cours ?", "Annulation panier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _cartItems.Clear();
            _discountAmount = 0m;
            UpdateTotals();
            txtProductSearch.Focus();
        }
    }

    private async void BtnCheckout_Click(object? sender, EventArgs e)
    {
        if (_cartItems.Count == 0) return;

        var netTotal = _cartItems.Sum(c => c.SubTotal) - _discountAmount;

        var paymentMethod = PaymentMethod.Cash;
        if (rdoCard.Checked) paymentMethod = PaymentMethod.CreditCard;
        else if (rdoMobile.Checked) paymentMethod = PaymentMethod.MobilePayment;

        var paidAmount = nudCashReceived.Value;
        if (paymentMethod == PaymentMethod.Cash && paidAmount < netTotal)
        {
            MessageBox.Show(
                $"Montant versé insuffisant ! Net à payer : {netTotal:C2}, Montant reçu : {paidAmount:C2}.",
                "Paiement incomplet",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            nudCashReceived.Focus();
            return;
        }

        btnCheckout.Enabled = false;
        btnCheckout.Text = "Validation en cours...";

        try
        {
            // Transaction atomique SQLite
            var saleDetail = await _saleService.ProcessSaleAsync(
                _cartItems.ToList(),
                paymentMethod,
                _discountAmount,
                paidAmount
            );

            // Génération et affichage du ticket de caisse
            var receiptText = await _receiptService.GenerateReceiptTextAsync(saleDetail);

            // Réinitialisation du panier
            _cartItems.Clear();
            _discountAmount = 0m;
            UpdateTotals();
            txtProductSearch.Focus();

            // Ouverture du ticket pour impression
            using var receiptForm = new ReceiptPreviewForm(receiptText);
            receiptForm.ShowDialog(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Échec lors de l'enregistrement de la vente :\n\n{ex.Message}",
                "Erreur de transaction",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        finally
        {
            btnCheckout.Enabled = true;
            btnCheckout.Text = "💳 Valider & Encaisser (F5)";
        }
    }

    private void BtnShiftClose_Click(object? sender, EventArgs e)
    {
        using var shiftForm = new ShiftCloseForm(_saleService);
        shiftForm.ShowDialog(this);
    }
}
