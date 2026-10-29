namespace GestionPharmacie.UI.Forms;

partial class DiscountApprovalDialog
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblHeader;
    private System.Windows.Forms.Label lblDiscount;
    private System.Windows.Forms.NumericUpDown nudDiscountAmount;
    private System.Windows.Forms.Label lblSupervisorUser;
    private System.Windows.Forms.TextBox txtSupervisorUsername;
    private System.Windows.Forms.Label lblSupervisorPass;
    private System.Windows.Forms.TextBox txtSupervisorPassword;
    private System.Windows.Forms.Button btnApprove;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblError;
    private System.Windows.Forms.Label lblNotice;

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
        this.lblHeader = new System.Windows.Forms.Label();
        this.lblDiscount = new System.Windows.Forms.Label();
        this.nudDiscountAmount = new System.Windows.Forms.NumericUpDown();
        this.lblSupervisorUser = new System.Windows.Forms.Label();
        this.txtSupervisorUsername = new System.Windows.Forms.TextBox();
        this.lblSupervisorPass = new System.Windows.Forms.Label();
        this.txtSupervisorPassword = new System.Windows.Forms.TextBox();
        this.btnApprove = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.lblError = new System.Windows.Forms.Label();
        this.lblNotice = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.nudDiscountAmount)).BeginInit();
        this.SuspendLayout();
        // 
        // lblHeader
        // 
        this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
        this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblHeader.ForeColor = System.Drawing.Color.White;
        this.lblHeader.Location = new System.Drawing.Point(0, 0);
        this.lblHeader.Name = "lblHeader";
        this.lblHeader.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
        this.lblHeader.Size = new System.Drawing.Size(420, 50);
        this.lblHeader.TabIndex = 0;
        this.lblHeader.Text = "🔒 Autorisation de Remise Commerciale";
        this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNotice
        // 
        this.lblNotice.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.lblNotice.Location = new System.Drawing.Point(25, 60);
        this.lblNotice.Name = "lblNotice";
        this.lblNotice.Size = new System.Drawing.Size(370, 35);
        this.lblNotice.TabIndex = 1;
        this.lblNotice.Text = "L'application d'une remise sur une vente requiert l'authentification explicite d\'un Responsable ou Administrateur.";
        // 
        // lblDiscount
        // 
        this.lblDiscount.AutoSize = true;
        this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDiscount.Location = new System.Drawing.Point(25, 105);
        this.lblDiscount.Name = "lblDiscount";
        this.lblDiscount.Size = new System.Drawing.Size(183, 17);
        this.lblDiscount.TabIndex = 2;
        this.lblDiscount.Text = "Montant de la remise (€) :";
        // 
        // nudDiscountAmount
        // 
        this.nudDiscountAmount.DecimalPlaces = 2;
        this.nudDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.nudDiscountAmount.Location = new System.Drawing.Point(28, 127);
        this.nudDiscountAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        this.nudDiscountAmount.Name = "nudDiscountAmount";
        this.nudDiscountAmount.Size = new System.Drawing.Size(364, 27);
        this.nudDiscountAmount.TabIndex = 3;
        // 
        // lblSupervisorUser
        // 
        this.lblSupervisorUser.AutoSize = true;
        this.lblSupervisorUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblSupervisorUser.Location = new System.Drawing.Point(25, 168);
        this.lblSupervisorUser.Name = "lblSupervisorUser";
        this.lblSupervisorUser.Size = new System.Drawing.Size(193, 17);
        this.lblSupervisorUser.TabIndex = 4;
        this.lblSupervisorUser.Text = "Identifiant du Responsable :";
        // 
        // txtSupervisorUsername
        // 
        this.txtSupervisorUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtSupervisorUsername.Location = new System.Drawing.Point(28, 190);
        this.txtSupervisorUsername.MaxLength = 50;
        this.txtSupervisorUsername.Name = "txtSupervisorUsername";
        this.txtSupervisorUsername.Size = new System.Drawing.Size(364, 25);
        this.txtSupervisorUsername.TabIndex = 5;
        // 
        // lblSupervisorPass
        // 
        this.lblSupervisorPass.AutoSize = true;
        this.lblSupervisorPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblSupervisorPass.Location = new System.Drawing.Point(25, 228);
        this.lblSupervisorPass.Name = "lblSupervisorPass";
        this.lblSupervisorPass.Size = new System.Drawing.Size(201, 17);
        this.lblSupervisorPass.TabIndex = 6;
        this.lblSupervisorPass.Text = "Mot de passe du Responsable :";
        // 
        // txtSupervisorPassword
        // 
        this.txtSupervisorPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtSupervisorPassword.Location = new System.Drawing.Point(28, 250);
        this.txtSupervisorPassword.MaxLength = 100;
        this.txtSupervisorPassword.Name = "txtSupervisorPassword";
        this.txtSupervisorPassword.Size = new System.Drawing.Size(364, 25);
        this.txtSupervisorPassword.TabIndex = 7;
        this.txtSupervisorPassword.UseSystemPasswordChar = true;
        // 
        // lblError
        // 
        this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
        this.lblError.Location = new System.Drawing.Point(28, 285);
        this.lblError.Name = "lblError";
        this.lblError.Size = new System.Drawing.Size(364, 30);
        this.lblError.TabIndex = 8;
        this.lblError.Visible = false;
        // 
        // btnApprove
        // 
        this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
        this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnApprove.FlatAppearance.BorderSize = 0;
        this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnApprove.ForeColor = System.Drawing.Color.White;
        this.btnApprove.Location = new System.Drawing.Point(192, 325);
        this.btnApprove.Name = "btnApprove";
        this.btnApprove.Size = new System.Drawing.Size(120, 36);
        this.btnApprove.TabIndex = 9;
        this.btnApprove.Text = "Valider Remise";
        this.btnApprove.UseVisualStyleBackColor = false;
        this.btnApprove.Click += new System.EventHandler(this.BtnApprove_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
        this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.FlatAppearance.BorderSize = 0;
        this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnCancel.Location = new System.Drawing.Point(318, 325);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(74, 36);
        this.btnCancel.TabIndex = 10;
        this.btnCancel.Text = "Annuler";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
        // 
        // DiscountApprovalDialog
        // 
        this.AcceptButton = this.btnApprove;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(420, 380);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnApprove);
        this.Controls.Add(this.lblError);
        this.Controls.Add(this.txtSupervisorPassword);
        this.Controls.Add(this.lblSupervisorPass);
        this.Controls.Add(this.txtSupervisorUsername);
        this.Controls.Add(this.lblSupervisorUser);
        this.Controls.Add(this.nudDiscountAmount);
        this.Controls.Add(this.lblDiscount);
        this.Controls.Add(this.lblNotice);
        this.Controls.Add(this.lblHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "DiscountApprovalDialog";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Validation Remise";
        ((System.ComponentModel.ISupportInitialize)(this.nudDiscountAmount)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
