namespace GestionPharmacie.UI.Forms;

partial class ProductEditDialog
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblReference;
    private System.Windows.Forms.TextBox txtReference;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.ComboBox cboCategory;
    private System.Windows.Forms.Label lblDosage;
    private System.Windows.Forms.TextBox txtDosage;
    private System.Windows.Forms.Label lblForm;
    private System.Windows.Forms.ComboBox cboForm;
    private System.Windows.Forms.Label lblSellingPrice;
    private System.Windows.Forms.NumericUpDown nudSellingPrice;
    private System.Windows.Forms.Label lblMinStock;
    private System.Windows.Forms.NumericUpDown nudMinStock;
    private System.Windows.Forms.CheckBox chkIsArchived;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblError;

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
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblReference = new System.Windows.Forms.Label();
        this.txtReference = new System.Windows.Forms.TextBox();
        this.lblName = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.lblCategory = new System.Windows.Forms.Label();
        this.cboCategory = new System.Windows.Forms.ComboBox();
        this.lblDosage = new System.Windows.Forms.Label();
        this.txtDosage = new System.Windows.Forms.TextBox();
        this.lblForm = new System.Windows.Forms.Label();
        this.cboForm = new System.Windows.Forms.ComboBox();
        this.lblSellingPrice = new System.Windows.Forms.Label();
        this.nudSellingPrice = new System.Windows.Forms.NumericUpDown();
        this.lblMinStock = new System.Windows.Forms.Label();
        this.nudMinStock = new System.Windows.Forms.NumericUpDown();
        this.chkIsArchived = new System.Windows.Forms.CheckBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.lblError = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.nudSellingPrice)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudMinStock)).BeginInit();
        this.SuspendLayout();
        // 
        // lblTitle
        // 
        this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.White;
        this.lblTitle.Location = new System.Drawing.Point(0, 0);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.lblTitle.Size = new System.Drawing.Size(520, 50);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Fiche Médicament / Produit";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblReference
        // 
        this.lblReference.AutoSize = true;
        this.lblReference.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblReference.Location = new System.Drawing.Point(25, 65);
        this.lblReference.Name = "lblReference";
        this.lblReference.Size = new System.Drawing.Size(126, 17);
        this.lblReference.TabIndex = 1;
        this.lblReference.Text = "Référence unique *";
        // 
        // txtReference
        // 
        this.txtReference.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtReference.Location = new System.Drawing.Point(28, 85);
        this.txtReference.MaxLength = 50;
        this.txtReference.Name = "txtReference";
        this.txtReference.Size = new System.Drawing.Size(220, 25);
        this.txtReference.TabIndex = 2;
        // 
        // lblCategory
        // 
        this.lblCategory.AutoSize = true;
        this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblCategory.Location = new System.Drawing.Point(270, 65);
        this.lblCategory.Name = "lblCategory";
        this.lblCategory.Size = new System.Drawing.Size(68, 17);
        this.lblCategory.TabIndex = 3;
        this.lblCategory.Text = "Catégorie";
        // 
        // cboCategory
        // 
        this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboCategory.FormattingEnabled = true;
        this.cboCategory.Location = new System.Drawing.Point(273, 85);
        this.cboCategory.Name = "cboCategory";
        this.cboCategory.Size = new System.Drawing.Size(220, 25);
        this.cboCategory.TabIndex = 4;
        // 
        // lblName
        // 
        this.lblName.AutoSize = true;
        this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblName.Location = new System.Drawing.Point(25, 125);
        this.lblName.Name = "lblName";
        this.lblName.Size = new System.Drawing.Size(155, 17);
        this.lblName.TabIndex = 5;
        this.lblName.Text = "Désignation complète *";
        // 
        // txtName
        // 
        this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtName.Location = new System.Drawing.Point(28, 145);
        this.txtName.MaxLength = 150;
        this.txtName.Name = "txtName";
        this.txtName.Size = new System.Drawing.Size(465, 25);
        this.txtName.TabIndex = 6;
        // 
        // lblDosage
        // 
        this.lblDosage.AutoSize = true;
        this.lblDosage.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDosage.Location = new System.Drawing.Point(25, 185);
        this.lblDosage.Name = "lblDosage";
        this.lblDosage.Size = new System.Drawing.Size(54, 17);
        this.lblDosage.TabIndex = 7;
        this.lblDosage.Text = "Dosage";
        // 
        // txtDosage
        // 
        this.txtDosage.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtDosage.Location = new System.Drawing.Point(28, 205);
        this.txtDosage.MaxLength = 50;
        this.txtDosage.Name = "txtDosage";
        this.txtDosage.PlaceholderText = "ex: 1000mg, 500mg/5ml";
        this.txtDosage.Size = new System.Drawing.Size(220, 25);
        this.txtDosage.TabIndex = 8;
        // 
        // lblForm
        // 
        this.lblForm.AutoSize = true;
        this.lblForm.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblForm.Location = new System.Drawing.Point(270, 185);
        this.lblForm.Name = "lblForm";
        this.lblForm.Size = new System.Drawing.Size(107, 17);
        this.lblForm.TabIndex = 9;
        this.lblForm.Text = "Forme galénique";
        // 
        // cboForm
        // 
        this.cboForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboForm.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboForm.FormattingEnabled = true;
        this.cboForm.Items.AddRange(new object[] {
            "Comprimé",
            "Gélule",
            "Sirop",
            "Pommade",
            "Solution injectable",
            "Gouttes",
            "Suppositoire",
            "Autre"});
        this.cboForm.Location = new System.Drawing.Point(273, 205);
        this.cboForm.Name = "cboForm";
        this.cboForm.Size = new System.Drawing.Size(220, 25);
        this.cboForm.TabIndex = 10;
        // 
        // lblSellingPrice
        // 
        this.lblSellingPrice.AutoSize = true;
        this.lblSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblSellingPrice.Location = new System.Drawing.Point(25, 245);
        this.lblSellingPrice.Name = "lblSellingPrice";
        this.lblSellingPrice.Size = new System.Drawing.Size(126, 17);
        this.lblSellingPrice.TabIndex = 11;
        this.lblSellingPrice.Text = "Prix de vente TTC *";
        // 
        // nudSellingPrice
        // 
        this.nudSellingPrice.DecimalPlaces = 2;
        this.nudSellingPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.nudSellingPrice.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
        this.nudSellingPrice.Location = new System.Drawing.Point(28, 265);
        this.nudSellingPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.nudSellingPrice.Name = "nudSellingPrice";
        this.nudSellingPrice.Size = new System.Drawing.Size(220, 25);
        this.nudSellingPrice.TabIndex = 12;
        // 
        // lblMinStock
        // 
        this.lblMinStock.AutoSize = true;
        this.lblMinStock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblMinStock.Location = new System.Drawing.Point(270, 245);
        this.lblMinStock.Name = "lblMinStock";
        this.lblMinStock.Size = new System.Drawing.Size(149, 17);
        this.lblMinStock.TabIndex = 13;
        this.lblMinStock.Text = "Seuil d'alerte stock min";
        // 
        // nudMinStock
        // 
        this.nudMinStock.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.nudMinStock.Location = new System.Drawing.Point(273, 265);
        this.nudMinStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        this.nudMinStock.Name = "nudMinStock";
        this.nudMinStock.Size = new System.Drawing.Size(220, 25);
        this.nudMinStock.TabIndex = 14;
        this.nudMinStock.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // chkIsArchived
        // 
        this.chkIsArchived.AutoSize = true;
        this.chkIsArchived.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.chkIsArchived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        this.chkIsArchived.Location = new System.Drawing.Point(28, 305);
        this.chkIsArchived.Name = "chkIsArchived";
        this.chkIsArchived.Size = new System.Drawing.Size(262, 21);
        this.chkIsArchived.TabIndex = 15;
        this.chkIsArchived.Text = "Archiver ce produit (masqué des ventes)";
        this.chkIsArchived.UseVisualStyleBackColor = true;
        // 
        // lblError
        // 
        this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
        this.lblError.Location = new System.Drawing.Point(28, 335);
        this.lblError.Name = "lblError";
        this.lblError.Size = new System.Drawing.Size(465, 30);
        this.lblError.TabIndex = 16;
        this.lblError.Visible = false;
        // 
        // btnSave
        // 
        this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnSave.FlatAppearance.BorderSize = 0;
        this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(253, 375);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(140, 36);
        this.btnSave.TabIndex = 17;
        this.btnSave.Text = "Enregistrer";
        this.btnSave.UseVisualStyleBackColor = false;
        this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
        this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.FlatAppearance.BorderSize = 0;
        this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnCancel.Location = new System.Drawing.Point(403, 375);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(90, 36);
        this.btnCancel.TabIndex = 18;
        this.btnCancel.Text = "Annuler";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
        // 
        // ProductEditDialog
        // 
        this.AcceptButton = this.btnSave;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(520, 430);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.lblError);
        this.Controls.Add(this.chkIsArchived);
        this.Controls.Add(this.nudMinStock);
        this.Controls.Add(this.lblMinStock);
        this.Controls.Add(this.nudSellingPrice);
        this.Controls.Add(this.lblSellingPrice);
        this.Controls.Add(this.cboForm);
        this.Controls.Add(this.lblForm);
        this.Controls.Add(this.txtDosage);
        this.Controls.Add(this.lblDosage);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblName);
        this.Controls.Add(this.cboCategory);
        this.Controls.Add(this.lblCategory);
        this.Controls.Add(this.txtReference);
        this.Controls.Add(this.lblReference);
        this.Controls.Add(this.lblTitle);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ProductEditDialog";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Fiche Produit";
        ((System.ComponentModel.ISupportInitialize)(this.nudSellingPrice)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudMinStock)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
