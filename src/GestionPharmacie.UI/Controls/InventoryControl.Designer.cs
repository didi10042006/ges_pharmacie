namespace GestionPharmacie.UI.Controls;

partial class InventoryControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Button btnExportCsv;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Panel pnlFilter;
    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.CheckBox chkIncludeZeroStock;
    private System.Windows.Forms.DataGridView dgvLots;
    private System.Windows.Forms.GroupBox grpAdjustment;
    private System.Windows.Forms.Label lblSelectedLotInfo;
    private System.Windows.Forms.Label lblPhysicalCount;
    private System.Windows.Forms.NumericUpDown nudPhysicalCount;
    private System.Windows.Forms.Label lblDiscrepancyTitle;
    private System.Windows.Forms.Label lblDiscrepancyValue;
    private System.Windows.Forms.Label lblReason;
    private System.Windows.Forms.ComboBox cboReason;
    private System.Windows.Forms.Button btnApplyAdjustment;
    private System.Windows.Forms.Button btnToggleBlock;

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
        this.btnExportCsv = new System.Windows.Forms.Button();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.lblHeaderSubtitle = new System.Windows.Forms.Label();
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.pnlFilter = new System.Windows.Forms.Panel();
        this.chkIncludeZeroStock = new System.Windows.Forms.CheckBox();
        this.txtSearch = new System.Windows.Forms.TextBox();
        this.lblSearch = new System.Windows.Forms.Label();
        this.dgvLots = new System.Windows.Forms.DataGridView();
        this.grpAdjustment = new System.Windows.Forms.GroupBox();
        this.btnToggleBlock = new System.Windows.Forms.Button();
        this.btnApplyAdjustment = new System.Windows.Forms.Button();
        this.cboReason = new System.Windows.Forms.ComboBox();
        this.lblReason = new System.Windows.Forms.Label();
        this.lblDiscrepancyValue = new System.Windows.Forms.Label();
        this.lblDiscrepancyTitle = new System.Windows.Forms.Label();
        this.nudPhysicalCount = new System.Windows.Forms.NumericUpDown();
        this.lblPhysicalCount = new System.Windows.Forms.Label();
        this.lblSelectedLotInfo = new System.Windows.Forms.Label();
        this.pnlHeader.SuspendLayout();
        this.pnlFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLots)).BeginInit();
        this.grpAdjustment.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudPhysicalCount)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.White;
        this.pnlHeader.Controls.Add(this.btnExportCsv);
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
        // btnExportCsv
        // 
        this.btnExportCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnExportCsv.BackColor = System.Drawing.Color.White;
        this.btnExportCsv.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnExportCsv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
        this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnExportCsv.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnExportCsv.Location = new System.Drawing.Point(825, 15);
        this.btnExportCsv.Name = "btnExportCsv";
        this.btnExportCsv.Size = new System.Drawing.Size(130, 32);
        this.btnExportCsv.TabIndex = 3;
        this.btnExportCsv.Text = "📥 Exporter CSV";
        this.btnExportCsv.UseVisualStyleBackColor = false;
        this.btnExportCsv.Click += new System.EventHandler(this.BtnExportCsv_Click);
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
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(466, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Comptage physique des lots, calcul des écarts, justification obligatoire et blocage de lot";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblHeaderTitle.Location = new System.Drawing.Point(23, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(350, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "📦 Gestion des Inventaires & Ajustements";
        // 
        // pnlFilter
        // 
        this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.pnlFilter.Controls.Add(this.chkIncludeZeroStock);
        this.pnlFilter.Controls.Add(this.txtSearch);
        this.pnlFilter.Controls.Add(this.lblSearch);
        this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlFilter.Location = new System.Drawing.Point(0, 65);
        this.pnlFilter.Name = "pnlFilter";
        this.pnlFilter.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
        this.pnlFilter.Size = new System.Drawing.Size(1100, 50);
        this.pnlFilter.TabIndex = 1;
        // 
        // chkIncludeZeroStock
        // 
        this.chkIncludeZeroStock.AutoSize = true;
        this.chkIncludeZeroStock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.chkIncludeZeroStock.Location = new System.Drawing.Point(400, 15);
        this.chkIncludeZeroStock.Name = "chkIncludeZeroStock";
        this.chkIncludeZeroStock.Size = new System.Drawing.Size(175, 21);
        this.chkIncludeZeroStock.TabIndex = 2;
        this.chkIncludeZeroStock.Text = "Afficher les lots épuisés (0)";
        this.chkIncludeZeroStock.UseVisualStyleBackColor = true;
        this.chkIncludeZeroStock.CheckedChanged += new System.EventHandler(this.Filter_Changed);
        // 
        // txtSearch
        // 
        this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtSearch.Location = new System.Drawing.Point(135, 13);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.PlaceholderText = "Filtrer par médicament, référence ou N° lot...";
        this.txtSearch.Size = new System.Drawing.Size(245, 24);
        this.txtSearch.TabIndex = 1;
        this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
        // 
        // lblSearch
        // 
        this.lblSearch.AutoSize = true;
        this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblSearch.Location = new System.Drawing.Point(25, 15);
        this.lblSearch.Name = "lblSearch";
        this.lblSearch.Size = new System.Drawing.Size(104, 17);
        this.lblSearch.TabIndex = 0;
        this.lblSearch.Text = "Rechercher un lot :";
        // 
        // dgvLots
        // 
        this.dgvLots.AllowUserToAddRows = false;
        this.dgvLots.AllowUserToDeleteRows = false;
        this.dgvLots.AllowUserToResizeRows = false;
        this.dgvLots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvLots.BackgroundColor = System.Drawing.Color.White;
        this.dgvLots.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvLots.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvLots.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvLots.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvLots.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvLots.EnableHeadersVisualStyles = false;
        this.dgvLots.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
        this.dgvLots.Location = new System.Drawing.Point(25, 125);
        this.dgvLots.MultiSelect = false;
        this.dgvLots.Name = "dgvLots";
        this.dgvLots.ReadOnly = true;
        this.dgvLots.RowHeadersVisible = false;
        this.dgvLots.RowTemplate.Height = 34;
        this.dgvLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvLots.Size = new System.Drawing.Size(1050, 360);
        this.dgvLots.TabIndex = 2;
        this.dgvLots.SelectionChanged += new System.EventHandler(this.DgvLots_SelectionChanged);
        // 
        // grpAdjustment
        // 
        this.grpAdjustment.BackColor = System.Drawing.Color.White;
        this.grpAdjustment.Controls.Add(this.btnToggleBlock);
        this.grpAdjustment.Controls.Add(this.btnApplyAdjustment);
        this.grpAdjustment.Controls.Add(this.cboReason);
        this.grpAdjustment.Controls.Add(this.lblReason);
        this.grpAdjustment.Controls.Add(this.lblDiscrepancyValue);
        this.grpAdjustment.Controls.Add(this.lblDiscrepancyTitle);
        this.grpAdjustment.Controls.Add(this.nudPhysicalCount);
        this.grpAdjustment.Controls.Add(this.lblPhysicalCount);
        this.grpAdjustment.Controls.Add(this.lblSelectedLotInfo);
        this.grpAdjustment.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.grpAdjustment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpAdjustment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.grpAdjustment.Location = new System.Drawing.Point(0, 495);
        this.grpAdjustment.Name = "grpAdjustment";
        this.grpAdjustment.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
        this.grpAdjustment.Size = new System.Drawing.Size(1100, 155);
        this.grpAdjustment.TabIndex = 3;
        this.grpAdjustment.TabStop = false;
        this.grpAdjustment.Text = "Saisie d'Ajustement sur le Lot Sélectionné";
        // 
        // btnToggleBlock
        // 
        this.btnToggleBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnToggleBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
        this.btnToggleBlock.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnToggleBlock.Enabled = false;
        this.btnToggleBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
        this.btnToggleBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnToggleBlock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnToggleBlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
        this.btnToggleBlock.Location = new System.Drawing.Point(680, 100);
        this.btnToggleBlock.Name = "btnToggleBlock";
        this.btnToggleBlock.Size = new System.Drawing.Size(170, 36);
        this.btnToggleBlock.TabIndex = 8;
        this.btnToggleBlock.Text = "🔒 Bloquer ce Lot";
        this.btnToggleBlock.UseVisualStyleBackColor = false;
        this.btnToggleBlock.Click += new System.EventHandler(this.BtnToggleBlock_Click);
        // 
        // btnApplyAdjustment
        // 
        this.btnApplyAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnApplyAdjustment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnApplyAdjustment.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnApplyAdjustment.Enabled = false;
        this.btnApplyAdjustment.FlatAppearance.BorderSize = 0;
        this.btnApplyAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnApplyAdjustment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnApplyAdjustment.ForeColor = System.Drawing.Color.White;
        this.btnApplyAdjustment.Location = new System.Drawing.Point(860, 100);
        this.btnApplyAdjustment.Name = "btnApplyAdjustment";
        this.btnApplyAdjustment.Size = new System.Drawing.Size(215, 36);
        this.btnApplyAdjustment.TabIndex = 7;
        this.btnApplyAdjustment.Text = "💾 Enregistrer Ajustement";
        this.btnApplyAdjustment.UseVisualStyleBackColor = false;
        this.btnApplyAdjustment.Click += new System.EventHandler(this.BtnApplyAdjustment_Click);
        // 
        // cboReason
        // 
        this.cboReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboReason.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboReason.FormattingEnabled = true;
        this.cboReason.Items.AddRange(new object[] {
            "Inventaire physique annuel / tournant",
            "Casse / Avarie en rayon",
            "Périmé / Retiré du stock",
            "Vol / Démarque inconnue",
            "Retour fournisseur",
            "Erreur de saisie antérieure"});
        this.cboReason.Location = new System.Drawing.Point(280, 107);
        this.cboReason.Name = "cboReason";
        this.cboReason.Size = new System.Drawing.Size(320, 24);
        this.cboReason.TabIndex = 6;
        // 
        // lblReason
        // 
        this.lblReason.AutoSize = true;
        this.lblReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblReason.Location = new System.Drawing.Point(277, 85);
        this.lblReason.Name = "lblReason";
        this.lblReason.Size = new System.Drawing.Size(182, 15);
        this.lblReason.TabIndex = 5;
        this.lblReason.Text = "Motif obligatoire de l\'ajustement :";
        // 
        // lblDiscrepancyValue
        // 
        this.lblDiscrepancyValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblDiscrepancyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblDiscrepancyValue.Location = new System.Drawing.Point(150, 107);
        this.lblDiscrepancyValue.Name = "lblDiscrepancyValue";
        this.lblDiscrepancyValue.Size = new System.Drawing.Size(100, 24);
        this.lblDiscrepancyValue.TabIndex = 4;
        this.lblDiscrepancyValue.Text = "0";
        this.lblDiscrepancyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblDiscrepancyTitle
        // 
        this.lblDiscrepancyTitle.AutoSize = true;
        this.lblDiscrepancyTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblDiscrepancyTitle.Location = new System.Drawing.Point(150, 85);
        this.lblDiscrepancyTitle.Name = "lblDiscrepancyTitle";
        this.lblDiscrepancyTitle.Size = new System.Drawing.Size(81, 15);
        this.lblDiscrepancyTitle.TabIndex = 3;
        this.lblDiscrepancyTitle.Text = "Écart calculé :";
        // 
        // nudPhysicalCount
        // 
        this.nudPhysicalCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.nudPhysicalCount.Location = new System.Drawing.Point(25, 107);
        this.nudPhysicalCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.nudPhysicalCount.Name = "nudPhysicalCount";
        this.nudPhysicalCount.Size = new System.Drawing.Size(105, 25);
        this.nudPhysicalCount.TabIndex = 2;
        this.nudPhysicalCount.ValueChanged += new System.EventHandler(this.NudPhysicalCount_ValueChanged);
        // 
        // lblPhysicalCount
        // 
        this.lblPhysicalCount.AutoSize = true;
        this.lblPhysicalCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblPhysicalCount.Location = new System.Drawing.Point(22, 85);
        this.lblPhysicalCount.Name = "lblPhysicalCount";
        this.lblPhysicalCount.Size = new System.Drawing.Size(123, 15);
        this.lblPhysicalCount.TabIndex = 1;
        this.lblPhysicalCount.Text = "Stock physique réel :";
        // 
        // lblSelectedLotInfo
        // 
        this.lblSelectedLotInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.lblSelectedLotInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblSelectedLotInfo.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblSelectedLotInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblSelectedLotInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
        this.lblSelectedLotInfo.Location = new System.Drawing.Point(20, 28);
        this.lblSelectedLotInfo.Name = "lblSelectedLotInfo";
        this.lblSelectedLotInfo.Padding = new System.Windows.Forms.Padding(10);
        this.lblSelectedLotInfo.Size = new System.Drawing.Size(1060, 42);
        this.lblSelectedLotInfo.TabIndex = 0;
        this.lblSelectedLotInfo.Text = "Sélectionnez un lot dans la grille ci-dessus pour effectuer un inventaire ou un ajustement.";
        this.lblSelectedLotInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // InventoryControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.Controls.Add(this.dgvLots);
        this.Controls.Add(this.grpAdjustment);
        this.Controls.Add(this.pnlFilter);
        this.Controls.Add(this.pnlHeader);
        this.Name = "InventoryControl";
        this.Size = new System.Drawing.Size(1100, 650);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFilter.ResumeLayout(false);
        this.pnlFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLots)).EndInit();
        this.grpAdjustment.ResumeLayout(false);
        this.grpAdjustment.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudPhysicalCount)).EndInit();
        this.ResumeLayout(false);
    }
}
