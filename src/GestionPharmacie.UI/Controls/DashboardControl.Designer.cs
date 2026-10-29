namespace GestionPharmacie.UI.Controls;

partial class DashboardControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.TableLayoutPanel tblKpis;
    private System.Windows.Forms.Panel pnlKpiSales;
    private System.Windows.Forms.Label lblKpiSalesTitle;
    private System.Windows.Forms.Label lblKpiSalesValue;
    private System.Windows.Forms.Label lblKpiSalesSub;
    private System.Windows.Forms.Panel pnlKpiOutOfStock;
    private System.Windows.Forms.Label lblKpiOutOfStockTitle;
    private System.Windows.Forms.Label lblKpiOutOfStockValue;
    private System.Windows.Forms.Label lblKpiOutOfStockSub;
    private System.Windows.Forms.Panel pnlKpiLowStock;
    private System.Windows.Forms.Label lblKpiLowStockTitle;
    private System.Windows.Forms.Label lblKpiLowStockValue;
    private System.Windows.Forms.Label lblKpiLowStockSub;
    private System.Windows.Forms.Panel pnlKpiExpiring;
    private System.Windows.Forms.Label lblKpiExpiringTitle;
    private System.Windows.Forms.Label lblKpiExpiringValue;
    private System.Windows.Forms.Label lblKpiExpiringSub;
    private System.Windows.Forms.SplitContainer splitAlerts;
    private System.Windows.Forms.GroupBox grpStockAlerts;
    private System.Windows.Forms.DataGridView dgvStockAlerts;
    private System.Windows.Forms.GroupBox grpExpiryAlerts;
    private System.Windows.Forms.DataGridView dgvExpiryAlerts;

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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.lblHeaderSubtitle = new System.Windows.Forms.Label();
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.tblKpis = new System.Windows.Forms.TableLayoutPanel();
        this.pnlKpiExpiring = new System.Windows.Forms.Panel();
        this.lblKpiExpiringSub = new System.Windows.Forms.Label();
        this.lblKpiExpiringValue = new System.Windows.Forms.Label();
        this.lblKpiExpiringTitle = new System.Windows.Forms.Label();
        this.pnlKpiLowStock = new System.Windows.Forms.Panel();
        this.lblKpiLowStockSub = new System.Windows.Forms.Label();
        this.lblKpiLowStockValue = new System.Windows.Forms.Label();
        this.lblKpiLowStockTitle = new System.Windows.Forms.Label();
        this.pnlKpiOutOfStock = new System.Windows.Forms.Panel();
        this.lblKpiOutOfStockSub = new System.Windows.Forms.Label();
        this.lblKpiOutOfStockValue = new System.Windows.Forms.Label();
        this.lblKpiOutOfStockTitle = new System.Windows.Forms.Label();
        this.pnlKpiSales = new System.Windows.Forms.Panel();
        this.lblKpiSalesSub = new System.Windows.Forms.Label();
        this.lblKpiSalesValue = new System.Windows.Forms.Label();
        this.lblKpiSalesTitle = new System.Windows.Forms.Label();
        this.splitAlerts = new System.Windows.Forms.SplitContainer();
        this.grpStockAlerts = new System.Windows.Forms.GroupBox();
        this.dgvStockAlerts = new System.Windows.Forms.DataGridView();
        this.grpExpiryAlerts = new System.Windows.Forms.GroupBox();
        this.dgvExpiryAlerts = new System.Windows.Forms.DataGridView();
        this.pnlHeader.SuspendLayout();
        this.tblKpis.SuspendLayout();
        this.pnlKpiExpiring.SuspendLayout();
        this.pnlKpiLowStock.SuspendLayout();
        this.pnlKpiOutOfStock.SuspendLayout();
        this.pnlKpiSales.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitAlerts)).BeginInit();
        this.splitAlerts.Panel1.SuspendLayout();
        this.splitAlerts.Panel2.SuspendLayout();
        this.splitAlerts.SuspendLayout();
        this.grpStockAlerts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvStockAlerts)).BeginInit();
        this.grpExpiryAlerts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvExpiryAlerts)).BeginInit();
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
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(434, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Indicateurs clés du jour, surveillance des ruptures et alertes péremption imminente";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblHeaderTitle.Location = new System.Drawing.Point(23, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(343, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "📊 Tableau de Bord & Alertes Sanitaires";
        // 
        // tblKpis
        // 
        this.tblKpis.ColumnCount = 4;
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tblKpis.Controls.Add(this.pnlKpiExpiring, 3, 0);
        this.tblKpis.Controls.Add(this.pnlKpiLowStock, 2, 0);
        this.tblKpis.Controls.Add(this.pnlKpiOutOfStock, 1, 0);
        this.tblKpis.Controls.Add(this.pnlKpiSales, 0, 0);
        this.tblKpis.Dock = System.Windows.Forms.DockStyle.Top;
        this.tblKpis.Location = new System.Drawing.Point(0, 65);
        this.tblKpis.Name = "tblKpis";
        this.tblKpis.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
        this.tblKpis.RowCount = 1;
        this.tblKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblKpis.Size = new System.Drawing.Size(1100, 125);
        this.tblKpis.TabIndex = 1;
        // 
        // pnlKpiExpiring
        // 
        this.pnlKpiExpiring.BackColor = System.Drawing.Color.White;
        this.pnlKpiExpiring.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlKpiExpiring.Controls.Add(this.lblKpiExpiringSub);
        this.pnlKpiExpiring.Controls.Add(this.lblKpiExpiringValue);
        this.pnlKpiExpiring.Controls.Add(this.lblKpiExpiringTitle);
        this.pnlKpiExpiring.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlKpiExpiring.Location = new System.Drawing.Point(818, 18);
        this.pnlKpiExpiring.Name = "pnlKpiExpiring";
        this.pnlKpiExpiring.Padding = new System.Windows.Forms.Padding(12);
        this.pnlKpiExpiring.Size = new System.Drawing.Size(259, 94);
        this.pnlKpiExpiring.TabIndex = 3;
        // 
        // lblKpiExpiringSub
        // 
        this.lblKpiExpiringSub.AutoSize = true;
        this.lblKpiExpiringSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblKpiExpiringSub.ForeColor = System.Drawing.Color.Gray;
        this.lblKpiExpiringSub.Location = new System.Drawing.Point(12, 65);
        this.lblKpiExpiringSub.Name = "lblKpiExpiringSub";
        this.lblKpiExpiringSub.Size = new System.Drawing.Size(129, 15);
        this.lblKpiExpiringSub.TabIndex = 2;
        this.lblKpiExpiringSub.Text = "0 lot(s) déjà périmé(s)";
        // 
        // lblKpiExpiringValue
        // 
        this.lblKpiExpiringValue.AutoSize = true;
        this.lblKpiExpiringValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblKpiExpiringValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
        this.lblKpiExpiringValue.Location = new System.Drawing.Point(10, 28);
        this.lblKpiExpiringValue.Name = "lblKpiExpiringValue";
        this.lblKpiExpiringValue.Size = new System.Drawing.Size(28, 32);
        this.lblKpiExpiringValue.TabIndex = 1;
        this.lblKpiExpiringValue.Text = "0";
        // 
        // lblKpiExpiringTitle
        // 
        this.lblKpiExpiringTitle.AutoSize = true;
        this.lblKpiExpiringTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblKpiExpiringTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
        this.lblKpiExpiringTitle.Location = new System.Drawing.Point(12, 10);
        this.lblKpiExpiringTitle.Name = "lblKpiExpiringTitle";
        this.lblKpiExpiringTitle.Size = new System.Drawing.Size(161, 15);
        this.lblKpiExpiringTitle.TabIndex = 0;
        this.lblKpiExpiringTitle.Text = "⏰ PÉREMPTION (< 90j)";
        // 
        // pnlKpiLowStock
        // 
        this.pnlKpiLowStock.BackColor = System.Drawing.Color.White;
        this.pnlKpiLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlKpiLowStock.Controls.Add(this.lblKpiLowStockSub);
        this.pnlKpiLowStock.Controls.Add(this.lblKpiLowStockValue);
        this.pnlKpiLowStock.Controls.Add(this.lblKpiLowStockTitle);
        this.pnlKpiLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlKpiLowStock.Location = new System.Drawing.Point(553, 18);
        this.pnlKpiLowStock.Name = "pnlKpiLowStock";
        this.pnlKpiLowStock.Padding = new System.Windows.Forms.Padding(12);
        this.pnlKpiLowStock.Size = new System.Drawing.Size(259, 94);
        this.pnlKpiLowStock.TabIndex = 2;
        // 
        // lblKpiLowStockSub
        // 
        this.lblKpiLowStockSub.AutoSize = true;
        this.lblKpiLowStockSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblKpiLowStockSub.ForeColor = System.Drawing.Color.Gray;
        this.lblKpiLowStockSub.Location = new System.Drawing.Point(12, 65);
        this.lblKpiLowStockSub.Name = "lblKpiLowStockSub";
        this.lblKpiLowStockSub.Size = new System.Drawing.Size(130, 15);
        this.lblKpiLowStockSub.TabIndex = 2;
        this.lblKpiLowStockSub.Text = "Réapprovisionner vite";
        // 
        // lblKpiLowStockValue
        // 
        this.lblKpiLowStockValue.AutoSize = true;
        this.lblKpiLowStockValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblKpiLowStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
        this.lblKpiLowStockValue.Location = new System.Drawing.Point(10, 28);
        this.lblKpiLowStockValue.Name = "lblKpiLowStockValue";
        this.lblKpiLowStockValue.Size = new System.Drawing.Size(28, 32);
        this.lblKpiLowStockValue.TabIndex = 1;
        this.lblKpiLowStockValue.Text = "0";
        // 
        // lblKpiLowStockTitle
        // 
        this.lblKpiLowStockTitle.AutoSize = true;
        this.lblKpiLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblKpiLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
        this.lblKpiLowStockTitle.Location = new System.Drawing.Point(12, 10);
        this.lblKpiLowStockTitle.Name = "lblKpiLowStockTitle";
        this.lblKpiLowStockTitle.Size = new System.Drawing.Size(139, 15);
        this.lblKpiLowStockTitle.TabIndex = 0;
        this.lblKpiLowStockTitle.Text = "⚠️ SOUS LE SEUIL MIN";
        // 
        // pnlKpiOutOfStock
        // 
        this.pnlKpiOutOfStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
        this.pnlKpiOutOfStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlKpiOutOfStock.Controls.Add(this.lblKpiOutOfStockSub);
        this.pnlKpiOutOfStock.Controls.Add(this.lblKpiOutOfStockValue);
        this.pnlKpiOutOfStock.Controls.Add(this.lblKpiOutOfStockTitle);
        this.pnlKpiOutOfStock.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlKpiOutOfStock.Location = new System.Drawing.Point(288, 18);
        this.pnlKpiOutOfStock.Name = "pnlKpiOutOfStock";
        this.pnlKpiOutOfStock.Padding = new System.Windows.Forms.Padding(12);
        this.pnlKpiOutOfStock.Size = new System.Drawing.Size(259, 94);
        this.pnlKpiOutOfStock.TabIndex = 1;
        // 
        // lblKpiOutOfStockSub
        // 
        this.lblKpiOutOfStockSub.AutoSize = true;
        this.lblKpiOutOfStockSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblKpiOutOfStockSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
        this.lblKpiOutOfStockSub.Location = new System.Drawing.Point(12, 65);
        this.lblKpiOutOfStockSub.Name = "lblKpiOutOfStockSub";
        this.lblKpiOutOfStockSub.Size = new System.Drawing.Size(149, 15);
        this.lblKpiOutOfStockSub.TabIndex = 2;
        this.lblKpiOutOfStockSub.Text = "Vente impossible en caisse";
        // 
        // lblKpiOutOfStockValue
        // 
        this.lblKpiOutOfStockValue.AutoSize = true;
        this.lblKpiOutOfStockValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblKpiOutOfStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
        this.lblKpiOutOfStockValue.Location = new System.Drawing.Point(10, 28);
        this.lblKpiOutOfStockValue.Name = "lblKpiOutOfStockValue";
        this.lblKpiOutOfStockValue.Size = new System.Drawing.Size(28, 32);
        this.lblKpiOutOfStockValue.TabIndex = 1;
        this.lblKpiOutOfStockValue.Text = "0";
        // 
        // lblKpiOutOfStockTitle
        // 
        this.lblKpiOutOfStockTitle.AutoSize = true;
        this.lblKpiOutOfStockTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblKpiOutOfStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
        this.lblKpiOutOfStockTitle.Location = new System.Drawing.Point(12, 10);
        this.lblKpiOutOfStockTitle.Name = "lblKpiOutOfStockTitle";
        this.lblKpiOutOfStockTitle.Size = new System.Drawing.Size(155, 15);
        this.lblKpiOutOfStockTitle.TabIndex = 0;
        this.lblKpiOutOfStockTitle.Text = "🚨 RUPTURES DE STOCK";
        // 
        // pnlKpiSales
        // 
        this.pnlKpiSales.BackColor = System.Drawing.Color.White;
        this.pnlKpiSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlKpiSales.Controls.Add(this.lblKpiSalesSub);
        this.pnlKpiSales.Controls.Add(this.lblKpiSalesValue);
        this.pnlKpiSales.Controls.Add(this.lblKpiSalesTitle);
        this.pnlKpiSales.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlKpiSales.Location = new System.Drawing.Point(23, 18);
        this.pnlKpiSales.Name = "pnlKpiSales";
        this.pnlKpiSales.Padding = new System.Windows.Forms.Padding(12);
        this.pnlKpiSales.Size = new System.Drawing.Size(259, 94);
        this.pnlKpiSales.TabIndex = 0;
        // 
        // lblKpiSalesSub
        // 
        this.lblKpiSalesSub.AutoSize = true;
        this.lblKpiSalesSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblKpiSalesSub.ForeColor = System.Drawing.Color.Gray;
        this.lblKpiSalesSub.Location = new System.Drawing.Point(12, 65);
        this.lblKpiSalesSub.Name = "lblKpiSalesSub";
        this.lblKpiSalesSub.Size = new System.Drawing.Size(107, 15);
        this.lblKpiSalesSub.TabIndex = 2;
        this.lblKpiSalesSub.Text = "0 transaction(s)";
        // 
        // lblKpiSalesValue
        // 
        this.lblKpiSalesValue.AutoSize = true;
        this.lblKpiSalesValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblKpiSalesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblKpiSalesValue.Location = new System.Drawing.Point(10, 28);
        this.lblKpiSalesValue.Name = "lblKpiSalesValue";
        this.lblKpiSalesValue.Size = new System.Drawing.Size(83, 32);
        this.lblKpiSalesValue.TabIndex = 1;
        this.lblKpiSalesValue.Text = "0,00 €";
        // 
        // lblKpiSalesTitle
        // 
        this.lblKpiSalesTitle.AutoSize = true;
        this.lblKpiSalesTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblKpiSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
        this.lblKpiSalesTitle.Location = new System.Drawing.Point(12, 10);
        this.lblKpiSalesTitle.Name = "lblKpiSalesTitle";
        this.lblKpiSalesTitle.Size = new System.Drawing.Size(130, 15);
        this.lblKpiSalesTitle.TabIndex = 0;
        this.lblKpiSalesTitle.Text = "💳 VENTES DU JOUR";
        // 
        // splitAlerts
        // 
        this.splitAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitAlerts.Location = new System.Drawing.Point(0, 190);
        this.splitAlerts.Name = "splitAlerts";
        // 
        // splitAlerts.Panel1
        // 
        this.splitAlerts.Panel1.Controls.Add(this.grpStockAlerts);
        this.splitAlerts.Panel1.Padding = new System.Windows.Forms.Padding(20, 10, 10, 20);
        // 
        // splitAlerts.Panel2
        // 
        this.splitAlerts.Panel2.Controls.Add(this.grpExpiryAlerts);
        this.splitAlerts.Panel2.Padding = new System.Windows.Forms.Padding(10, 10, 20, 20);
        this.splitAlerts.Size = new System.Drawing.Size(1100, 460);
        this.splitAlerts.SplitterDistance = 550;
        this.splitAlerts.TabIndex = 2;
        // 
        // grpStockAlerts
        // 
        this.grpStockAlerts.BackColor = System.Drawing.Color.White;
        this.grpStockAlerts.Controls.Add(this.dgvStockAlerts);
        this.grpStockAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpStockAlerts.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpStockAlerts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.grpStockAlerts.Location = new System.Drawing.Point(20, 10);
        this.grpStockAlerts.Name = "grpStockAlerts";
        this.grpStockAlerts.Padding = new System.Windows.Forms.Padding(10);
        this.grpStockAlerts.Size = new System.Drawing.Size(520, 430);
        this.grpStockAlerts.TabIndex = 0;
        this.grpStockAlerts.TabStop = false;
        this.grpStockAlerts.Text = "⚠️ Alertes Niveaux de Stock (Ruptures & Seuil)";
        // 
        // dgvStockAlerts
        // 
        this.dgvStockAlerts.AllowUserToAddRows = false;
        this.dgvStockAlerts.AllowUserToDeleteRows = false;
        this.dgvStockAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStockAlerts.BackgroundColor = System.Drawing.Color.White;
        this.dgvStockAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvStockAlerts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvStockAlerts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvStockAlerts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvStockAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvStockAlerts.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvStockAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvStockAlerts.EnableHeadersVisualStyles = false;
        this.dgvStockAlerts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.dgvStockAlerts.Location = new System.Drawing.Point(10, 27);
        this.dgvStockAlerts.MultiSelect = false;
        this.dgvStockAlerts.Name = "dgvStockAlerts";
        this.dgvStockAlerts.ReadOnly = true;
        this.dgvStockAlerts.RowHeadersVisible = false;
        this.dgvStockAlerts.RowTemplate.Height = 32;
        this.dgvStockAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvStockAlerts.Size = new System.Drawing.Size(500, 393);
        this.dgvStockAlerts.TabIndex = 0;
        // 
        // grpExpiryAlerts
        // 
        this.grpExpiryAlerts.BackColor = System.Drawing.Color.White;
        this.grpExpiryAlerts.Controls.Add(this.dgvExpiryAlerts);
        this.grpExpiryAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpExpiryAlerts.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpExpiryAlerts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.grpExpiryAlerts.Location = new System.Drawing.Point(10, 10);
        this.grpExpiryAlerts.Name = "grpExpiryAlerts";
        this.grpExpiryAlerts.Padding = new System.Windows.Forms.Padding(10);
        this.grpExpiryAlerts.Size = new System.Drawing.Size(516, 430);
        this.grpExpiryAlerts.TabIndex = 1;
        this.grpExpiryAlerts.TabStop = false;
        this.grpExpiryAlerts.Text = "⏰ Alertes Dates d'Expiration des Lots";
        // 
        // dgvExpiryAlerts
        // 
        this.dgvExpiryAlerts.AllowUserToAddRows = false;
        this.dgvExpiryAlerts.AllowUserToDeleteRows = false;
        this.dgvExpiryAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvExpiryAlerts.BackgroundColor = System.Drawing.Color.White;
        this.dgvExpiryAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvExpiryAlerts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvExpiryAlerts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvExpiryAlerts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
        this.dgvExpiryAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
        dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
        dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvExpiryAlerts.DefaultCellStyle = dataGridViewCellStyle4;
        this.dgvExpiryAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvExpiryAlerts.EnableHeadersVisualStyles = false;
        this.dgvExpiryAlerts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.dgvExpiryAlerts.Location = new System.Drawing.Point(10, 27);
        this.dgvExpiryAlerts.MultiSelect = false;
        this.dgvExpiryAlerts.Name = "dgvExpiryAlerts";
        this.dgvExpiryAlerts.ReadOnly = true;
        this.dgvExpiryAlerts.RowHeadersVisible = false;
        this.dgvExpiryAlerts.RowTemplate.Height = 32;
        this.dgvExpiryAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvExpiryAlerts.Size = new System.Drawing.Size(496, 393);
        this.dgvExpiryAlerts.TabIndex = 0;
        // 
        // DashboardControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.Controls.Add(this.splitAlerts);
        this.Controls.Add(this.tblKpis);
        this.Controls.Add(this.pnlHeader);
        this.Name = "DashboardControl";
        this.Size = new System.Drawing.Size(1100, 650);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.tblKpis.ResumeLayout(false);
        this.pnlKpiExpiring.ResumeLayout(false);
        this.pnlKpiExpiring.PerformLayout();
        this.pnlKpiLowStock.ResumeLayout(false);
        this.pnlKpiLowStock.PerformLayout();
        this.pnlKpiOutOfStock.ResumeLayout(false);
        this.pnlKpiOutOfStock.PerformLayout();
        this.pnlKpiSales.ResumeLayout(false);
        this.pnlKpiSales.PerformLayout();
        this.splitAlerts.Panel1.ResumeLayout(false);
        this.splitAlerts.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitAlerts)).EndInit();
        this.splitAlerts.ResumeLayout(false);
        this.grpStockAlerts.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvStockAlerts)).EndInit();
        this.grpExpiryAlerts.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvExpiryAlerts)).EndInit();
        this.ResumeLayout(false);
    }
}
