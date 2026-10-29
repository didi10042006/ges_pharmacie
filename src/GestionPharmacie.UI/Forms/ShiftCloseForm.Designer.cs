namespace GestionPharmacie.UI.Forms;

partial class ShiftCloseForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.GroupBox grpSummary;
    private System.Windows.Forms.Label lblSalesCount;
    private System.Windows.Forms.Label lblTotalNet;
    private System.Windows.Forms.Label lblExpectedCash;
    private System.Windows.Forms.Label lblCardSales;
    private System.Windows.Forms.Label lblMobileSales;
    private System.Windows.Forms.Label lblTotalDiscounts;
    private System.Windows.Forms.GroupBox grpCount;
    private System.Windows.Forms.Label lblCountedCash;
    private System.Windows.Forms.NumericUpDown nudCountedCash;
    private System.Windows.Forms.Label lblDifferenceTitle;
    private System.Windows.Forms.Label lblDifferenceValue;
    private System.Windows.Forms.Label lblNotes;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.Button btnConfirmClose;
    private System.Windows.Forms.Button btnCancel;

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
        this.grpSummary = new System.Windows.Forms.GroupBox();
        this.lblTotalDiscounts = new System.Windows.Forms.Label();
        this.lblMobileSales = new System.Windows.Forms.Label();
        this.lblCardSales = new System.Windows.Forms.Label();
        this.lblExpectedCash = new System.Windows.Forms.Label();
        this.lblTotalNet = new System.Windows.Forms.Label();
        this.lblSalesCount = new System.Windows.Forms.Label();
        this.grpCount = new System.Windows.Forms.GroupBox();
        this.txtNotes = new System.Windows.Forms.TextBox();
        this.lblNotes = new System.Windows.Forms.Label();
        this.lblDifferenceValue = new System.Windows.Forms.Label();
        this.lblDifferenceTitle = new System.Windows.Forms.Label();
        this.nudCountedCash = new System.Windows.Forms.NumericUpDown();
        this.lblCountedCash = new System.Windows.Forms.Label();
        this.btnConfirmClose = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.pnlHeader.SuspendLayout();
        this.grpSummary.SuspendLayout();
        this.grpCount.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudCountedCash)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
        this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 12, 20, 10);
        this.pnlHeader.Size = new System.Drawing.Size(560, 65);
        this.pnlHeader.TabIndex = 0;
        // 
        // lblHeaderSubtitle
        // 
        this.lblHeaderSubtitle.AutoSize = true;
        this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
        this.lblHeaderSubtitle.Location = new System.Drawing.Point(20, 38);
        this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(374, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Rapprochement des paiements et justification des écarts de trésorerie";
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
        this.lblHeaderTitle.Location = new System.Drawing.Point(18, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(262, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "📊 Clôture de Caisse Journalière";
        // 
        // grpSummary
        // 
        this.grpSummary.BackColor = System.Drawing.Color.White;
        this.grpSummary.Controls.Add(this.lblTotalDiscounts);
        this.grpSummary.Controls.Add(this.lblMobileSales);
        this.grpSummary.Controls.Add(this.lblCardSales);
        this.grpSummary.Controls.Add(this.lblExpectedCash);
        this.grpSummary.Controls.Add(this.lblTotalNet);
        this.grpSummary.Controls.Add(this.lblSalesCount);
        this.grpSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.grpSummary.Location = new System.Drawing.Point(25, 75);
        this.grpSummary.Name = "grpSummary";
        this.grpSummary.Size = new System.Drawing.Size(510, 150);
        this.grpSummary.TabIndex = 1;
        this.grpSummary.TabStop = false;
        this.grpSummary.Text = "1. Chiffre d'Affaires Théorique (Système)";
        // 
        // lblTotalDiscounts
        // 
        this.lblTotalDiscounts.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblTotalDiscounts.Location = new System.Drawing.Point(260, 110);
        this.lblTotalDiscounts.Name = "lblTotalDiscounts";
        this.lblTotalDiscounts.Size = new System.Drawing.Size(230, 22);
        this.lblTotalDiscounts.TabIndex = 5;
        this.lblTotalDiscounts.Text = "Remises accordées : 0,00 €";
        // 
        // lblMobileSales
        // 
        this.lblMobileSales.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblMobileSales.Location = new System.Drawing.Point(260, 70);
        this.lblMobileSales.Name = "lblMobileSales";
        this.lblMobileSales.Size = new System.Drawing.Size(230, 22);
        this.lblMobileSales.TabIndex = 4;
        this.lblMobileSales.Text = "Paiement Mobile : 0,00 €";
        // 
        // lblCardSales
        // 
        this.lblCardSales.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblCardSales.Location = new System.Drawing.Point(260, 30);
        this.lblCardSales.Name = "lblCardSales";
        this.lblCardSales.Size = new System.Drawing.Size(230, 22);
        this.lblCardSales.TabIndex = 3;
        this.lblCardSales.Text = "Carte Bancaire : 0,00 €";
        // 
        // lblExpectedCash
        // 
        this.lblExpectedCash.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblExpectedCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblExpectedCash.Location = new System.Drawing.Point(20, 110);
        this.lblExpectedCash.Name = "lblExpectedCash";
        this.lblExpectedCash.Size = new System.Drawing.Size(220, 22);
        this.lblExpectedCash.TabIndex = 2;
        this.lblExpectedCash.Text = "Espèces attendues : 0,00 €";
        // 
        // lblTotalNet
        // 
        this.lblTotalNet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblTotalNet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
        this.lblTotalNet.Location = new System.Drawing.Point(20, 70);
        this.lblTotalNet.Name = "lblTotalNet";
        this.lblTotalNet.Size = new System.Drawing.Size(220, 22);
        this.lblTotalNet.TabIndex = 1;
        this.lblTotalNet.Text = "Total Net Encaissé : 0,00 €";
        // 
        // lblSalesCount
        // 
        this.lblSalesCount.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSalesCount.Location = new System.Drawing.Point(20, 30);
        this.lblSalesCount.Name = "lblSalesCount";
        this.lblSalesCount.Size = new System.Drawing.Size(220, 22);
        this.lblSalesCount.TabIndex = 0;
        this.lblSalesCount.Text = "Nombre de transactions : 0";
        // 
        // grpCount
        // 
        this.grpCount.BackColor = System.Drawing.Color.White;
        this.grpCount.Controls.Add(this.txtNotes);
        this.grpCount.Controls.Add(this.lblNotes);
        this.grpCount.Controls.Add(this.lblDifferenceValue);
        this.grpCount.Controls.Add(this.lblDifferenceTitle);
        this.grpCount.Controls.Add(this.nudCountedCash);
        this.grpCount.Controls.Add(this.lblCountedCash);
        this.grpCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
        this.grpCount.Location = new System.Drawing.Point(25, 235);
        this.grpCount.Name = "grpCount";
        this.grpCount.Size = new System.Drawing.Size(510, 190);
        this.grpCount.TabIndex = 2;
        this.grpCount.TabStop = false;
        this.grpCount.Text = "2. Comptage Physique du Tiroir Caisse";
        // 
        // txtNotes
        // 
        this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtNotes.Location = new System.Drawing.Point(20, 145);
        this.txtNotes.MaxLength = 200;
        this.txtNotes.Name = "txtNotes";
        this.txtNotes.PlaceholderText = "Explication d'un éventuel écart ou remarque...";
        this.txtNotes.Size = new System.Drawing.Size(470, 23);
        this.txtNotes.TabIndex = 5;
        // 
        // lblNotes
        // 
        this.lblNotes.AutoSize = true;
        this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblNotes.Location = new System.Drawing.Point(17, 125);
        this.lblNotes.Name = "lblNotes";
        this.lblNotes.Size = new System.Drawing.Size(130, 15);
        this.lblNotes.TabIndex = 4;
        this.lblNotes.Text = "Observations / Justif. :";
        // 
        // lblDifferenceValue
        // 
        this.lblDifferenceValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblDifferenceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblDifferenceValue.Location = new System.Drawing.Point(260, 60);
        this.lblDifferenceValue.Name = "lblDifferenceValue";
        this.lblDifferenceValue.Size = new System.Drawing.Size(230, 30);
        this.lblDifferenceValue.TabIndex = 3;
        this.lblDifferenceValue.Text = "0,00 € (Équilibré)";
        this.lblDifferenceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblDifferenceTitle
        // 
        this.lblDifferenceTitle.AutoSize = true;
        this.lblDifferenceTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblDifferenceTitle.Location = new System.Drawing.Point(257, 35);
        this.lblDifferenceTitle.Name = "lblDifferenceTitle";
        this.lblDifferenceTitle.Size = new System.Drawing.Size(125, 15);
        this.lblDifferenceTitle.TabIndex = 2;
        this.lblDifferenceTitle.Text = "Écart constaté (Caisse) :";
        // 
        // nudCountedCash
        // 
        this.nudCountedCash.DecimalPlaces = 2;
        this.nudCountedCash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.nudCountedCash.Location = new System.Drawing.Point(20, 60);
        this.nudCountedCash.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.nudCountedCash.Name = "nudCountedCash";
        this.nudCountedCash.Size = new System.Drawing.Size(200, 29);
        this.nudCountedCash.TabIndex = 1;
        this.nudCountedCash.ValueChanged += new System.EventHandler(this.NudCountedCash_ValueChanged);
        // 
        // lblCountedCash
        // 
        this.lblCountedCash.AutoSize = true;
        this.lblCountedCash.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblCountedCash.Location = new System.Drawing.Point(17, 35);
        this.lblCountedCash.Name = "lblCountedCash";
        this.lblCountedCash.Size = new System.Drawing.Size(149, 15);
        this.lblCountedCash.TabIndex = 0;
        this.lblCountedCash.Text = "Montant espèces compté :";
        // 
        // btnConfirmClose
        // 
        this.btnConfirmClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
        this.btnConfirmClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnConfirmClose.FlatAppearance.BorderSize = 0;
        this.btnConfirmClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnConfirmClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnConfirmClose.ForeColor = System.Drawing.Color.White;
        this.btnConfirmClose.Location = new System.Drawing.Point(275, 440);
        this.btnConfirmClose.Name = "btnConfirmClose";
        this.btnConfirmClose.Size = new System.Drawing.Size(260, 40);
        this.btnConfirmClose.TabIndex = 3;
        this.btnConfirmClose.Text = "🔒 Enregistrer la Clôture";
        this.btnConfirmClose.UseVisualStyleBackColor = false;
        this.btnConfirmClose.Click += new System.EventHandler(this.BtnConfirmClose_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
        this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.FlatAppearance.BorderSize = 0;
        this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnCancel.Location = new System.Drawing.Point(165, 440);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(100, 40);
        this.btnCancel.TabIndex = 4;
        this.btnCancel.Text = "Annuler";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
        // 
        // ShiftCloseForm
        // 
        this.AcceptButton = this.btnConfirmClose;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(560, 500);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirmClose);
        this.Controls.Add(this.grpCount);
        this.Controls.Add(this.grpSummary);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ShiftCloseForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Clôture de Caisse";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.grpSummary.ResumeLayout(false);
        this.grpCount.ResumeLayout(false);
        this.grpCount.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudCountedCash)).EndInit();
        this.ResumeLayout(false);
    }
}
