namespace GestionPharmacie.UI.Controls;

partial class BackupControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Button btnRefresh;

    private System.Windows.Forms.GroupBox grpImmediateBackup;
    private System.Windows.Forms.Button btnCreateBackup;
    private System.Windows.Forms.Label lblBackupDescription;
    private System.Windows.Forms.Label lblBackupDir;
    private System.Windows.Forms.Button btnOpenFolder;

    private System.Windows.Forms.GroupBox grpExistingBackups;
    private System.Windows.Forms.DataGridView dgvBackups;
    private System.Windows.Forms.Button btnRestoreBackup;
    private System.Windows.Forms.Label lblRestoreWarning;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.lblHeaderSubtitle = new System.Windows.Forms.Label();
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.grpImmediateBackup = new System.Windows.Forms.GroupBox();
        this.btnOpenFolder = new System.Windows.Forms.Button();
        this.lblBackupDir = new System.Windows.Forms.Label();
        this.btnCreateBackup = new System.Windows.Forms.Button();
        this.lblBackupDescription = new System.Windows.Forms.Label();
        this.grpExistingBackups = new System.Windows.Forms.GroupBox();
        this.lblRestoreWarning = new System.Windows.Forms.Label();
        this.btnRestoreBackup = new System.Windows.Forms.Button();
        this.dgvBackups = new System.Windows.Forms.DataGridView();
        this.pnlHeader.SuspendLayout();
        this.grpImmediateBackup.SuspendLayout();
        this.grpExistingBackups.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.White;
        this.pnlHeader.Controls.Add(this.btnRefresh);
        this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(25, 12, 25, 10);
        this.pnlHeader.Size = new System.Drawing.Size(1100, 65);
        this.pnlHeader.TabIndex = 0;
        // 
        // btnRefresh
        // 
        this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnRefresh.FlatAppearance.BorderSize = 0;
        this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnRefresh.Location = new System.Drawing.Point(965, 15);
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Size = new System.Drawing.Size(110, 32);
        this.btnRefresh.TabIndex = 2;
        this.btnRefresh.Text = "🔄 Actualiser";
        this.btnRefresh.UseVisualStyleBackColor = false;
        this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
        // 
        // lblHeaderSubtitle
        // 
        this.lblHeaderSubtitle.AutoSize = true;
        this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblHeaderSubtitle.Location = new System.Drawing.Point(25, 38);
        this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(534, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Sauvegardes SQLite consistantes à chaud (VACUUM INTO) et restauration sécurisée Administrateur";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblHeaderTitle.Location = new System.Drawing.Point(23, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(332, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "💾 Sauvegarde & Restauration SQLite";
        // 
        // grpImmediateBackup
        // 
        this.grpImmediateBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.grpImmediateBackup.BackColor = System.Drawing.Color.White;
        this.grpImmediateBackup.Controls.Add(this.btnOpenFolder);
        this.grpImmediateBackup.Controls.Add(this.lblBackupDir);
        this.grpImmediateBackup.Controls.Add(this.btnCreateBackup);
        this.grpImmediateBackup.Controls.Add(this.lblBackupDescription);
        this.grpImmediateBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.grpImmediateBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
        this.grpImmediateBackup.Location = new System.Drawing.Point(25, 80);
        this.grpImmediateBackup.Name = "grpImmediateBackup";
        this.grpImmediateBackup.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
        this.grpImmediateBackup.Size = new System.Drawing.Size(1050, 120);
        this.grpImmediateBackup.TabIndex = 1;
        this.grpImmediateBackup.TabStop = false;
        this.grpImmediateBackup.Text = "Sauvegarde Immédiate";
        // 
        // btnOpenFolder
        // 
        this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnOpenFolder.BackColor = System.Drawing.Color.White;
        this.btnOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
        this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnOpenFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnOpenFolder.ForeColor = System.Drawing.Color.Black;
        this.btnOpenFolder.Location = new System.Drawing.Point(620, 42);
        this.btnOpenFolder.Name = "btnOpenFolder";
        this.btnOpenFolder.Size = new System.Drawing.Size(160, 42);
        this.btnOpenFolder.TabIndex = 3;
        this.btnOpenFolder.Text = "📂 Ouvrir le dossier";
        this.btnOpenFolder.UseVisualStyleBackColor = false;
        this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
        // 
        // lblBackupDir
        // 
        this.lblBackupDir.AutoSize = true;
        this.lblBackupDir.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblBackupDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
        this.lblBackupDir.Location = new System.Drawing.Point(20, 68);
        this.lblBackupDir.Name = "lblBackupDir";
        this.lblBackupDir.Size = new System.Drawing.Size(127, 15);
        this.lblBackupDir.TabIndex = 2;
        this.lblBackupDir.Text = "Dossier de destination : ";
        // 
        // btnCreateBackup
        // 
        this.btnCreateBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnCreateBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnCreateBackup.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCreateBackup.FlatAppearance.BorderSize = 0;
        this.btnCreateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCreateBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnCreateBackup.ForeColor = System.Drawing.Color.White;
        this.btnCreateBackup.Location = new System.Drawing.Point(795, 42);
        this.btnCreateBackup.Name = "btnCreateBackup";
        this.btnCreateBackup.Size = new System.Drawing.Size(235, 42);
        this.btnCreateBackup.TabIndex = 1;
        this.btnCreateBackup.Text = "💾 Créer une Sauvegarde Maintenant";
        this.btnCreateBackup.UseVisualStyleBackColor = false;
        this.btnCreateBackup.Click += new System.EventHandler(this.BtnCreateBackup_Click);
        // 
        // lblBackupDescription
        // 
        this.lblBackupDescription.AutoSize = true;
        this.lblBackupDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblBackupDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
        this.lblBackupDescription.Location = new System.Drawing.Point(20, 42);
        this.lblBackupDescription.Name = "lblBackupDescription";
        this.lblBackupDescription.Size = new System.Drawing.Size(564, 15);
        this.lblBackupDescription.TabIndex = 0;
        this.lblBackupDescription.Text = "Génère un instantané consistant de la base SQLite active, sans interrompre les ventes ni les consultations.";
        // 
        // grpExistingBackups
        // 
        this.grpExistingBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.grpExistingBackups.BackColor = System.Drawing.Color.White;
        this.grpExistingBackups.Controls.Add(this.lblRestoreWarning);
        this.grpExistingBackups.Controls.Add(this.btnRestoreBackup);
        this.grpExistingBackups.Controls.Add(this.dgvBackups);
        this.grpExistingBackups.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.grpExistingBackups.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
        this.grpExistingBackups.Location = new System.Drawing.Point(25, 215);
        this.grpExistingBackups.Name = "grpExistingBackups";
        this.grpExistingBackups.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
        this.grpExistingBackups.Size = new System.Drawing.Size(1050, 415);
        this.grpExistingBackups.TabIndex = 2;
        this.grpExistingBackups.TabStop = false;
        this.grpExistingBackups.Text = "Sauvegardes Existantes & Restauration";
        // 
        // lblRestoreWarning
        // 
        this.lblRestoreWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.lblRestoreWarning.AutoSize = true;
        this.lblRestoreWarning.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular);
        this.lblRestoreWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
        this.lblRestoreWarning.Location = new System.Drawing.Point(20, 375);
        this.lblRestoreWarning.Name = "lblRestoreWarning";
        this.lblRestoreWarning.Size = new System.Drawing.Size(588, 15);
        this.lblRestoreWarning.TabIndex = 2;
        this.lblRestoreWarning.Text = "⚠️ Attention : La restauration remplace intégralement la base courante. Une sauvegarde de précaution est créée.";
        // 
        // btnRestoreBackup
        // 
        this.btnRestoreBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRestoreBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
        this.btnRestoreBackup.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnRestoreBackup.Enabled = false;
        this.btnRestoreBackup.FlatAppearance.BorderSize = 0;
        this.btnRestoreBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRestoreBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnRestoreBackup.ForeColor = System.Drawing.Color.White;
        this.btnRestoreBackup.Location = new System.Drawing.Point(825, 365);
        this.btnRestoreBackup.Name = "btnRestoreBackup";
        this.btnRestoreBackup.Size = new System.Drawing.Size(205, 36);
        this.btnRestoreBackup.TabIndex = 1;
        this.btnRestoreBackup.Text = "⚠️ Restaurer la Sélection";
        this.btnRestoreBackup.UseVisualStyleBackColor = false;
        this.btnRestoreBackup.Click += new System.EventHandler(this.BtnRestoreBackup_Click);
        // 
        // dgvBackups
        // 
        this.dgvBackups.AllowUserToAddRows = false;
        this.dgvBackups.AllowUserToDeleteRows = false;
        this.dgvBackups.AllowUserToResizeRows = false;
        this.dgvBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvBackups.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.dgvBackups.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvBackups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvBackups.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvBackups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvBackups.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvBackups.EnableHeadersVisualStyles = false;
        this.dgvBackups.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
        this.dgvBackups.Location = new System.Drawing.Point(20, 35);
        this.dgvBackups.MultiSelect = false;
        this.dgvBackups.Name = "dgvBackups";
        this.dgvBackups.ReadOnly = true;
        this.dgvBackups.RowHeadersVisible = false;
        this.dgvBackups.RowTemplate.Height = 32;
        this.dgvBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvBackups.Size = new System.Drawing.Size(1010, 315);
        this.dgvBackups.TabIndex = 0;
        this.dgvBackups.SelectionChanged += new System.EventHandler(this.DgvBackups_SelectionChanged);
        // 
        // BackupControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.Controls.Add(this.grpExistingBackups);
        this.Controls.Add(this.grpImmediateBackup);
        this.Controls.Add(this.pnlHeader);
        this.Name = "BackupControl";
        this.Size = new System.Drawing.Size(1100, 650);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.grpImmediateBackup.ResumeLayout(false);
        this.grpImmediateBackup.PerformLayout();
        this.grpExistingBackups.ResumeLayout(false);
        this.grpExistingBackups.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
        this.ResumeLayout(false);
    }
}
