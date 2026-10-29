namespace GestionPharmacie.UI.Controls;

partial class ReportsControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Button btnExportCsv;
    private System.Windows.Forms.Button btnRefresh;

    private System.Windows.Forms.Panel pnlFilter;
    private System.Windows.Forms.Label lblStartDate;
    private System.Windows.Forms.DateTimePicker dtpStartDate;
    private System.Windows.Forms.Label lblEndDate;
    private System.Windows.Forms.DateTimePicker dtpEndDate;
    private System.Windows.Forms.Button btnFilter;
    private System.Windows.Forms.Button btnQuickToday;
    private System.Windows.Forms.Button btnQuickThisMonth;
    private System.Windows.Forms.Button btnQuickThisYear;

    private System.Windows.Forms.Panel pnlKpis;
    private System.Windows.Forms.TableLayoutPanel tblKpis;
    private System.Windows.Forms.Panel cardGrossRevenue;
    private System.Windows.Forms.Label lblCardGrossRevenueTitle;
    private System.Windows.Forms.Label lblCardGrossRevenueValue;
    private System.Windows.Forms.Panel cardNetRevenue;
    private System.Windows.Forms.Label lblCardNetRevenueTitle;
    private System.Windows.Forms.Label lblCardNetRevenueValue;
    private System.Windows.Forms.Panel cardPurchaseCost;
    private System.Windows.Forms.Label lblCardPurchaseCostTitle;
    private System.Windows.Forms.Label lblCardPurchaseCostValue;
    private System.Windows.Forms.Panel cardGrossMargin;
    private System.Windows.Forms.Label lblCardGrossMarginTitle;
    private System.Windows.Forms.Label lblCardGrossMarginValue;
    private System.Windows.Forms.Panel cardMarginRate;
    private System.Windows.Forms.Label lblCardMarginRateTitle;
    private System.Windows.Forms.Label lblCardMarginRateValue;

    private System.Windows.Forms.DataGridView dgvProductMargins;

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
        this.btnQuickThisYear = new System.Windows.Forms.Button();
        this.btnQuickThisMonth = new System.Windows.Forms.Button();
        this.btnQuickToday = new System.Windows.Forms.Button();
        this.btnFilter = new System.Windows.Forms.Button();
        this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
        this.lblEndDate = new System.Windows.Forms.Label();
        this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
        this.lblStartDate = new System.Windows.Forms.Label();
        this.pnlKpis = new System.Windows.Forms.Panel();
        this.tblKpis = new System.Windows.Forms.TableLayoutPanel();
        this.cardGrossRevenue = new System.Windows.Forms.Panel();
        this.lblCardGrossRevenueValue = new System.Windows.Forms.Label();
        this.lblCardGrossRevenueTitle = new System.Windows.Forms.Label();
        this.cardNetRevenue = new System.Windows.Forms.Panel();
        this.lblCardNetRevenueValue = new System.Windows.Forms.Label();
        this.lblCardNetRevenueTitle = new System.Windows.Forms.Label();
        this.cardPurchaseCost = new System.Windows.Forms.Panel();
        this.lblCardPurchaseCostValue = new System.Windows.Forms.Label();
        this.lblCardPurchaseCostTitle = new System.Windows.Forms.Label();
        this.cardGrossMargin = new System.Windows.Forms.Panel();
        this.lblCardGrossMarginValue = new System.Windows.Forms.Label();
        this.lblCardGrossMarginTitle = new System.Windows.Forms.Label();
        this.cardMarginRate = new System.Windows.Forms.Panel();
        this.lblCardMarginRateValue = new System.Windows.Forms.Label();
        this.lblCardMarginRateTitle = new System.Windows.Forms.Label();
        this.dgvProductMargins = new System.Windows.Forms.DataGridView();
        this.pnlHeader.SuspendLayout();
        this.pnlFilter.SuspendLayout();
        this.pnlKpis.SuspendLayout();
        this.tblKpis.SuspendLayout();
        this.cardGrossRevenue.SuspendLayout();
        this.cardNetRevenue.SuspendLayout();
        this.cardPurchaseCost.SuspendLayout();
        this.cardGrossMargin.SuspendLayout();
        this.cardMarginRate.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProductMargins)).BeginInit();
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
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(434, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Analyse de rentabilité des ventes et calcul de la marge brute par produit/lot";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblHeaderTitle.Location = new System.Drawing.Point(23, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(262, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "📈 Rapports & Marges Brutes";
        // 
        // pnlFilter
        // 
        this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.pnlFilter.Controls.Add(this.btnQuickThisYear);
        this.pnlFilter.Controls.Add(this.btnQuickThisMonth);
        this.pnlFilter.Controls.Add(this.btnQuickToday);
        this.pnlFilter.Controls.Add(this.btnFilter);
        this.pnlFilter.Controls.Add(this.dtpEndDate);
        this.pnlFilter.Controls.Add(this.lblEndDate);
        this.pnlFilter.Controls.Add(this.dtpStartDate);
        this.pnlFilter.Controls.Add(this.lblStartDate);
        this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlFilter.Location = new System.Drawing.Point(0, 65);
        this.pnlFilter.Name = "pnlFilter";
        this.pnlFilter.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
        this.pnlFilter.Size = new System.Drawing.Size(1100, 52);
        this.pnlFilter.TabIndex = 1;
        // 
        // btnQuickThisYear
        // 
        this.btnQuickThisYear.BackColor = System.Drawing.Color.White;
        this.btnQuickThisYear.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnQuickThisYear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
        this.btnQuickThisYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnQuickThisYear.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.btnQuickThisYear.Location = new System.Drawing.Point(750, 12);
        this.btnQuickThisYear.Name = "btnQuickThisYear";
        this.btnQuickThisYear.Size = new System.Drawing.Size(90, 26);
        this.btnQuickThisYear.TabIndex = 7;
        this.btnQuickThisYear.Text = "Cette Année";
        this.btnQuickThisYear.UseVisualStyleBackColor = false;
        this.btnQuickThisYear.Click += new System.EventHandler(this.BtnQuickThisYear_Click);
        // 
        // btnQuickThisMonth
        // 
        this.btnQuickThisMonth.BackColor = System.Drawing.Color.White;
        this.btnQuickThisMonth.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnQuickThisMonth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
        this.btnQuickThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnQuickThisMonth.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.btnQuickThisMonth.Location = new System.Drawing.Point(650, 12);
        this.btnQuickThisMonth.Name = "btnQuickThisMonth";
        this.btnQuickThisMonth.Size = new System.Drawing.Size(90, 26);
        this.btnQuickThisMonth.TabIndex = 6;
        this.btnQuickThisMonth.Text = "Ce Mois-ci";
        this.btnQuickThisMonth.UseVisualStyleBackColor = false;
        this.btnQuickThisMonth.Click += new System.EventHandler(this.BtnQuickThisMonth_Click);
        // 
        // btnQuickToday
        // 
        this.btnQuickToday.BackColor = System.Drawing.Color.White;
        this.btnQuickToday.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnQuickToday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
        this.btnQuickToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnQuickToday.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.btnQuickToday.Location = new System.Drawing.Point(550, 12);
        this.btnQuickToday.Name = "btnQuickToday";
        this.btnQuickToday.Size = new System.Drawing.Size(90, 26);
        this.btnQuickToday.TabIndex = 5;
        this.btnQuickToday.Text = "Aujourd'hui";
        this.btnQuickToday.UseVisualStyleBackColor = false;
        this.btnQuickToday.Click += new System.EventHandler(this.BtnQuickToday_Click);
        // 
        // btnFilter
        // 
        this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnFilter.FlatAppearance.BorderSize = 0;
        this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnFilter.ForeColor = System.Drawing.Color.White;
        this.btnFilter.Location = new System.Drawing.Point(440, 12);
        this.btnFilter.Name = "btnFilter";
        this.btnFilter.Size = new System.Drawing.Size(90, 26);
        this.btnFilter.TabIndex = 4;
        this.btnFilter.Text = "Filtrer";
        this.btnFilter.UseVisualStyleBackColor = false;
        this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
        // 
        // dtpEndDate
        // 
        this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
        this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpEndDate.Location = new System.Drawing.Point(295, 14);
        this.dtpEndDate.Name = "dtpEndDate";
        this.dtpEndDate.Size = new System.Drawing.Size(125, 23);
        this.dtpEndDate.TabIndex = 3;
        // 
        // lblEndDate
        // 
        this.lblEndDate.AutoSize = true;
        this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblEndDate.Location = new System.Drawing.Point(235, 17);
        this.lblEndDate.Name = "lblEndDate";
        this.lblEndDate.Size = new System.Drawing.Size(53, 15);
        this.lblEndDate.TabIndex = 2;
        this.lblEndDate.Text = "Date fin :";
        // 
        // dtpStartDate
        // 
        this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
        this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpStartDate.Location = new System.Drawing.Point(95, 14);
        this.dtpStartDate.Name = "dtpStartDate";
        this.dtpStartDate.Size = new System.Drawing.Size(125, 23);
        this.dtpStartDate.TabIndex = 1;
        // 
        // lblStartDate
        // 
        this.lblStartDate.AutoSize = true;
        this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblStartDate.Location = new System.Drawing.Point(20, 17);
        this.lblStartDate.Name = "lblStartDate";
        this.lblStartDate.Size = new System.Drawing.Size(71, 15);
        this.lblStartDate.TabIndex = 0;
        this.lblStartDate.Text = "Date début :";
        // 
        // pnlKpis
        // 
        this.pnlKpis.Controls.Add(this.tblKpis);
        this.pnlKpis.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlKpis.Location = new System.Drawing.Point(0, 117);
        this.pnlKpis.Name = "pnlKpis";
        this.pnlKpis.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
        this.pnlKpis.Size = new System.Drawing.Size(1100, 105);
        this.pnlKpis.TabIndex = 2;
        // 
        // tblKpis
        // 
        this.tblKpis.ColumnCount = 5;
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tblKpis.Controls.Add(this.cardGrossRevenue, 0, 0);
        this.tblKpis.Controls.Add(this.cardNetRevenue, 1, 0);
        this.tblKpis.Controls.Add(this.cardPurchaseCost, 2, 0);
        this.tblKpis.Controls.Add(this.cardGrossMargin, 3, 0);
        this.tblKpis.Controls.Add(this.cardMarginRate, 4, 0);
        this.tblKpis.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tblKpis.Location = new System.Drawing.Point(25, 10);
        this.tblKpis.Name = "tblKpis";
        this.tblKpis.RowCount = 1;
        this.tblKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblKpis.Size = new System.Drawing.Size(1050, 85);
        this.tblKpis.TabIndex = 0;
        // 
        // cardGrossRevenue
        // 
        this.cardGrossRevenue.BackColor = System.Drawing.Color.White;
        this.cardGrossRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.cardGrossRevenue.Controls.Add(this.lblCardGrossRevenueValue);
        this.cardGrossRevenue.Controls.Add(this.lblCardGrossRevenueTitle);
        this.cardGrossRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cardGrossRevenue.Location = new System.Drawing.Point(3, 3);
        this.cardGrossRevenue.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
        this.cardGrossRevenue.Name = "cardGrossRevenue";
        this.cardGrossRevenue.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
        this.cardGrossRevenue.Size = new System.Drawing.Size(199, 79);
        this.cardGrossRevenue.TabIndex = 0;
        // 
        // lblCardGrossRevenueValue
        // 
        this.lblCardGrossRevenueValue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblCardGrossRevenueValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblCardGrossRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.lblCardGrossRevenueValue.Location = new System.Drawing.Point(12, 28);
        this.lblCardGrossRevenueValue.Name = "lblCardGrossRevenueValue";
        this.lblCardGrossRevenueValue.Size = new System.Drawing.Size(173, 41);
        this.lblCardGrossRevenueValue.TabIndex = 1;
        this.lblCardGrossRevenueValue.Text = "0,00 €";
        this.lblCardGrossRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCardGrossRevenueTitle
        // 
        this.lblCardGrossRevenueTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblCardGrossRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblCardGrossRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblCardGrossRevenueTitle.Location = new System.Drawing.Point(12, 10);
        this.lblCardGrossRevenueTitle.Name = "lblCardGrossRevenueTitle";
        this.lblCardGrossRevenueTitle.Size = new System.Drawing.Size(173, 18);
        this.lblCardGrossRevenueTitle.TabIndex = 0;
        this.lblCardGrossRevenueTitle.Text = "CHIFFRE D\'AFFAIRES BRUT";
        // 
        // cardNetRevenue
        // 
        this.cardNetRevenue.BackColor = System.Drawing.Color.White;
        this.cardNetRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.cardNetRevenue.Controls.Add(this.lblCardNetRevenueValue);
        this.cardNetRevenue.Controls.Add(this.lblCardNetRevenueTitle);
        this.cardNetRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cardNetRevenue.Location = new System.Drawing.Point(213, 3);
        this.cardNetRevenue.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
        this.cardNetRevenue.Name = "cardNetRevenue";
        this.cardNetRevenue.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
        this.cardNetRevenue.Size = new System.Drawing.Size(199, 79);
        this.cardNetRevenue.TabIndex = 1;
        // 
        // lblCardNetRevenueValue
        // 
        this.lblCardNetRevenueValue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblCardNetRevenueValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblCardNetRevenueValue.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199);
        this.lblCardNetRevenueValue.Location = new System.Drawing.Point(12, 28);
        this.lblCardNetRevenueValue.Name = "lblCardNetRevenueValue";
        this.lblCardNetRevenueValue.Size = new System.Drawing.Size(173, 41);
        this.lblCardNetRevenueValue.TabIndex = 1;
        this.lblCardNetRevenueValue.Text = "0,00 €";
        this.lblCardNetRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCardNetRevenueTitle
        // 
        this.lblCardNetRevenueTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblCardNetRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblCardNetRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblCardNetRevenueTitle.Location = new System.Drawing.Point(12, 10);
        this.lblCardNetRevenueTitle.Name = "lblCardNetRevenueTitle";
        this.lblCardNetRevenueTitle.Size = new System.Drawing.Size(173, 18);
        this.lblCardNetRevenueTitle.TabIndex = 0;
        this.lblCardNetRevenueTitle.Text = "CA NET ENCAISSÉ";
        // 
        // cardPurchaseCost
        // 
        this.cardPurchaseCost.BackColor = System.Drawing.Color.White;
        this.cardPurchaseCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.cardPurchaseCost.Controls.Add(this.lblCardPurchaseCostValue);
        this.cardPurchaseCost.Controls.Add(this.lblCardPurchaseCostTitle);
        this.cardPurchaseCost.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cardPurchaseCost.Location = new System.Drawing.Point(423, 3);
        this.cardPurchaseCost.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
        this.cardPurchaseCost.Name = "cardPurchaseCost";
        this.cardPurchaseCost.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
        this.cardPurchaseCost.Size = new System.Drawing.Size(199, 79);
        this.cardPurchaseCost.TabIndex = 2;
        // 
        // lblCardPurchaseCostValue
        // 
        this.lblCardPurchaseCostValue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblCardPurchaseCostValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblCardPurchaseCostValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
        this.lblCardPurchaseCostValue.Location = new System.Drawing.Point(12, 28);
        this.lblCardPurchaseCostValue.Name = "lblCardPurchaseCostValue";
        this.lblCardPurchaseCostValue.Size = new System.Drawing.Size(173, 41);
        this.lblCardPurchaseCostValue.TabIndex = 1;
        this.lblCardPurchaseCostValue.Text = "0,00 €";
        this.lblCardPurchaseCostValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCardPurchaseCostTitle
        // 
        this.lblCardPurchaseCostTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblCardPurchaseCostTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblCardPurchaseCostTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblCardPurchaseCostTitle.Location = new System.Drawing.Point(12, 10);
        this.lblCardPurchaseCostTitle.Name = "lblCardPurchaseCostTitle";
        this.lblCardPurchaseCostTitle.Size = new System.Drawing.Size(173, 18);
        this.lblCardPurchaseCostTitle.TabIndex = 0;
        this.lblCardPurchaseCostTitle.Text = "COÛT D\'ACHAT DES LOTS";
        // 
        // cardGrossMargin
        // 
        this.cardGrossMargin.BackColor = System.Drawing.Color.White;
        this.cardGrossMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.cardGrossMargin.Controls.Add(this.lblCardGrossMarginValue);
        this.cardGrossMargin.Controls.Add(this.lblCardGrossMarginTitle);
        this.cardGrossMargin.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cardGrossMargin.Location = new System.Drawing.Point(633, 3);
        this.cardGrossMargin.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
        this.cardGrossMargin.Name = "cardGrossMargin";
        this.cardGrossMargin.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
        this.cardGrossMargin.Size = new System.Drawing.Size(199, 79);
        this.cardGrossMargin.TabIndex = 3;
        // 
        // lblCardGrossMarginValue
        // 
        this.lblCardGrossMarginValue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblCardGrossMarginValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblCardGrossMarginValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblCardGrossMarginValue.Location = new System.Drawing.Point(12, 28);
        this.lblCardGrossMarginValue.Name = "lblCardGrossMarginValue";
        this.lblCardGrossMarginValue.Size = new System.Drawing.Size(173, 41);
        this.lblCardGrossMarginValue.TabIndex = 1;
        this.lblCardGrossMarginValue.Text = "+0,00 €";
        this.lblCardGrossMarginValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCardGrossMarginTitle
        // 
        this.lblCardGrossMarginTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblCardGrossMarginTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblCardGrossMarginTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblCardGrossMarginTitle.Location = new System.Drawing.Point(12, 10);
        this.lblCardGrossMarginTitle.Name = "lblCardGrossMarginTitle";
        this.lblCardGrossMarginTitle.Size = new System.Drawing.Size(173, 18);
        this.lblCardGrossMarginTitle.TabIndex = 0;
        this.lblCardGrossMarginTitle.Text = "MARGE BRUTE RÉALISÉE";
        // 
        // cardMarginRate
        // 
        this.cardMarginRate.BackColor = System.Drawing.Color.White;
        this.cardMarginRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.cardMarginRate.Controls.Add(this.lblCardMarginRateValue);
        this.cardMarginRate.Controls.Add(this.lblCardMarginRateTitle);
        this.cardMarginRate.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cardMarginRate.Location = new System.Drawing.Point(843, 3);
        this.cardMarginRate.Name = "cardMarginRate";
        this.cardMarginRate.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
        this.cardMarginRate.Size = new System.Drawing.Size(204, 79);
        this.cardMarginRate.TabIndex = 4;
        // 
        // lblCardMarginRateValue
        // 
        this.lblCardMarginRateValue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblCardMarginRateValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblCardMarginRateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblCardMarginRateValue.Location = new System.Drawing.Point(12, 28);
        this.lblCardMarginRateValue.Name = "lblCardMarginRateValue";
        this.lblCardMarginRateValue.Size = new System.Drawing.Size(178, 41);
        this.lblCardMarginRateValue.TabIndex = 1;
        this.lblCardMarginRateValue.Text = "0.0 %";
        this.lblCardMarginRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCardMarginRateTitle
        // 
        this.lblCardMarginRateTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblCardMarginRateTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblCardMarginRateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblCardMarginRateTitle.Location = new System.Drawing.Point(12, 10);
        this.lblCardMarginRateTitle.Name = "lblCardMarginRateTitle";
        this.lblCardMarginRateTitle.Size = new System.Drawing.Size(178, 18);
        this.lblCardMarginRateTitle.TabIndex = 0;
        this.lblCardMarginRateTitle.Text = "TAUX DE MARGE MOYEN";
        // 
        // dgvProductMargins
        // 
        this.dgvProductMargins.AllowUserToAddRows = false;
        this.dgvProductMargins.AllowUserToDeleteRows = false;
        this.dgvProductMargins.AllowUserToResizeRows = false;
        this.dgvProductMargins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvProductMargins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProductMargins.BackgroundColor = System.Drawing.Color.White;
        this.dgvProductMargins.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvProductMargins.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvProductMargins.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvProductMargins.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvProductMargins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvProductMargins.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvProductMargins.EnableHeadersVisualStyles = false;
        this.dgvProductMargins.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
        this.dgvProductMargins.Location = new System.Drawing.Point(25, 230);
        this.dgvProductMargins.MultiSelect = false;
        this.dgvProductMargins.Name = "dgvProductMargins";
        this.dgvProductMargins.ReadOnly = true;
        this.dgvProductMargins.RowHeadersVisible = false;
        this.dgvProductMargins.RowTemplate.Height = 34;
        this.dgvProductMargins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvProductMargins.Size = new System.Drawing.Size(1050, 400);
        this.dgvProductMargins.TabIndex = 3;
        // 
        // ReportsControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.Controls.Add(this.dgvProductMargins);
        this.Controls.Add(this.pnlKpis);
        this.Controls.Add(this.pnlFilter);
        this.Controls.Add(this.pnlHeader);
        this.Name = "ReportsControl";
        this.Size = new System.Drawing.Size(1100, 650);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFilter.ResumeLayout(false);
        this.pnlFilter.PerformLayout();
        this.pnlKpis.ResumeLayout(false);
        this.tblKpis.ResumeLayout(false);
        this.cardGrossRevenue.ResumeLayout(false);
        this.cardNetRevenue.ResumeLayout(false);
        this.cardPurchaseCost.ResumeLayout(false);
        this.cardGrossMargin.ResumeLayout(false);
        this.cardMarginRate.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvProductMargins)).EndInit();
        this.ResumeLayout(false);
    }
}
