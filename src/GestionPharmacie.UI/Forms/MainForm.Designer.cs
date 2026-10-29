namespace GestionPharmacie.UI.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlTopBar;
    private System.Windows.Forms.Label lblAppTitle;
    private System.Windows.Forms.Label lblUserBadge;
    private System.Windows.Forms.Label lblDateTime;
    private System.Windows.Forms.Button btnAbout;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.Panel pnlSidebar;
    private System.Windows.Forms.Button btnNavDashboard;
    private System.Windows.Forms.Button btnNavSales;
    private System.Windows.Forms.Button btnNavProducts;
    private System.Windows.Forms.Button btnNavStock;
    private System.Windows.Forms.Button btnNavInventory;
    private System.Windows.Forms.Button btnNavReports;
    private System.Windows.Forms.Button btnNavBackup;
    private System.Windows.Forms.Button btnNavAudit;
    private System.Windows.Forms.Button btnNavSettings;
    private System.Windows.Forms.Panel pnlContent;
    private System.Windows.Forms.Panel pnlActiveIndicator;
    private System.Windows.Forms.Timer tmrClock;

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
        this.components = new System.ComponentModel.Container();
        this.pnlTopBar = new System.Windows.Forms.Panel();
        this.lblDateTime = new System.Windows.Forms.Label();
        this.btnAbout = new System.Windows.Forms.Button();
        this.btnLogout = new System.Windows.Forms.Button();
        this.lblUserBadge = new System.Windows.Forms.Label();
        this.lblAppTitle = new System.Windows.Forms.Label();
        this.pnlSidebar = new System.Windows.Forms.Panel();
        this.pnlActiveIndicator = new System.Windows.Forms.Panel();
        this.btnNavSettings = new System.Windows.Forms.Button();
        this.btnNavAudit = new System.Windows.Forms.Button();
        this.btnNavBackup = new System.Windows.Forms.Button();
        this.btnNavReports = new System.Windows.Forms.Button();
        this.btnNavInventory = new System.Windows.Forms.Button();
        this.btnNavStock = new System.Windows.Forms.Button();
        this.btnNavProducts = new System.Windows.Forms.Button();
        this.btnNavSales = new System.Windows.Forms.Button();
        this.btnNavDashboard = new System.Windows.Forms.Button();
        this.pnlContent = new System.Windows.Forms.Panel();
        this.tmrClock = new System.Windows.Forms.Timer(this.components);
        this.pnlTopBar.SuspendLayout();
        this.pnlSidebar.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlTopBar
        // 
        this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.pnlTopBar.Controls.Add(this.lblDateTime);
        this.pnlTopBar.Controls.Add(this.btnAbout);
        this.pnlTopBar.Controls.Add(this.btnLogout);
        this.pnlTopBar.Controls.Add(this.lblUserBadge);
        this.pnlTopBar.Controls.Add(this.lblAppTitle);
        this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
        this.pnlTopBar.Name = "pnlTopBar";
        this.pnlTopBar.Size = new System.Drawing.Size(1366, 60);
        this.pnlTopBar.TabIndex = 0;
        // 
        // lblDateTime
        // 
        this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
        this.lblDateTime.Location = new System.Drawing.Point(620, 20);
        this.lblDateTime.Name = "lblDateTime";
        this.lblDateTime.Size = new System.Drawing.Size(200, 20);
        this.lblDateTime.TabIndex = 3;
        this.lblDateTime.Text = "13/10/2026 15:45";
        this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnAbout
        // 
        this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(140)))), ((int)(((byte)(110)))));
        this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnAbout.FlatAppearance.BorderSize = 0;
        this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnAbout.ForeColor = System.Drawing.Color.White;
        this.btnAbout.Location = new System.Drawing.Point(1135, 14);
        this.btnAbout.Name = "btnAbout";
        this.btnAbout.Size = new System.Drawing.Size(100, 32);
        this.btnAbout.TabIndex = 3;
        this.btnAbout.Text = "ℹ️ À Propos";
        this.btnAbout.UseVisualStyleBackColor = false;
        this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
        // 
        // btnLogout
        // 
        this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
        this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLogout.FlatAppearance.BorderSize = 0;
        this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnLogout.ForeColor = System.Drawing.Color.White;
        this.btnLogout.Location = new System.Drawing.Point(1245, 14);
        this.btnLogout.Name = "btnLogout";
        this.btnLogout.Size = new System.Drawing.Size(105, 32);
        this.btnLogout.TabIndex = 2;
        this.btnLogout.Text = "🚪 Déconnexion";
        this.btnLogout.UseVisualStyleBackColor = false;
        this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
        // 
        // lblUserBadge
        // 
        this.lblUserBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblUserBadge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblUserBadge.ForeColor = System.Drawing.Color.White;
        this.lblUserBadge.Location = new System.Drawing.Point(830, 18);
        this.lblUserBadge.Name = "lblUserBadge";
        this.lblUserBadge.Size = new System.Drawing.Size(295, 24);
        this.lblUserBadge.TabIndex = 1;
        this.lblUserBadge.Text = "👤 Connecté : Utilisateur (Rôle)";
        this.lblUserBadge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblAppTitle
        // 
        this.lblAppTitle.AutoSize = true;
        this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblAppTitle.ForeColor = System.Drawing.Color.White;
        this.lblAppTitle.Location = new System.Drawing.Point(20, 16);
        this.lblAppTitle.Name = "lblAppTitle";
        this.lblAppTitle.Size = new System.Drawing.Size(270, 25);
        this.lblAppTitle.TabIndex = 0;
        this.lblAppTitle.Text = "🏥 GESTION DE PHARMACIE";
        // 
        // pnlSidebar
        // 
        this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(36)))), ((int)(((byte)(44)))));
        this.pnlSidebar.Controls.Add(this.pnlActiveIndicator);
        this.pnlSidebar.Controls.Add(this.btnNavSettings);
        this.pnlSidebar.Controls.Add(this.btnNavAudit);
        this.pnlSidebar.Controls.Add(this.btnNavBackup);
        this.pnlSidebar.Controls.Add(this.btnNavReports);
        this.pnlSidebar.Controls.Add(this.btnNavInventory);
        this.pnlSidebar.Controls.Add(this.btnNavStock);
        this.pnlSidebar.Controls.Add(this.btnNavProducts);
        this.pnlSidebar.Controls.Add(this.btnNavSales);
        this.pnlSidebar.Controls.Add(this.btnNavDashboard);
        this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
        this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
        this.pnlSidebar.Name = "pnlSidebar";
        this.pnlSidebar.Size = new System.Drawing.Size(240, 708);
        this.pnlSidebar.TabIndex = 1;
        // 
        // pnlActiveIndicator
        // 
        this.pnlActiveIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.pnlActiveIndicator.Location = new System.Drawing.Point(0, 10);
        this.pnlActiveIndicator.Name = "pnlActiveIndicator";
        this.pnlActiveIndicator.Size = new System.Drawing.Size(5, 46);
        this.pnlActiveIndicator.TabIndex = 9;
        // 
        // btnNavSettings
        // 
        this.btnNavSettings.BackColor = System.Drawing.Color.Transparent;
        this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavSettings.FlatAppearance.BorderSize = 0;
        this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavSettings.Location = new System.Drawing.Point(0, 378);
        this.btnNavSettings.Name = "btnNavSettings";
        this.btnNavSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavSettings.Size = new System.Drawing.Size(240, 46);
        this.btnNavSettings.TabIndex = 8;
        this.btnNavSettings.Text = "⚙️ Paramètres Officine";
        this.btnNavSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavSettings.UseVisualStyleBackColor = false;
        this.btnNavSettings.Click += new System.EventHandler(this.BtnNavSettings_Click);
        // 
        // btnNavAudit
        // 
        this.btnNavAudit.BackColor = System.Drawing.Color.Transparent;
        this.btnNavAudit.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavAudit.FlatAppearance.BorderSize = 0;
        this.btnNavAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavAudit.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavAudit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavAudit.Location = new System.Drawing.Point(0, 332);
        this.btnNavAudit.Name = "btnNavAudit";
        this.btnNavAudit.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavAudit.Size = new System.Drawing.Size(240, 46);
        this.btnNavAudit.TabIndex = 7;
        this.btnNavAudit.Text = "📋 Journal d\'Audit";
        this.btnNavAudit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavAudit.UseVisualStyleBackColor = false;
        this.btnNavAudit.Click += new System.EventHandler(this.BtnNavAudit_Click);
        // 
        // btnNavBackup
        // 
        this.btnNavBackup.BackColor = System.Drawing.Color.Transparent;
        this.btnNavBackup.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavBackup.FlatAppearance.BorderSize = 0;
        this.btnNavBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavBackup.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavBackup.Location = new System.Drawing.Point(0, 286);
        this.btnNavBackup.Name = "btnNavBackup";
        this.btnNavBackup.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavBackup.Size = new System.Drawing.Size(240, 46);
        this.btnNavBackup.TabIndex = 6;
        this.btnNavBackup.Text = "💾 Sauvegardes SQLite";
        this.btnNavBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavBackup.UseVisualStyleBackColor = false;
        this.btnNavBackup.Click += new System.EventHandler(this.BtnNavBackup_Click);
        // 
        // btnNavReports
        // 
        this.btnNavReports.BackColor = System.Drawing.Color.Transparent;
        this.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavReports.FlatAppearance.BorderSize = 0;
        this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavReports.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavReports.Location = new System.Drawing.Point(0, 240);
        this.btnNavReports.Name = "btnNavReports";
        this.btnNavReports.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavReports.Size = new System.Drawing.Size(240, 46);
        this.btnNavReports.TabIndex = 5;
        this.btnNavReports.Text = "📈 Rapports & Marges";
        this.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavReports.UseVisualStyleBackColor = false;
        this.btnNavReports.Click += new System.EventHandler(this.BtnNavReports_Click);
        // 
        // btnNavInventory
        // 
        this.btnNavInventory.BackColor = System.Drawing.Color.Transparent;
        this.btnNavInventory.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavInventory.FlatAppearance.BorderSize = 0;
        this.btnNavInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavInventory.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavInventory.Location = new System.Drawing.Point(0, 194);
        this.btnNavInventory.Name = "btnNavInventory";
        this.btnNavInventory.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavInventory.Size = new System.Drawing.Size(240, 46);
        this.btnNavInventory.TabIndex = 4;
        this.btnNavInventory.Text = "📦 Inventaires & Ajustements";
        this.btnNavInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavInventory.UseVisualStyleBackColor = false;
        this.btnNavInventory.Click += new System.EventHandler(this.BtnNavInventory_Click);
        // 
        // btnNavStock
        // 
        this.btnNavStock.BackColor = System.Drawing.Color.Transparent;
        this.btnNavStock.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavStock.FlatAppearance.BorderSize = 0;
        this.btnNavStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavStock.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavStock.Location = new System.Drawing.Point(0, 148);
        this.btnNavStock.Name = "btnNavStock";
        this.btnNavStock.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavStock.Size = new System.Drawing.Size(240, 46);
        this.btnNavStock.TabIndex = 3;
        this.btnNavStock.Text = "📥 Réception de Stock";
        this.btnNavStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavStock.UseVisualStyleBackColor = false;
        this.btnNavStock.Click += new System.EventHandler(this.BtnNavStock_Click);
        // 
        // btnNavProducts
        // 
        this.btnNavProducts.BackColor = System.Drawing.Color.Transparent;
        this.btnNavProducts.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavProducts.FlatAppearance.BorderSize = 0;
        this.btnNavProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavProducts.Location = new System.Drawing.Point(0, 102);
        this.btnNavProducts.Name = "btnNavProducts";
        this.btnNavProducts.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavProducts.Size = new System.Drawing.Size(240, 46);
        this.btnNavProducts.TabIndex = 2;
        this.btnNavProducts.Text = "💊 Catalogue Produits";
        this.btnNavProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavProducts.UseVisualStyleBackColor = false;
        this.btnNavProducts.Click += new System.EventHandler(this.BtnNavProducts_Click);
        // 
        // btnNavSales
        // 
        this.btnNavSales.BackColor = System.Drawing.Color.Transparent;
        this.btnNavSales.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavSales.FlatAppearance.BorderSize = 0;
        this.btnNavSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavSales.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnNavSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
        this.btnNavSales.Location = new System.Drawing.Point(0, 56);
        this.btnNavSales.Name = "btnNavSales";
        this.btnNavSales.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavSales.Size = new System.Drawing.Size(240, 46);
        this.btnNavSales.TabIndex = 1;
        this.btnNavSales.Text = "💳 Caisse & Ventes";
        this.btnNavSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavSales.UseVisualStyleBackColor = false;
        this.btnNavSales.Click += new System.EventHandler(this.BtnNavSales_Click);
        // 
        // btnNavDashboard
        // 
        this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
        this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNavDashboard.FlatAppearance.BorderSize = 0;
        this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
        this.btnNavDashboard.Location = new System.Drawing.Point(0, 10);
        this.btnNavDashboard.Name = "btnNavDashboard";
        this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.btnNavDashboard.Size = new System.Drawing.Size(240, 46);
        this.btnNavDashboard.TabIndex = 0;
        this.btnNavDashboard.Text = "📊 Tableau de Bord";
        this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnNavDashboard.UseVisualStyleBackColor = false;
        this.btnNavDashboard.Click += new System.EventHandler(this.BtnNavDashboard_Click);
        // 
        // pnlContent
        // 
        this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlContent.Location = new System.Drawing.Point(240, 60);
        this.pnlContent.Name = "pnlContent";
        this.pnlContent.Size = new System.Drawing.Size(1126, 708);
        this.pnlContent.TabIndex = 2;
        // 
        // tmrClock
        // 
        this.tmrClock.Enabled = true;
        this.tmrClock.Interval = 1000;
        this.tmrClock.Tick += new System.EventHandler(this.TmrClock_Tick);
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1366, 768);
        this.Controls.Add(this.pnlContent);
        this.Controls.Add(this.pnlSidebar);
        this.Controls.Add(this.pnlTopBar);
        this.MinimumSize = new System.Drawing.Size(1280, 720);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Système de Gestion de Pharmacie Officinale";
        this.pnlTopBar.ResumeLayout(false);
        this.pnlTopBar.PerformLayout();
        this.pnlSidebar.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
