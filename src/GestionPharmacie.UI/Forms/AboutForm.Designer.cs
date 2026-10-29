namespace GestionPharmacie.UI.Forms;

partial class AboutForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Panel pnlContent;
    private System.Windows.Forms.Label lblAppName;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Label lblAuthor;
    private System.Windows.Forms.Label lblYear;
    private System.Windows.Forms.Label lblLicenseBadge;
    private System.Windows.Forms.Label lblLicenseSummary;
    private System.Windows.Forms.TextBox txtLicenseFull;
    private System.Windows.Forms.Button btnClose;

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
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.lblHeaderSubtitle = new System.Windows.Forms.Label();
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.pnlContent = new System.Windows.Forms.Panel();
        this.btnClose = new System.Windows.Forms.Button();
        this.txtLicenseFull = new System.Windows.Forms.TextBox();
        this.lblLicenseSummary = new System.Windows.Forms.Label();
        this.lblLicenseBadge = new System.Windows.Forms.Label();
        this.lblYear = new System.Windows.Forms.Label();
        this.lblAuthor = new System.Windows.Forms.Label();
        this.lblVersion = new System.Windows.Forms.Label();
        this.lblAppName = new System.Windows.Forms.Label();
        this.pnlHeader.SuspendLayout();
        this.pnlContent.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
        this.pnlHeader.Size = new System.Drawing.Size(620, 75);
        this.pnlHeader.TabIndex = 0;
        // 
        // lblHeaderSubtitle
        // 
        this.lblHeaderSubtitle.AutoSize = true;
        this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
        this.lblHeaderSubtitle.Location = new System.Drawing.Point(20, 42);
        this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(370, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Informations sur le logiciel, l\'auteur et la licence Open Source (MIT)";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
        this.lblHeaderTitle.Location = new System.Drawing.Point(18, 14);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(306, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "ℹ️ À Propos de Gestion Pharmacie";
        // 
        // pnlContent
        // 
        this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.pnlContent.Controls.Add(this.btnClose);
        this.pnlContent.Controls.Add(this.txtLicenseFull);
        this.pnlContent.Controls.Add(this.lblLicenseSummary);
        this.pnlContent.Controls.Add(this.lblLicenseBadge);
        this.pnlContent.Controls.Add(this.lblYear);
        this.pnlContent.Controls.Add(this.lblAuthor);
        this.pnlContent.Controls.Add(this.lblVersion);
        this.pnlContent.Controls.Add(this.lblAppName);
        this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlContent.Location = new System.Drawing.Point(0, 75);
        this.pnlContent.Name = "pnlContent";
        this.pnlContent.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
        this.pnlContent.Size = new System.Drawing.Size(620, 465);
        this.pnlContent.TabIndex = 1;
        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.btnClose.FlatAppearance.BorderSize = 0;
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(475, 415);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(120, 35);
        this.btnClose.TabIndex = 7;
        this.btnClose.Text = "Fermer";
        this.btnClose.UseVisualStyleBackColor = false;
        // 
        // txtLicenseFull
        // 
        this.txtLicenseFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.txtLicenseFull.BackColor = System.Drawing.Color.White;
        this.txtLicenseFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtLicenseFull.Font = new System.Drawing.Font("Consolas", 8.5F);
        this.txtLicenseFull.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
        this.txtLicenseFull.Location = new System.Drawing.Point(25, 220);
        this.txtLicenseFull.Multiline = true;
        this.txtLicenseFull.Name = "txtLicenseFull";
        this.txtLicenseFull.ReadOnly = true;
        this.txtLicenseFull.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtLicenseFull.Size = new System.Drawing.Size(570, 180);
        this.txtLicenseFull.TabIndex = 6;
        // 
        // lblLicenseSummary
        // 
        this.lblLicenseSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblLicenseSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblLicenseSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
        this.lblLicenseSummary.Location = new System.Drawing.Point(22, 160);
        this.lblLicenseSummary.Name = "lblLicenseSummary";
        this.lblLicenseSummary.Size = new System.Drawing.Size(573, 50);
        this.lblLicenseSummary.TabIndex = 5;
        this.lblLicenseSummary.Text = "Ce logiciel est distribué sous la Licence Open Source MIT. Vous êtes libre de l\'utiliser, de le modifier, de le distribuer et de l\'adapter pour toute utilisation commerciale ou privée, sous réserve de conserver la mention de copyright ci-dessous.";
        // 
        // lblLicenseBadge
        // 
        this.lblLicenseBadge.AutoSize = true;
        this.lblLicenseBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
        this.lblLicenseBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblLicenseBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblLicenseBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblLicenseBadge.Location = new System.Drawing.Point(25, 130);
        this.lblLicenseBadge.Name = "lblLicenseBadge";
        this.lblLicenseBadge.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
        this.lblLicenseBadge.Size = new System.Drawing.Size(185, 23);
        this.lblLicenseBadge.TabIndex = 4;
        this.lblLicenseBadge.Text = "⚖️ Licence MIT (Open Source)";
        // 
        // lblYear
        // 
        this.lblYear.AutoSize = true;
        this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblYear.Location = new System.Drawing.Point(22, 95);
        this.lblYear.Name = "lblYear";
        this.lblYear.Size = new System.Drawing.Size(199, 17);
        this.lblYear.TabIndex = 3;
        this.lblYear.Text = "Année : 2026 | Tous droits réservés";
        // 
        // lblAuthor
        // 
        this.lblAuthor.AutoSize = true;
        this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
        this.lblAuthor.Location = new System.Drawing.Point(22, 70);
        this.lblAuthor.Name = "lblAuthor";
        this.lblAuthor.Size = new System.Drawing.Size(268, 19);
        this.lblAuthor.TabIndex = 2;
        this.lblAuthor.Text = "Auteur / Créateur : Dzaba Diliane Merveille";
        // 
        // lblVersion
        // 
        this.lblVersion.AutoSize = true;
        this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
        this.lblVersion.Location = new System.Drawing.Point(22, 45);
        this.lblVersion.Name = "lblVersion";
        this.lblVersion.Size = new System.Drawing.Size(319, 17);
        this.lblVersion.TabIndex = 1;
        this.lblVersion.Text = "Version 1.0.0 (Release .NET 8.0 WinForms + SQLite)";
        // 
        // lblAppName
        // 
        this.lblAppName.AutoSize = true;
        this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblAppName.Location = new System.Drawing.Point(20, 15);
        this.lblAppName.Name = "lblAppName";
        this.lblAppName.Size = new System.Drawing.Size(434, 25);
        this.lblAppName.TabIndex = 0;
        this.lblAppName.Text = "🏥 Système de Gestion de Pharmacie Officinale";
        // 
        // AboutForm
        // 
        this.AcceptButton = this.btnClose;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(620, 540);
        this.Controls.Add(this.pnlContent);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AboutForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "À propos de Gestion Pharmacie";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlContent.ResumeLayout(false);
        this.pnlContent.PerformLayout();
        this.ResumeLayout(false);
    }
}
