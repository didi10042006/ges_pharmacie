using System.Drawing;
using System.Windows.Forms;
using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.UI.Controls;

public partial class InventoryControl : UserControl
{
    private readonly IInventoryService _inventoryService;
    private readonly IReportService _reportService;

    private List<InventoryLotItemDto> _allLots = new();
    private InventoryLotItemDto? _selectedLot;

    public InventoryControl(IInventoryService inventoryService, IReportService reportService)
    {
        _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));

        InitializeComponent();
        ConfigureGridColumns();

        ApplySecurityPolicies();
    }

    private void ApplySecurityPolicies()
    {
        var session = UserSession.Instance;
        btnToggleBlock.Visible = session.IsAdmin;

        if (!session.CanManageStock)
        {
            grpAdjustment.Enabled = false;
            grpAdjustment.Text += " (Accès restreint aux Administrateurs / Gestionnaires)";
        }
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (cboReason.Items.Count > 0)
        {
            cboReason.SelectedIndex = 0;
        }

        await LoadLotsAsync();
    }

    private void ConfigureGridColumns()
    {
        dgvLots.AutoGenerateColumns = false;
        dgvLots.Columns.Clear();

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.LotId),
            HeaderText = "ID Lot",
            Width = 70,
            Visible = false
        });

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.ProductReference),
            HeaderText = "Réf. Produit",
            Width = 110
        });

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.ProductName),
            HeaderText = "Désignation Médicament",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.Category),
            HeaderText = "Catégorie",
            Width = 130
        });

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.LotNumber),
            HeaderText = "N° de Lot",
            Width = 120
        });

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.ExpiryFormatted),
            HeaderText = "Péremption",
            Width = 100
        });

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.TheoreticalQuantity),
            HeaderText = "Stock Théorique",
            Width = 120,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvLots.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InventoryLotItemDto.StatusDisplay),
            HeaderText = "Statut Lot",
            Width = 130
        });

        dgvLots.RowPrePaint += DgvLots_RowPrePaint;
    }

    private void DgvLots_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvLots.Rows.Count) return;

        var row = dgvLots.Rows[e.RowIndex];
        if (row.DataBoundItem is InventoryLotItemDto lot)
        {
            if (lot.IsBlocked)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(153, 27, 27);
            }
            else if (lot.ExpiryDate.Date < DateTime.Today)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 237, 213);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(154, 52, 18);
            }
            else if (lot.TheoreticalQuantity <= 0)
            {
                row.DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);
            }
        }
    }

    public async Task LoadLotsAsync()
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            _allLots = (await _inventoryService.GetInventoryLotsAsync(null, chkIncludeZeroStock.Checked)).ToList();
            ApplyClientFilter();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement de l'inventaire : {ex.Message}", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void ApplyClientFilter()
    {
        string query = txtSearch.Text.Trim().ToLowerInvariant();
        var filtered = _allLots.Where(l =>
            string.IsNullOrWhiteSpace(query) ||
            l.ProductName.ToLowerInvariant().Contains(query) ||
            l.ProductReference.ToLowerInvariant().Contains(query) ||
            l.LotNumber.ToLowerInvariant().Contains(query)
        ).ToList();

        dgvLots.DataSource = null;
        dgvLots.DataSource = filtered;

        ResetAdjustmentSection();
    }

    private void ResetAdjustmentSection()
    {
        _selectedLot = null;
        lblSelectedLotInfo.Text = "Sélectionnez un lot dans la grille ci-dessus pour effectuer un inventaire ou un ajustement.";
        lblSelectedLotInfo.ForeColor = Color.FromArgb(50, 60, 70);
        nudPhysicalCount.Value = 0;
        lblDiscrepancyValue.Text = "0";
        lblDiscrepancyValue.ForeColor = Color.FromArgb(13, 110, 87);
        btnApplyAdjustment.Enabled = false;
        btnToggleBlock.Enabled = false;
        btnToggleBlock.Text = "🔒 Bloquer ce Lot";
    }

    private void DgvLots_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvLots.CurrentRow?.DataBoundItem is InventoryLotItemDto lot)
        {
            _selectedLot = lot;
            lblSelectedLotInfo.Text = $"Lot: {lot.LotNumber} | Produit: {lot.ProductName} ({lot.ProductReference}) | " +
                                     $"Péremption: {lot.ExpiryFormatted} | Stock Système: {lot.TheoreticalQuantity} unité(s)" +
                                     (lot.IsBlocked ? " [ACTUELLEMENT BLOQUÉ]" : "");

            lblSelectedLotInfo.ForeColor = lot.IsBlocked ? Color.FromArgb(185, 28, 28) : Color.FromArgb(20, 30, 45);

            nudPhysicalCount.Value = Math.Max(0, lot.TheoreticalQuantity);
            CalculateDiscrepancy();

            btnApplyAdjustment.Enabled = UserSession.Instance.CanManageStock;
            btnToggleBlock.Enabled = UserSession.Instance.IsAdmin;
            btnToggleBlock.Text = lot.IsBlocked ? "🔓 Débloquer ce Lot" : "🔒 Bloquer ce Lot";
        }
        else
        {
            ResetAdjustmentSection();
        }
    }

    private void NudPhysicalCount_ValueChanged(object? sender, EventArgs e)
    {
        CalculateDiscrepancy();
    }

    private void CalculateDiscrepancy()
    {
        if (_selectedLot == null)
        {
            lblDiscrepancyValue.Text = "0";
            lblDiscrepancyValue.ForeColor = Color.FromArgb(13, 110, 87);
            return;
        }

        int physical = (int)nudPhysicalCount.Value;
        int discrepancy = physical - _selectedLot.TheoreticalQuantity;

        if (discrepancy > 0)
        {
            lblDiscrepancyValue.Text = $"+{discrepancy}";
            lblDiscrepancyValue.ForeColor = Color.FromArgb(2, 132, 199);
        }
        else if (discrepancy < 0)
        {
            lblDiscrepancyValue.Text = $"{discrepancy}";
            lblDiscrepancyValue.ForeColor = Color.FromArgb(220, 38, 38);
        }
        else
        {
            lblDiscrepancyValue.Text = "0 (Conforme)";
            lblDiscrepancyValue.ForeColor = Color.FromArgb(13, 110, 87);
        }
    }

    private async void BtnApplyAdjustment_Click(object? sender, EventArgs e)
    {
        if (_selectedLot == null) return;

        if (!UserSession.Instance.CanManageStock)
        {
            MessageBox.Show("Vous n'avez pas l'autorisation d'ajuster les stocks.", "Droit insuffisant",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int physical = (int)nudPhysicalCount.Value;
        int discrepancy = physical - _selectedLot.TheoreticalQuantity;

        if (discrepancy == 0)
        {
            MessageBox.Show("Le stock physique saisi est identique au stock théorique. Aucun écart à enregistrer.",
                "Aucun changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string reason = cboReason.Text.Trim();
        if (string.IsNullOrWhiteSpace(reason))
        {
            MessageBox.Show("Le motif d'ajustement est OBLIGATOIRE pour la traçabilité et l'audit légal.",
                "Motif requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboReason.Focus();
            return;
        }

        string sign = discrepancy > 0 ? $"+{discrepancy}" : $"{discrepancy}";
        var confirmation = MessageBox.Show(
            $"Confirmez-vous l'ajustement de stock pour le lot {_selectedLot.LotNumber} ?\n\n" +
            $"• Produit : {_selectedLot.ProductName}\n" +
            $"• Stock théorique : {_selectedLot.TheoreticalQuantity}\n" +
            $"• Stock compté (réel) : {physical}\n" +
            $"• Écart net : {sign} unité(s)\n" +
            $"• Motif : {reason}",
            "Confirmation d'ajustement d'inventaire",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmation != DialogResult.Yes) return;

        try
        {
            Cursor = Cursors.WaitCursor;

            bool success = await _inventoryService.AdjustLotStockAsync(
                _selectedLot.LotId,
                physical,
                reason);

            if (success)
            {
                MessageBox.Show("Ajustement de stock enregistré avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadLotsAsync();
            }
            else
            {
                MessageBox.Show("Échec de l'ajustement du lot.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur : {ex.Message}", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async void BtnToggleBlock_Click(object? sender, EventArgs e)
    {
        if (_selectedLot == null) return;

        if (!UserSession.Instance.IsAdmin)
        {
            MessageBox.Show("Seul un Administrateur est autorisé à bloquer ou débloquer un lot.",
                "Accès restreint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string actionText = _selectedLot.IsBlocked ? "débloquer" : "bloquer";
        var confirm = MessageBox.Show(
            $"Êtes-vous sûr de vouloir {actionText} le lot {_selectedLot.LotNumber} ({_selectedLot.ProductName}) ?\n" +
            (_selectedLot.IsBlocked
                ? "Le lot redeviendra disponible à la vente."
                : "Le lot sera immédiatement retiré de la vente au comptoir."),
            "Confirmation de blocage de lot",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        try
        {
            Cursor = Cursors.WaitCursor;

            bool newBlockedState = !_selectedLot.IsBlocked;
            bool success = await _inventoryService.ToggleBlockLotAsync(_selectedLot.LotId, newBlockedState);
            if (success)
            {
                MessageBox.Show($"Le lot a été {(_selectedLot.IsBlocked ? "débloqué" : "bloqué")} avec succès.",
                    "Statut mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadLotsAsync();
            }
            else
            {
                MessageBox.Show("Échec de la modification du statut du lot.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur : {ex.Message}", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        ApplyClientFilter();
    }

    private async void Filter_Changed(object? sender, EventArgs e)
    {
        await LoadLotsAsync();
    }

    private async void BtnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadLotsAsync();
    }

    private void BtnExportCsv_Click(object? sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog
        {
            Filter = "Fichier CSV (*.csv)|*.csv",
            FileName = $"Inventaire_Lots_{DateTime.Now:yyyyMMdd_HHmm}.csv",
            Title = "Exporter l'inventaire en CSV"
        };

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var csv = _reportService.ExportInventoryToCsv(_allLots);
                File.WriteAllText(sfd.FileName, csv, System.Text.Encoding.UTF8);

                MessageBox.Show($"Fichier inventaire exporté avec succès !\n{sfd.FileName}",
                    "Exportation réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'export CSV : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
