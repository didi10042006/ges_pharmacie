namespace GestionPharmacie.UI.Controls;

partial class StockEntryControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.GroupBox grpDocument;
    private System.Windows.Forms.Label lblSupplier;
    private System.Windows.Forms.ComboBox cboSupplier;
    private System.Windows.Forms.Label lblDocNumber;
    private System.Windows.Forms.TextBox txtDocNumber;
    private System.Windows.Forms.Label lblReceptionDate;
    private System.Windows.Forms.DateTimePicker dtpReceptionDate;
    private System.Windows.Forms.GroupBox grpLineInput;
    private System.Windows.Forms.Label lblProduct;
    private System.Windows.Forms.ComboBox cboProduct;
    private System.Windows.Forms.Label lblLotNumber;
    private System.Windows.Forms.TextBox txtLotNumber;
    private System.Windows.Forms.Label lblExpiryDate;
    private System.Windows.Forms.DateTimePicker dtpExpiryDate;
    private System.Windows.Forms.Label lblQuantity;
    private System.Windows.Forms.NumericUpDown nudQuantity;
    private System.Windows.Forms.Label lblPurchaseCost;
    private System.Windows.Forms.NumericUpDown nudPurchaseCost;
    private System.Windows.Forms.Button btnAddLine;
    private System.Windows.Forms.DataGridView dgvLines;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Label lblTotalSummary;
    private System.Windows.Forms.Button btnSubmitReception;
    private System.Windows.Forms.Button btnClear;

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
        this.grpDocument = new System.Windows.Forms.GroupBox();
        this.dtpReceptionDate = new System.Windows.Forms.DateTimePicker();
        this.lblReceptionDate = new System.Windows.Forms.Label();
        this.txtDocNumber = new System.Windows.Forms.TextBox();
        this.lblDocNumber = new System.Windows.Forms.Label();
        this.cboSupplier = new System.Windows.Forms.ComboBox();
        this.lblSupplier = new System.Windows.Forms.Label();
        this.grpLineInput = new System.Windows.Forms.GroupBox();
        this.btnAddLine = new System.Windows.Forms.Button();
        this.nudPurchaseCost = new System.Windows.Forms.NumericUpDown();
        this.lblPurchaseCost = new System.Windows.Forms.Label();
        this.nudQuantity = new System.Windows.Forms.NumericUpDown();
        this.lblQuantity = new System.Windows.Forms.Label();
        this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
        this.lblExpiryDate = new System.Windows.Forms.Label();
        this.txtLotNumber = new System.Windows.Forms.TextBox();
        this.lblLotNumber = new System.Windows.Forms.Label();
        this.cboProduct = new System.Windows.Forms.ComboBox();
        this.lblProduct = new System.Windows.Forms.Label();
        this.dgvLines = new System.Windows.Forms.DataGridView();
        this.pnlFooter = new System.Windows.Forms.Panel();
        this.btnClear = new System.Windows.Forms.Button();
        this.btnSubmitReception = new System.Windows.Forms.Button();
        this.lblTotalSummary = new System.Windows.Forms.Label();
        this.pnlHeader.SuspendLayout();
        this.grpDocument.SuspendLayout();
        this.grpLineInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudPurchaseCost)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
        this.pnlFooter.SuspendLayout();
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
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(438, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Enregistrement atomique des livraisons fournisseurs et traçabilité des numéros de lots";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblHeaderTitle.Location = new System.Drawing.Point(23, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(414, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "📥 Approvisionnement & Entrée de Stock (Lots)";
        // 
        // grpDocument
        // 
        this.grpDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.grpDocument.BackColor = System.Drawing.Color.White;
        this.grpDocument.Controls.Add(this.dtpReceptionDate);
        this.grpDocument.Controls.Add(this.lblReceptionDate);
        this.grpDocument.Controls.Add(this.txtDocNumber);
        this.grpDocument.Controls.Add(this.lblDocNumber);
        this.grpDocument.Controls.Add(this.cboSupplier);
        this.grpDocument.Controls.Add(this.lblSupplier);
        this.grpDocument.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpDocument.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.grpDocument.Location = new System.Drawing.Point(25, 75);
        this.grpDocument.Name = "grpDocument";
        this.grpDocument.Size = new System.Drawing.Size(950, 75);
        this.grpDocument.TabIndex = 1;
        this.grpDocument.TabStop = false;
        this.grpDocument.Text = "1. Informations du Document de Livraison";
        // 
        // dtpReceptionDate
        // 
        this.dtpReceptionDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.dtpReceptionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpReceptionDate.Location = new System.Drawing.Point(700, 32);
        this.dtpReceptionDate.Name = "dtpReceptionDate";
        this.dtpReceptionDate.Size = new System.Drawing.Size(150, 24);
        this.dtpReceptionDate.TabIndex = 5;
        // 
        // lblReceptionDate
        // 
        this.lblReceptionDate.AutoSize = true;
        this.lblReceptionDate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblReceptionDate.Location = new System.Drawing.Point(595, 36);
        this.lblReceptionDate.Name = "lblReceptionDate";
        this.lblReceptionDate.Size = new System.Drawing.Size(99, 15);
        this.lblReceptionDate.TabIndex = 4;
        this.lblReceptionDate.Text = "Date de réception :";
        // 
        // txtDocNumber
        // 
        this.txtDocNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtDocNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtDocNumber.Location = new System.Drawing.Point(410, 32);
        this.txtDocNumber.MaxLength = 50;
        this.txtDocNumber.Name = "txtDocNumber";
        this.txtDocNumber.PlaceholderText = "ex: BL-2026-9041";
        this.txtDocNumber.Size = new System.Drawing.Size(160, 24);
        this.txtDocNumber.TabIndex = 3;
        // 
        // lblDocNumber
        // 
        this.lblDocNumber.AutoSize = true;
        this.lblDocNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblDocNumber.Location = new System.Drawing.Point(315, 36);
        this.lblDocNumber.Name = "lblDocNumber";
        this.lblDocNumber.Size = new System.Drawing.Size(89, 15);
        this.lblDocNumber.TabIndex = 2;
        this.lblDocNumber.Text = "N° BL / Facture :";
        // 
        // cboSupplier
        // 
        this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboSupplier.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboSupplier.FormattingEnabled = true;
        this.cboSupplier.Location = new System.Drawing.Point(95, 32);
        this.cboSupplier.Name = "cboSupplier";
        this.cboSupplier.Size = new System.Drawing.Size(200, 24);
        this.cboSupplier.TabIndex = 1;
        // 
        // lblSupplier
        // 
        this.lblSupplier.AutoSize = true;
        this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSupplier.Location = new System.Drawing.Point(15, 36);
        this.lblSupplier.Name = "lblSupplier";
        this.lblSupplier.Size = new System.Drawing.Size(74, 15);
        this.lblSupplier.TabIndex = 0;
        this.lblSupplier.Text = "Fournisseur :";
        // 
        // grpLineInput
        // 
        this.grpLineInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.grpLineInput.BackColor = System.Drawing.Color.White;
        this.grpLineInput.Controls.Add(this.btnAddLine);
        this.grpLineInput.Controls.Add(this.nudPurchaseCost);
        this.grpLineInput.Controls.Add(this.lblPurchaseCost);
        this.grpLineInput.Controls.Add(this.nudQuantity);
        this.grpLineInput.Controls.Add(this.lblQuantity);
        this.grpLineInput.Controls.Add(this.dtpExpiryDate);
        this.grpLineInput.Controls.Add(this.lblExpiryDate);
        this.grpLineInput.Controls.Add(this.txtLotNumber);
        this.grpLineInput.Controls.Add(this.lblLotNumber);
        this.grpLineInput.Controls.Add(this.cboProduct);
        this.grpLineInput.Controls.Add(this.lblProduct);
        this.grpLineInput.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpLineInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.grpLineInput.Location = new System.Drawing.Point(25, 160);
        this.grpLineInput.Name = "grpLineInput";
        this.grpLineInput.Size = new System.Drawing.Size(950, 95);
        this.grpLineInput.TabIndex = 2;
        this.grpLineInput.TabStop = false;
        this.grpLineInput.Text = "2. Saisie d'une Ligne de Lot Reçu";
        // 
        // btnAddLine
        // 
        this.btnAddLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnAddLine.FlatAppearance.BorderSize = 0;
        this.btnAddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAddLine.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnAddLine.ForeColor = System.Drawing.Color.White;
        this.btnAddLine.Location = new System.Drawing.Point(825, 45);
        this.btnAddLine.Name = "btnAddLine";
        this.btnAddLine.Size = new System.Drawing.Size(110, 30);
        this.btnAddLine.TabIndex = 10;
        this.btnAddLine.Text = "➕ Ajouter Lot";
        this.btnAddLine.UseVisualStyleBackColor = false;
        this.btnAddLine.Click += new System.EventHandler(this.BtnAddLine_Click);
        // 
        // nudPurchaseCost
        // 
        this.nudPurchaseCost.DecimalPlaces = 2;
        this.nudPurchaseCost.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.nudPurchaseCost.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
        this.nudPurchaseCost.Location = new System.Drawing.Point(715, 48);
        this.nudPurchaseCost.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.nudPurchaseCost.Name = "nudPurchaseCost";
        this.nudPurchaseCost.Size = new System.Drawing.Size(95, 24);
        this.nudPurchaseCost.TabIndex = 9;
        this.nudPurchaseCost.Value = new decimal(new int[] { 150, 0, 0, 131072 });
        // 
        // lblPurchaseCost
        // 
        this.lblPurchaseCost.AutoSize = true;
        this.lblPurchaseCost.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblPurchaseCost.Location = new System.Drawing.Point(712, 28);
        this.lblPurchaseCost.Name = "lblPurchaseCost";
        this.lblPurchaseCost.Size = new System.Drawing.Size(89, 15);
        this.lblPurchaseCost.TabIndex = 8;
        this.lblPurchaseCost.Text = "Coût Achat TTC :";
        // 
        // nudQuantity
        // 
        this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.nudQuantity.Location = new System.Drawing.Point(615, 48);
        this.nudQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.nudQuantity.Name = "nudQuantity";
        this.nudQuantity.Size = new System.Drawing.Size(85, 24);
        this.nudQuantity.TabIndex = 7;
        this.nudQuantity.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // lblQuantity
        // 
        this.lblQuantity.AutoSize = true;
        this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblQuantity.Location = new System.Drawing.Point(612, 28);
        this.lblQuantity.Name = "lblQuantity";
        this.lblQuantity.Size = new System.Drawing.Size(59, 15);
        this.lblQuantity.TabIndex = 6;
        this.lblQuantity.Text = "Quantité :";
        // 
        // dtpExpiryDate
        // 
        this.dtpExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpExpiryDate.Location = new System.Drawing.Point(475, 48);
        this.dtpExpiryDate.Name = "dtpExpiryDate";
        this.dtpExpiryDate.Size = new System.Drawing.Size(125, 24);
        this.dtpExpiryDate.TabIndex = 5;
        // 
        // lblExpiryDate
        // 
        this.lblExpiryDate.AutoSize = true;
        this.lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblExpiryDate.Location = new System.Drawing.Point(472, 28);
        this.lblExpiryDate.Name = "lblExpiryDate";
        this.lblExpiryDate.Size = new System.Drawing.Size(95, 15);
        this.lblExpiryDate.TabIndex = 4;
        this.lblExpiryDate.Text = "Date péremption :";
        // 
        // txtLotNumber
        // 
        this.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtLotNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtLotNumber.Location = new System.Drawing.Point(315, 48);
        this.txtLotNumber.MaxLength = 50;
        this.txtLotNumber.Name = "txtLotNumber";
        this.txtLotNumber.PlaceholderText = "ex: LOT-2026-A1";
        this.txtLotNumber.Size = new System.Drawing.Size(145, 24);
        this.txtLotNumber.TabIndex = 3;
        // 
        // lblLotNumber
        // 
        this.lblLotNumber.AutoSize = true;
        this.lblLotNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblLotNumber.Location = new System.Drawing.Point(312, 28);
        this.lblLotNumber.Name = "lblLotNumber";
        this.lblLotNumber.Size = new System.Drawing.Size(84, 15);
        this.lblLotNumber.TabIndex = 2;
        this.lblLotNumber.Text = "Numéro de lot :";
        // 
        // cboProduct
        // 
        this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboProduct.FormattingEnabled = true;
        this.cboProduct.Location = new System.Drawing.Point(15, 48);
        this.cboProduct.Name = "cboProduct";
        this.cboProduct.Size = new System.Drawing.Size(285, 24);
        this.cboProduct.TabIndex = 1;
        // 
        // lblProduct
        // 
        this.lblProduct.AutoSize = true;
        this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblProduct.Location = new System.Drawing.Point(12, 28);
        this.lblProduct.Name = "lblProduct";
        this.lblProduct.Size = new System.Drawing.Size(125, 15);
        this.lblProduct.TabIndex = 0;
        this.lblProduct.Text = "Médicament / Produit :";
        // 
        // dgvLines
        // 
        this.dgvLines.AllowUserToAddRows = false;
        this.dgvLines.AllowUserToDeleteRows = false;
        this.dgvLines.AllowUserToResizeRows = false;
        this.dgvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvLines.BackgroundColor = System.Drawing.Color.White;
        this.dgvLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvLines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvLines.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvLines.EnableHeadersVisualStyles = false;
        this.dgvLines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
        this.dgvLines.Location = new System.Drawing.Point(25, 265);
        this.dgvLines.MultiSelect = false;
        this.dgvLines.Name = "dgvLines";
        this.dgvLines.ReadOnly = true;
        this.dgvLines.RowHeadersVisible = false;
        this.dgvLines.RowTemplate.Height = 34;
        this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvLines.Size = new System.Drawing.Size(950, 315);
        this.dgvLines.TabIndex = 3;
        this.dgvLines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLines_CellContentClick);
        // 
        // pnlFooter
        // 
        this.pnlFooter.BackColor = System.Drawing.Color.White;
        this.pnlFooter.Controls.Add(this.btnClear);
        this.pnlFooter.Controls.Add(this.btnSubmitReception);
        this.pnlFooter.Controls.Add(this.lblTotalSummary);
        this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlFooter.Location = new System.Drawing.Point(0, 590);
        this.pnlFooter.Name = "pnlFooter";
        this.pnlFooter.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
        this.pnlFooter.Size = new System.Drawing.Size(1000, 60);
        this.pnlFooter.TabIndex = 4;
        // 
        // btnClear
        // 
        this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
        this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnClear.FlatAppearance.BorderSize = 0;
        this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnClear.Location = new System.Drawing.Point(625, 12);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(115, 36);
        this.btnClear.TabIndex = 2;
        this.btnClear.Text = "Effacer tout";
        this.btnClear.UseVisualStyleBackColor = false;
        this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
        // 
        // btnSubmitReception
        // 
        this.btnSubmitReception.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSubmitReception.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnSubmitReception.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnSubmitReception.FlatAppearance.BorderSize = 0;
        this.btnSubmitReception.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSubmitReception.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnSubmitReception.ForeColor = System.Drawing.Color.White;
        this.btnSubmitReception.Location = new System.Drawing.Point(750, 12);
        this.btnSubmitReception.Name = "btnSubmitReception";
        this.btnSubmitReception.Size = new System.Drawing.Size(225, 36);
        this.btnSubmitReception.TabIndex = 1;
        this.btnSubmitReception.Text = "💾 Valider Réception Stock";
        this.btnSubmitReception.UseVisualStyleBackColor = false;
        this.btnSubmitReception.Click += new System.EventHandler(this.BtnSubmitReception_Click);
        // 
        // lblTotalSummary
        // 
        this.lblTotalSummary.AutoSize = true;
        this.lblTotalSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblTotalSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
        this.lblTotalSummary.Location = new System.Drawing.Point(25, 18);
        this.lblTotalSummary.Name = "lblTotalSummary";
        this.lblTotalSummary.Size = new System.Drawing.Size(351, 20);
        this.lblTotalSummary.TabIndex = 0;
        this.lblTotalSummary.Text = "Lots en attente : 0 | Quantité : 0 | Montant : 0,00 €";
        // 
        // StockEntryControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.Controls.Add(this.pnlFooter);
        this.Controls.Add(this.dgvLines);
        this.Controls.Add(this.grpLineInput);
        this.Controls.Add(this.grpDocument);
        this.Controls.Add(this.pnlHeader);
        this.Name = "StockEntryControl";
        this.Size = new System.Drawing.Size(1000, 650);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.grpDocument.ResumeLayout(false);
        this.grpDocument.PerformLayout();
        this.grpLineInput.ResumeLayout(false);
        this.grpLineInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudPurchaseCost)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
        this.pnlFooter.ResumeLayout(false);
        this.pnlFooter.PerformLayout();
        this.ResumeLayout(false);
    }
}
