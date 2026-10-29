using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GestionPharmacie.BLL.Security;
using GestionPharmacie.BLL.Services;

namespace GestionPharmacie.UI.Controls;

public partial class BackupControl : UserControl
{
    private readonly IBackupService _backupService;
    private FileInfo? _selectedBackupFile;

    public BackupControl(IBackupService backupService)
    {
        _backupService = backupService ?? throw new ArgumentNullException(nameof(backupService));

        InitializeComponent();
        ConfigureGridColumns();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!UserSession.Instance.IsAdmin)
        {
            MessageBox.Show("Accès restreint. Le module de sauvegarde et de restauration est réservé exclusivement à l'Administrateur.",
                "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Enabled = false;
            return;
        }

        lblBackupDir.Text = $"Dossier de destination : {_backupService.DefaultBackupFolder}";
        LoadBackups();
    }

    private void ConfigureGridColumns()
    {
        dgvBackups.AutoGenerateColumns = false;
        dgvBackups.Columns.Clear();

        dgvBackups.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(FileInfo.Name),
            HeaderText = "NOM DU FICHIER SAUVEGARDE",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        dgvBackups.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(FileInfo.CreationTime),
            HeaderText = "DATE & HEURE DE CRÉATION",
            Width = 200,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" }
        });

        dgvBackups.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "TAILLE DU FICHIER",
            Width = 140,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvBackups.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBackups.Rows.Count) return;
            if (e.ColumnIndex == 2 && dgvBackups.Rows[e.RowIndex].DataBoundItem is FileInfo fi)
            {
                double kb = fi.Length / 1024.0;
                e.Value = kb >= 1024 ? $"{kb / 1024.0:F2} Mo" : $"{kb:F1} Ko";
                e.FormattingApplied = true;
            }
        };
    }

    public void LoadBackups()
    {
        try
        {
            var backups = _backupService.GetExistingBackups().ToList();
            dgvBackups.DataSource = null;
            dgvBackups.DataSource = backups;

            btnRestoreBackup.Enabled = false;
            _selectedBackupFile = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de la lecture des sauvegardes : {ex.Message}", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DgvBackups_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvBackups.CurrentRow?.DataBoundItem is FileInfo file)
        {
            _selectedBackupFile = file;
            btnRestoreBackup.Enabled = UserSession.Instance.IsAdmin;
        }
        else
        {
            _selectedBackupFile = null;
            btnRestoreBackup.Enabled = false;
        }
    }

    private async void BtnCreateBackup_Click(object? sender, EventArgs e)
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            btnCreateBackup.Enabled = false;

            string backupPath = await _backupService.CreateBackupAsync();

            MessageBox.Show($"Sauvegarde SQLite consistante créée avec succès !\n\nFichier :\n{backupPath}",
                "Sauvegarde Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadBackups();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de la création de la sauvegarde : {ex.Message}", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnCreateBackup.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private async void BtnRestoreBackup_Click(object? sender, EventArgs e)
    {
        if (_selectedBackupFile == null) return;

        if (!UserSession.Instance.IsAdmin)
        {
            MessageBox.Show("La restauration de la base de données est exclusivement réservée à l'Administrateur.",
                "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm1 = MessageBox.Show(
            $"ATTENTION : Vous êtes sur le point de restaurer la base de données à partir du fichier :\n" +
            $"'{_selectedBackupFile.Name}' ({_selectedBackupFile.CreationTime:dd/MM/yyyy HH:mm}).\n\n" +
            $"Toutes les données créées après cette sauvegarde seront remplacées.\n" +
            $"Une copie de sécurité de la base actuelle sera automatiquement créée au préalable.\n\n" +
            $"Souhaitez-vous continuer ?",
            "Confirmation de restauration critique",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);

        if (confirm1 != DialogResult.Yes) return;

        var confirm2 = MessageBox.Show(
            "Êtes-vous ABSOLUMENT CERTAIN ? Cette action est irréversible pour la session en cours.",
            "Dernière confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (confirm2 != DialogResult.Yes) return;

        try
        {
            Cursor = Cursors.WaitCursor;
            btnRestoreBackup.Enabled = false;

            bool success = await _backupService.RestoreBackupAsync(_selectedBackupFile.FullName);

            if (success)
            {
                MessageBox.Show(
                    "La base de données a été restaurée avec succès !\n\n" +
                    "Il est fortement recommandé de redémarrer l'application pour recharger l'ensemble des données fraîches.",
                    "Restauration effectuée",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadBackups();
            }
            else
            {
                MessageBox.Show("Échec de la restauration de la base de données.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur critique lors de la restauration : {ex.Message}", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRestoreBackup.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void BtnRefresh_Click(object? sender, EventArgs e)
    {
        LoadBackups();
    }

    private void BtnOpenFolder_Click(object? sender, EventArgs e)
    {
        try
        {
            if (Directory.Exists(_backupService.DefaultBackupFolder))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _backupService.DefaultBackupFolder,
                    UseShellExecute = true
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Impossible d'ouvrir le dossier : {ex.Message}", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
