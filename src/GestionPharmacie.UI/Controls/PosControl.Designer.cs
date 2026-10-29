namespace GestionPharmacie.UI.Controls;

partial class PosControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Button btnShiftClose;
    private System.Windows.Forms.Panel pnlSearch;
    private System.Windows.Forms.Label lblSearchPrompt;
    private System.Windows.Forms.TextBox txtProductSearch;
    private System.Windows.Forms.ListBox lstSearchResults;
    private System.Windows.Forms.Panel pnlCart;
    private System.Windows.Forms.DataGridView dgvCart;
    private System.Windows.Forms.Panel pnlPayment;
    private System.Windows.Forms.Label lblGrossTotalTitle;
    private System.Windows.Forms.Label lblGrossTotalValue;
    private System.Windows.Forms.Label lblDiscountTitle;
    private System.Windows.Forms.Label lblDiscountValue;
    private System.Windows.Forms.Button btnApplyDiscount;
    private System.Windows.Forms.Label lblNetTotalTitle;
    private System.Windows.Forms.Label lblNetTotalValue;
    private System.Windows.Forms.Label lblPaymentMethod;
    private System.Windows.Forms.RadioButton rdoCash;
    private System.Windows.Forms.RadioButton rdoCard;
    private System.Windows.Forms.RadioButton rdoMobile;
    private System.Windows.Forms.Panel pnlCashSection;
    private System.Windows.Forms.Label lblCashReceived;
    private System.Windows.Forms.NumericUpDown nudCashReceived;
    private System.Windows.Forms.Label lblChangeTitle;
    private System.Windows.Forms.Label lblChangeValue;
    private System.Windows.Forms.Button btnCheckout;
    private System.Windows.Forms.Button btnClearCart;
    private System.Windows.Forms.Label lblFifoBanner;

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
        this.btnShiftClose = new System.Windows.Forms.Button();
        this.lblHeaderSubtitle = new System.Windows.Forms.Label();
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.pnlSearch = new System.Windows.Forms.Panel();
        this.lblFifoBanner = new System.Windows.Forms.Label();
        this.lstSearchResults = new System.Windows.Forms.ListBox();
        this.txtProductSearch = new System.Windows.Forms.TextBox();
        this.lblSearchPrompt = new System.Windows.Forms.Label();
        this.pnlCart = new System.Windows.Forms.Panel();
        this.dgvCart = new System.Windows.Forms.DataGridView();
        this.pnlPayment = new System.Windows.Forms.Panel();
        this.btnClearCart = new System.Windows.Forms.Button();
        this.btnCheckout = new System.Windows.Forms.Button();
        this.pnlCashSection = new System.Windows.Forms.Panel();
        this.lblChangeValue = new System.Windows.Forms.Label();
        this.lblChangeTitle = new System.Windows.Forms.Label();
        this.nudCashReceived = new System.Windows.Forms.NumericUpDown();
        this.lblCashReceived = new System.Windows.Forms.Label();
        this.rdoMobile = new System.Windows.Forms.RadioButton();
        this.rdoCard = new System.Windows.Forms.RadioButton();
        this.rdoCash = new System.Windows.Forms.RadioButton();
        this.lblPaymentMethod = new System.Windows.Forms.Label();
        this.lblNetTotalValue = new System.Windows.Forms.Label();
        this.lblNetTotalTitle = new System.Windows.Forms.Label();
        this.btnApplyDiscount = new System.Windows.Forms.Button();
        this.lblDiscountValue = new System.Windows.Forms.Label();
        this.lblDiscountTitle = new System.Windows.Forms.Label();
        this.lblGrossTotalValue = new System.Windows.Forms.Label();
        this.lblGrossTotalTitle = new System.Windows.Forms.Label();
        this.pnlHeader.SuspendLayout();
        this.pnlSearch.SuspendLayout();
        this.pnlCart.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
        this.pnlPayment.SuspendLayout();
        this.pnlCashSection.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudCashReceived)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.White;
        this.pnlHeader.Controls.Add(this.btnShiftClose);
        this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(25, 12, 25, 10);
        this.pnlHeader.Size = new System.Drawing.Size(1100, 65);
        this.pnlHeader.TabIndex = 0;
        // 
        // btnShiftClose
        // 
        this.btnShiftClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnShiftClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
        this.btnShiftClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnShiftClose.FlatAppearance.BorderSize = 0;
        this.btnShiftClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnShiftClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnShiftClose.ForeColor = System.Drawing.Color.White;
        this.btnShiftClose.Location = new System.Drawing.Point(920, 14);
        this.btnShiftClose.Name = "btnShiftClose";
        this.btnShiftClose.Size = new System.Drawing.Size(155, 36);
        this.btnShiftClose.TabIndex = 2;
        this.btnShiftClose.Text = "📊 Clôture Caisse";
        this.btnShiftClose.UseVisualStyleBackColor = false;
        this.btnShiftClose.Click += new System.EventHandler(this.BtnShiftClose_Click);
        // 
        // lblHeaderSubtitle
        // 
        this.lblHeaderSubtitle.AutoSize = true;
        this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblHeaderSubtitle.Location = new System.Drawing.Point(25, 38);
        this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(465, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Comptoir de vente • Règle FIFO de péremption active • Raccourcis : F2 (Chercher) | F5 (Payer)";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblHeaderTitle.Location = new System.Drawing.Point(23, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(306, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "💳 Terminal Caisse & Ventes (POS)";
        // 
        // pnlSearch
        // 
        this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.pnlSearch.Controls.Add(this.lblFifoBanner);
        this.pnlSearch.Controls.Add(this.lstSearchResults);
        this.pnlSearch.Controls.Add(this.txtProductSearch);
        this.pnlSearch.Controls.Add(this.lblSearchPrompt);
        this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlSearch.Location = new System.Drawing.Point(0, 65);
        this.pnlSearch.Name = "pnlSearch";
        this.pnlSearch.Padding = new System.Windows.Forms.Padding(25, 10, 25, 5);
        this.pnlSearch.Size = new System.Drawing.Size(1100, 110);
        this.pnlSearch.TabIndex = 1;
        // 
        // lblFifoBanner
        // 
        this.lblFifoBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblFifoBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
        this.lblFifoBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblFifoBanner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblFifoBanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(87)))), ((int)(((byte)(36)))));
        this.lblFifoBanner.Location = new System.Drawing.Point(680, 10);
        this.lblFifoBanner.Name = "lblFifoBanner";
        this.lblFifoBanner.Padding = new System.Windows.Forms.Padding(8);
        this.lblFifoBanner.Size = new System.Drawing.Size(395, 85);
        this.lblFifoBanner.TabIndex = 3;
        this.lblFifoBanner.Text = "🛡 RÈGLE FIFO STRICTE EN VIGUEUR :\r\nChaque produit ajouté sélectionne automatiquement en priorité le lot ayant la date d\'expiration la plus proche. Les lots périmés ou bloqués sont exclus.";
        // 
        // lstSearchResults
        // 
        this.lstSearchResults.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lstSearchResults.FormattingEnabled = true;
        this.lstSearchResults.ItemHeight = 17;
        this.lstSearchResults.Location = new System.Drawing.Point(28, 48);
        this.lstSearchResults.Name = "lstSearchResults";
        this.lstSearchResults.Size = new System.Drawing.Size(635, 55);
        this.lstSearchResults.TabIndex = 2;
        this.lstSearchResults.Visible = false;
        this.lstSearchResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstSearchResults_KeyDown);
        this.lstSearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstSearchResults_MouseDoubleClick);
        // 
        // txtProductSearch
        // 
        this.txtProductSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtProductSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.txtProductSearch.Location = new System.Drawing.Point(28, 20);
        this.txtProductSearch.Name = "txtProductSearch";
        this.txtProductSearch.PlaceholderText = "Scannez un code-barres ou saisissez un nom / référence (Entrée pour ajouter)...";
        this.txtProductSearch.Size = new System.Drawing.Size(635, 29);
        this.txtProductSearch.TabIndex = 1;
        this.txtProductSearch.TextChanged += new System.EventHandler(this.TxtProductSearch_TextChanged);
        this.txtProductSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductSearch_KeyDown);
        // 
        // lblSearchPrompt
        // 
        this.lblSearchPrompt.AutoSize = true;
        this.lblSearchPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblSearchPrompt.Location = new System.Drawing.Point(25, 4);
        this.lblSearchPrompt.Name = "lblSearchPrompt";
        this.lblSearchPrompt.Size = new System.Drawing.Size(188, 15);
        this.lblSearchPrompt.TabIndex = 0;
        this.lblSearchPrompt.Text = "Recherche / Scan Médicament :";
        // 
        // pnlCart
        // 
        this.pnlCart.Controls.Add(this.dgvCart);
        this.pnlCart.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCart.Location = new System.Drawing.Point(0, 175);
        this.pnlCart.Name = "pnlCart";
        this.pnlCart.Padding = new System.Windows.Forms.Padding(25, 10, 10, 10);
        this.pnlCart.Size = new System.Drawing.Size(730, 475);
        this.pnlCart.TabIndex = 2;
        // 
        // dgvCart
        // 
        this.dgvCart.AllowUserToAddRows = false;
        this.dgvCart.AllowUserToDeleteRows = false;
        this.dgvCart.AllowUserToResizeRows = false;
        this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCart.BackgroundColor = System.Drawing.Color.White;
        this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvCart.EnableHeadersVisualStyles = false;
        this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
        this.dgvCart.Location = new System.Drawing.Point(25, 10);
        this.dgvCart.MultiSelect = false;
        this.dgvCart.Name = "dgvCart";
        this.dgvCart.RowHeadersVisible = false;
        this.dgvCart.RowTemplate.Height = 36;
        this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvCart.Size = new System.Drawing.Size(695, 455);
        this.dgvCart.TabIndex = 0;
        this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellContentClick);
        this.dgvCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellValueChanged);
        // 
        // pnlPayment
        // 
        this.pnlPayment.BackColor = System.Drawing.Color.White;
        this.pnlPayment.Controls.Add(this.btnClearCart);
        this.pnlPayment.Controls.Add(this.btnCheckout);
        this.pnlPayment.Controls.Add(this.pnlCashSection);
        this.pnlPayment.Controls.Add(this.rdoMobile);
        this.pnlPayment.Controls.Add(this.rdoCard);
        this.pnlPayment.Controls.Add(this.rdoCash);
        this.pnlPayment.Controls.Add(this.lblPaymentMethod);
        this.pnlPayment.Controls.Add(this.lblNetTotalValue);
        this.pnlPayment.Controls.Add(this.lblNetTotalTitle);
        this.pnlPayment.Controls.Add(this.btnApplyDiscount);
        this.pnlPayment.Controls.Add(this.lblDiscountValue);
        this.pnlPayment.Controls.Add(this.lblDiscountTitle);
        this.pnlPayment.Controls.Add(this.lblGrossTotalValue);
        this.pnlPayment.Controls.Add(this.lblGrossTotalTitle);
        this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Right;
        this.pnlPayment.Location = new System.Drawing.Point(730, 175);
        this.pnlPayment.Name = "pnlPayment";
        this.pnlPayment.Padding = new System.Windows.Forms.Padding(20);
        this.pnlPayment.Size = new System.Drawing.Size(370, 475);
        this.pnlPayment.TabIndex = 3;
        // 
        // btnClearCart
        // 
        this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
        this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnClearCart.FlatAppearance.BorderSize = 0;
        this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnClearCart.ForeColor = System.Drawing.Color.Gray;
        this.btnClearCart.Location = new System.Drawing.Point(20, 435);
        this.btnClearCart.Name = "btnClearCart";
        this.btnClearCart.Size = new System.Drawing.Size(330, 26);
        this.btnClearCart.TabIndex = 13;
        this.btnClearCart.Text = "🗑 Vider le panier (Échap)";
        this.btnClearCart.UseVisualStyleBackColor = false;
        this.btnClearCart.Click += new System.EventHandler(this.BtnClearCart_Click);
        // 
        // btnCheckout
        // 
        this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCheckout.FlatAppearance.BorderSize = 0;
        this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnCheckout.ForeColor = System.Drawing.Color.White;
        this.btnCheckout.Location = new System.Drawing.Point(20, 380);
        this.btnCheckout.Name = "btnCheckout";
        this.btnCheckout.Size = new System.Drawing.Size(330, 48);
        this.btnCheckout.TabIndex = 12;
        this.btnCheckout.Text = "💳 Valider & Encaisser (F5)";
        this.btnCheckout.UseVisualStyleBackColor = false;
        this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);
        // 
        // pnlCashSection
        // 
        this.pnlCashSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.pnlCashSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCashSection.Controls.Add(this.lblChangeValue);
        this.pnlCashSection.Controls.Add(this.lblChangeTitle);
        this.pnlCashSection.Controls.Add(this.nudCashReceived);
        this.pnlCashSection.Controls.Add(this.lblCashReceived);
        this.pnlCashSection.Location = new System.Drawing.Point(20, 280);
        this.pnlCashSection.Name = "pnlCashSection";
        this.pnlCashSection.Padding = new System.Windows.Forms.Padding(10);
        this.pnlCashSection.Size = new System.Drawing.Size(330, 90);
        this.pnlCashSection.TabIndex = 11;
        // 
        // lblChangeValue
        // 
        this.lblChangeValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblChangeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblChangeValue.Location = new System.Drawing.Point(170, 45);
        this.lblChangeValue.Name = "lblChangeValue";
        this.lblChangeValue.Size = new System.Drawing.Size(145, 25);
        this.lblChangeValue.TabIndex = 3;
        this.lblChangeValue.Text = "0,00 €";
        this.lblChangeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblChangeTitle
        // 
        this.lblChangeTitle.AutoSize = true;
        this.lblChangeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblChangeTitle.Location = new System.Drawing.Point(170, 15);
        this.lblChangeTitle.Name = "lblChangeTitle";
        this.lblChangeTitle.Size = new System.Drawing.Size(107, 15);
        this.lblChangeTitle.TabIndex = 2;
        this.lblChangeTitle.Text = "Monnaie à rendre :";
        // 
        // nudCashReceived
        // 
        this.nudCashReceived.DecimalPlaces = 2;
        this.nudCashReceived.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.nudCashReceived.Location = new System.Drawing.Point(10, 45);
        this.nudCashReceived.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.nudCashReceived.Name = "nudCashReceived";
        this.nudCashReceived.Size = new System.Drawing.Size(140, 27);
        this.nudCashReceived.TabIndex = 1;
        this.nudCashReceived.ValueChanged += new System.EventHandler(this.NudCashReceived_ValueChanged);
        // 
        // lblCashReceived
        // 
        this.lblCashReceived.AutoSize = true;
        this.lblCashReceived.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblCashReceived.Location = new System.Drawing.Point(10, 15);
        this.lblCashReceived.Name = "lblCashReceived";
        this.lblCashReceived.Size = new System.Drawing.Size(91, 15);
        this.lblCashReceived.TabIndex = 0;
        this.lblCashReceived.Text = "Montant versé :";
        // 
        // rdoMobile
        // 
        this.rdoMobile.AutoSize = true;
        this.rdoMobile.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.rdoMobile.Location = new System.Drawing.Point(235, 245);
        this.rdoMobile.Name = "rdoMobile";
        this.rdoMobile.Size = new System.Drawing.Size(115, 21);
        this.rdoMobile.TabIndex = 10;
        this.rdoMobile.Text = "Paiement Mob.";
        this.rdoMobile.UseVisualStyleBackColor = true;
        this.rdoMobile.CheckedChanged += new System.EventHandler(this.PaymentMethod_Changed);
        // 
        // rdoCard
        // 
        this.rdoCard.AutoSize = true;
        this.rdoCard.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.rdoCard.Location = new System.Drawing.Point(115, 245);
        this.rdoCard.Name = "rdoCard";
        this.rdoCard.Size = new System.Drawing.Size(107, 21);
        this.rdoCard.TabIndex = 9;
        this.rdoCard.Text = "Carte Bancaire";
        this.rdoCard.UseVisualStyleBackColor = true;
        this.rdoCard.CheckedChanged += new System.EventHandler(this.PaymentMethod_Changed);
        // 
        // rdoCash
        // 
        this.rdoCash.AutoSize = true;
        this.rdoCash.Checked = true;
        this.rdoCash.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.rdoCash.Location = new System.Drawing.Point(20, 245);
        this.rdoCash.Name = "rdoCash";
        this.rdoCash.Size = new System.Drawing.Size(73, 21);
        this.rdoCash.TabIndex = 8;
        this.rdoCash.TabStop = true;
        this.rdoCash.Text = "Espèces";
        this.rdoCash.UseVisualStyleBackColor = true;
        this.rdoCash.CheckedChanged += new System.EventHandler(this.PaymentMethod_Changed);
        // 
        // lblPaymentMethod
        // 
        this.lblPaymentMethod.AutoSize = true;
        this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblPaymentMethod.Location = new System.Drawing.Point(20, 220);
        this.lblPaymentMethod.Name = "lblPaymentMethod";
        this.lblPaymentMethod.Size = new System.Drawing.Size(134, 17);
        this.lblPaymentMethod.TabIndex = 7;
        this.lblPaymentMethod.Text = "Mode de règlement :";
        // 
        // lblNetTotalValue
        // 
        this.lblNetTotalValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        this.lblNetTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblNetTotalValue.Location = new System.Drawing.Point(20, 160);
        this.lblNetTotalValue.Name = "lblNetTotalValue";
        this.lblNetTotalValue.Size = new System.Drawing.Size(330, 45);
        this.lblNetTotalValue.TabIndex = 6;
        this.lblNetTotalValue.Text = "0,00 €";
        this.lblNetTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblNetTotalTitle
        // 
        this.lblNetTotalTitle.AutoSize = true;
        this.lblNetTotalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblNetTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.lblNetTotalTitle.Location = new System.Drawing.Point(20, 140);
        this.lblNetTotalTitle.Name = "lblNetTotalTitle";
        this.lblNetTotalTitle.Size = new System.Drawing.Size(161, 20);
        this.lblNetTotalTitle.TabIndex = 5;
        this.lblNetTotalTitle.Text = "TOTAL NET À PAYER :";
        // 
        // btnApplyDiscount
        // 
        this.btnApplyDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(231)))));
        this.btnApplyDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnApplyDiscount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(145)))));
        this.btnApplyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnApplyDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnApplyDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(89)))), ((int)(((byte)(2)))));
        this.btnApplyDiscount.Location = new System.Drawing.Point(20, 95);
        this.btnApplyDiscount.Name = "btnApplyDiscount";
        this.btnApplyDiscount.Size = new System.Drawing.Size(155, 30);
        this.btnApplyDiscount.TabIndex = 4;
        this.btnApplyDiscount.Text = "🏷️ Remise (F4)";
        this.btnApplyDiscount.UseVisualStyleBackColor = false;
        this.btnApplyDiscount.Click += new System.EventHandler(this.BtnApplyDiscount_Click);
        // 
        // lblDiscountValue
        // 
        this.lblDiscountValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblDiscountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
        this.lblDiscountValue.Location = new System.Drawing.Point(180, 58);
        this.lblDiscountValue.Name = "lblDiscountValue";
        this.lblDiscountValue.Size = new System.Drawing.Size(170, 25);
        this.lblDiscountValue.TabIndex = 3;
        this.lblDiscountValue.Text = "0,00 €";
        this.lblDiscountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblDiscountTitle
        // 
        this.lblDiscountTitle.AutoSize = true;
        this.lblDiscountTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblDiscountTitle.Location = new System.Drawing.Point(20, 62);
        this.lblDiscountTitle.Name = "lblDiscountTitle";
        this.lblDiscountTitle.Size = new System.Drawing.Size(117, 17);
        this.lblDiscountTitle.TabIndex = 2;
        this.lblDiscountTitle.Text = "Remise accordée :";
        // 
        // lblGrossTotalValue
        // 
        this.lblGrossTotalValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblGrossTotalValue.Location = new System.Drawing.Point(180, 23);
        this.lblGrossTotalValue.Name = "lblGrossTotalValue";
        this.lblGrossTotalValue.Size = new System.Drawing.Size(170, 25);
        this.lblGrossTotalValue.TabIndex = 1;
        this.lblGrossTotalValue.Text = "0,00 €";
        this.lblGrossTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblGrossTotalTitle
        // 
        this.lblGrossTotalTitle.AutoSize = true;
        this.lblGrossTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblGrossTotalTitle.Location = new System.Drawing.Point(20, 27);
        this.lblGrossTotalTitle.Name = "lblGrossTotalTitle";
        this.lblGrossTotalTitle.Size = new System.Drawing.Size(107, 17);
        this.lblGrossTotalTitle.TabIndex = 0;
        this.lblGrossTotalTitle.Text = "Sous-total Brut :";
        // 
        // PosControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.Controls.Add(this.pnlCart);
        this.Controls.Add(this.pnlPayment);
        this.Controls.Add(this.pnlSearch);
        this.Controls.Add(this.pnlHeader);
        this.Name = "PosControl";
        this.Size = new System.Drawing.Size(1100, 650);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlSearch.ResumeLayout(false);
        this.pnlSearch.PerformLayout();
        this.pnlCart.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
        this.pnlPayment.ResumeLayout(false);
        this.pnlPayment.PerformLayout();
        this.pnlCashSection.ResumeLayout(false);
        this.pnlCashSection.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudCashReceived)).EndInit();
        this.ResumeLayout(false);
    }
}
