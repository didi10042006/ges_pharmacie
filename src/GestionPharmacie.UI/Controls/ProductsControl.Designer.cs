namespace GestionPharmacie.UI.Controls;

partial class ProductsControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Panel pnlFilterBar;
    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Label lblCategoryFilter;
    private System.Windows.Forms.ComboBox cboCategoryFilter;
    private System.Windows.Forms.CheckBox chkIncludeArchived;
    private System.Windows.Forms.Button btnNewProduct;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.DataGridView dgvProducts;
    private System.Windows.Forms.Panel pnlBottomActions;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnToggleArchive;
    private System.Windows.Forms.Label lblStats;

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
        this.lblHeaderSubtitle = new System.Windows.Forms.Label();
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.pnlFilterBar = new System.Windows.Forms.Panel();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.btnNewProduct = new System.Windows.Forms.Button();
        this.chkIncludeArchived = new System.Windows.Forms.CheckBox();
        this.cboCategoryFilter = new System.Windows.Forms.ComboBox();
        this.lblCategoryFilter = new System.Windows.Forms.Label();
        this.txtSearch = new System.Windows.Forms.TextBox();
        this.lblSearch = new System.Windows.Forms.Label();
        this.dgvProducts = new System.Windows.Forms.DataGridView();
        this.pnlBottomActions = new System.Windows.Forms.Panel();
        this.lblStats = new System.Windows.Forms.Label();
        this.btnToggleArchive = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnEdit = new System.Windows.Forms.Button();
        this.pnlHeader.SuspendLayout();
        this.pnlFilterBar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
        this.pnlBottomActions.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.White;
        this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
        this.pnlHeader.Size = new System.Drawing.Size(1000, 65);
        this.pnlHeader.TabIndex = 0;
        // 
        // lblHeaderSubtitle
        // 
        this.lblHeaderSubtitle.AutoSize = true;
        this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblHeaderSubtitle.Location = new System.Drawing.Point(25, 38);
        this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(434, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Gestion du catalogue officiel, vérification des références et niveaux d'approvisionnement";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblHeaderTitle.Location = new System.Drawing.Point(23, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(347, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "💊 Catalogue Médicaments & Produits";
        // 
        // pnlFilterBar
        // 
        this.pnlFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.pnlFilterBar.Controls.Add(this.btnRefresh);
        this.pnlFilterBar.Controls.Add(this.btnNewProduct);
        this.pnlFilterBar.Controls.Add(this.chkIncludeArchived);
        this.pnlFilterBar.Controls.Add(this.cboCategoryFilter);
        this.pnlFilterBar.Controls.Add(this.lblCategoryFilter);
        this.pnlFilterBar.Controls.Add(this.txtSearch);
        this.pnlFilterBar.Controls.Add(this.lblSearch);
        this.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlFilterBar.Location = new System.Drawing.Point(0, 65);
        this.pnlFilterBar.Name = "pnlFilterBar";
        this.pnlFilterBar.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
        this.pnlFilterBar.Size = new System.Drawing.Size(1000, 55);
        this.pnlFilterBar.TabIndex = 1;
        // 
        // btnRefresh
        // 
        this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRefresh.BackColor = System.Drawing.Color.White;
        this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
        this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnRefresh.Location = new System.Drawing.Point(685, 12);
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Size = new System.Drawing.Size(115, 30);
        this.btnRefresh.TabIndex = 6;
        this.btnRefresh.Text = "🔄 Actualiser";
        this.btnRefresh.UseVisualStyleBackColor = false;
        this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
        // 
        // btnNewProduct
        // 
        this.btnNewProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnNewProduct.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNewProduct.FlatAppearance.BorderSize = 0;
        this.btnNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNewProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnNewProduct.ForeColor = System.Drawing.Color.White;
        this.btnNewProduct.Location = new System.Drawing.Point(810, 12);
        this.btnNewProduct.Name = "btnNewProduct";
        this.btnNewProduct.Size = new System.Drawing.Size(165, 30);
        this.btnNewProduct.TabIndex = 5;
        this.btnNewProduct.Text = "➕ Nouveau Produit";
        this.btnNewProduct.UseVisualStyleBackColor = false;
        this.btnNewProduct.Click += new System.EventHandler(this.BtnNewProduct_Click);
        // 
        // chkIncludeArchived
        // 
        this.chkIncludeArchived.AutoSize = true;
        this.chkIncludeArchived.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.chkIncludeArchived.Location = new System.Drawing.Point(525, 17);
        this.chkIncludeArchived.Name = "chkIncludeArchived";
        this.chkIncludeArchived.Size = new System.Drawing.Size(130, 21);
        this.chkIncludeArchived.TabIndex = 4;
        this.chkIncludeArchived.Text = "Afficher archivés";
        this.chkIncludeArchived.UseVisualStyleBackColor = true;
        this.chkIncludeArchived.CheckedChanged += new System.EventHandler(this.Filter_Changed);
        // 
        // cboCategoryFilter
        // 
        this.cboCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboCategoryFilter.FormattingEnabled = true;
        this.cboCategoryFilter.Location = new System.Drawing.Point(365, 15);
        this.cboCategoryFilter.Name = "cboCategoryFilter";
        this.cboCategoryFilter.Size = new System.Drawing.Size(145, 24);
        this.cboCategoryFilter.TabIndex = 3;
        this.cboCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
        // 
        // lblCategoryFilter
        // 
        this.lblCategoryFilter.AutoSize = true;
        this.lblCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblCategoryFilter.Location = new System.Drawing.Point(295, 18);
        this.lblCategoryFilter.Name = "lblCategoryFilter";
        this.lblCategoryFilter.Size = new System.Drawing.Size(72, 17);
        this.lblCategoryFilter.TabIndex = 2;
        this.lblCategoryFilter.Text = "Catégorie :";
        // 
        // txtSearch
        // 
        this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtSearch.Location = new System.Drawing.Point(100, 15);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.PlaceholderText = "Nom ou référence...";
        this.txtSearch.Size = new System.Drawing.Size(180, 24);
        this.txtSearch.TabIndex = 1;
        this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
        // 
        // lblSearch
        // 
        this.lblSearch.AutoSize = true;
        this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblSearch.Location = new System.Drawing.Point(25, 18);
        this.lblSearch.Name = "lblSearch";
        this.lblSearch.Size = new System.Drawing.Size(76, 17);
        this.lblSearch.TabIndex = 0;
        this.lblSearch.Text = "Recherche :";
        // 
        // dgvProducts
        // 
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.AllowUserToDeleteRows = false;
        this.dgvProducts.AllowUserToResizeRows = false;
        this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
        this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvProducts.EnableHeadersVisualStyles = false;
        this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
        this.dgvProducts.Location = new System.Drawing.Point(0, 120);
        this.dgvProducts.MultiSelect = false;
        this.dgvProducts.Name = "dgvProducts";
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.RowHeadersVisible = false;
        this.dgvProducts.RowTemplate.Height = 36;
        this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.Size = new System.Drawing.Size(1000, 480);
        this.dgvProducts.TabIndex = 2;
        this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProducts_CellDoubleClick);
        this.dgvProducts.SelectionChanged += new System.EventHandler(this.DgvProducts_SelectionChanged);
        // 
        // pnlBottomActions
        // 
        this.pnlBottomActions.BackColor = System.Drawing.Color.White;
        this.pnlBottomActions.Controls.Add(this.lblStats);
        this.pnlBottomActions.Controls.Add(this.btnToggleArchive);
        this.pnlBottomActions.Controls.Add(this.btnDelete);
        this.pnlBottomActions.Controls.Add(this.btnEdit);
        this.pnlBottomActions.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlBottomActions.Location = new System.Drawing.Point(0, 600);
        this.pnlBottomActions.Name = "pnlBottomActions";
        this.pnlBottomActions.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
        this.pnlBottomActions.Size = new System.Drawing.Size(1000, 50);
        this.pnlBottomActions.TabIndex = 3;
        // 
        // lblStats
        // 
        this.lblStats.AutoSize = true;
        this.lblStats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblStats.Location = new System.Drawing.Point(25, 16);
        this.lblStats.Name = "lblStats";
        this.lblStats.Size = new System.Drawing.Size(147, 17);
        this.lblStats.TabIndex = 3;
        this.lblStats.Text = "Total : 0 produit(s) listé(s)";
        // 
        // btnToggleArchive
        // 
        this.btnToggleArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnToggleArchive.BackColor = System.Drawing.Color.White;
        this.btnToggleArchive.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnToggleArchive.Enabled = false;
        this.btnToggleArchive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
        this.btnToggleArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnToggleArchive.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnToggleArchive.Location = new System.Drawing.Point(620, 10);
        this.btnToggleArchive.Name = "btnToggleArchive";
        this.btnToggleArchive.Size = new System.Drawing.Size(140, 30);
        this.btnToggleArchive.TabIndex = 2;
        this.btnToggleArchive.Text = "📁 Archiver / Activer";
        this.btnToggleArchive.UseVisualStyleBackColor = false;
        this.btnToggleArchive.Click += new System.EventHandler(this.BtnToggleArchive_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
        this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnDelete.Enabled = false;
        this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
        this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.btnDelete.Location = new System.Drawing.Point(770, 10);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(110, 30);
        this.btnDelete.TabIndex = 1;
        this.btnDelete.Text = "🗑 Supprimer";
        this.btnDelete.UseVisualStyleBackColor = false;
        this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
        this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnEdit.Enabled = false;
        this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
        this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
        this.btnEdit.Location = new System.Drawing.Point(890, 10);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new System.Drawing.Size(95, 30);
        this.btnEdit.TabIndex = 0;
        this.btnEdit.Text = "✏️ Modifier";
        this.btnEdit.UseVisualStyleBackColor = false;
        this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
        // 
        // ProductsControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.Controls.Add(this.dgvProducts);
        this.Controls.Add(this.pnlBottomActions);
        this.Controls.Add(this.pnlFilterBar);
        this.Controls.Add(this.pnlHeader);
        this.Name = "ProductsControl";
        this.Size = new System.Drawing.Size(1000, 650);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFilterBar.ResumeLayout(false);
        this.pnlFilterBar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
        this.pnlBottomActions.ResumeLayout(false);
        this.pnlBottomActions.PerformLayout();
        this.ResumeLayout(false);
    }
}
