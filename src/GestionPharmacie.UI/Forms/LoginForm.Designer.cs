namespace GestionPharmacie.UI.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnTogglePassword;
    private System.Windows.Forms.Label lblErrorMessage;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Panel pnlCard;
    private System.Windows.Forms.Label lblAppVersion;

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
        this.pnlCard = new System.Windows.Forms.Panel();
        this.lblAppVersion = new System.Windows.Forms.Label();
        this.lblUsername = new System.Windows.Forms.Label();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.lblPassword = new System.Windows.Forms.Label();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.btnTogglePassword = new System.Windows.Forms.Button();
        this.lblErrorMessage = new System.Windows.Forms.Label();
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.pnlHeader.SuspendLayout();
        this.pnlCard.SuspendLayout();
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
        this.pnlHeader.Size = new System.Drawing.Size(460, 95);
        this.pnlHeader.TabIndex = 0;
        // 
        // lblHeaderSubtitle
        // 
        this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
        this.lblHeaderSubtitle.Location = new System.Drawing.Point(20, 52);
        this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        this.lblHeaderSubtitle.Size = new System.Drawing.Size(420, 24);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Authentification sécurisée & gestion officine";
        this.lblHeaderSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
        this.lblHeaderTitle.Location = new System.Drawing.Point(20, 16);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(420, 32);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "PHARMA-GESTION";
        this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlCard
        // 
        this.pnlCard.BackColor = System.Drawing.Color.White;
        this.pnlCard.Controls.Add(this.lblAppVersion);
        this.pnlCard.Controls.Add(this.lblUsername);
        this.pnlCard.Controls.Add(this.txtUsername);
        this.pnlCard.Controls.Add(this.lblPassword);
        this.pnlCard.Controls.Add(this.txtPassword);
        this.pnlCard.Controls.Add(this.btnTogglePassword);
        this.pnlCard.Controls.Add(this.lblErrorMessage);
        this.pnlCard.Controls.Add(this.btnLogin);
        this.pnlCard.Controls.Add(this.btnCancel);
        this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCard.Location = new System.Drawing.Point(0, 95);
        this.pnlCard.Name = "pnlCard";
        this.pnlCard.Padding = new System.Windows.Forms.Padding(35, 25, 35, 20);
        this.pnlCard.Size = new System.Drawing.Size(460, 335);
        this.pnlCard.TabIndex = 1;
        // 
        // lblAppVersion
        // 
        this.lblAppVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
        this.lblAppVersion.ForeColor = System.Drawing.Color.Gray;
        this.lblAppVersion.Location = new System.Drawing.Point(35, 298);
        this.lblAppVersion.Name = "lblAppVersion";
        this.lblAppVersion.Size = new System.Drawing.Size(390, 20);
        this.lblAppVersion.TabIndex = 8;
        this.lblAppVersion.Text = "v1.0.0 • SQLite Chiffré & Audit Actif";
        this.lblAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblUsername
        // 
        this.lblUsername.AutoSize = true;
        this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.lblUsername.Location = new System.Drawing.Point(35, 18);
        this.lblUsername.Name = "lblUsername";
        this.lblUsername.Size = new System.Drawing.Size(127, 17);
        this.lblUsername.TabIndex = 0;
        this.lblUsername.Text = "Nom d'utilisateur :";
        // 
        // txtUsername
        // 
        this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.txtUsername.Location = new System.Drawing.Point(38, 40);
        this.txtUsername.MaxLength = 50;
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new System.Drawing.Size(384, 27);
        this.txtUsername.TabIndex = 1;
        // 
        // lblPassword
        // 
        this.lblPassword.AutoSize = true;
        this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.lblPassword.Location = new System.Drawing.Point(35, 80);
        this.lblPassword.Name = "lblPassword";
        this.lblPassword.Size = new System.Drawing.Size(98, 17);
        this.lblPassword.TabIndex = 2;
        this.lblPassword.Text = "Mot de passe :";
        // 
        // txtPassword
        // 
        this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.txtPassword.Location = new System.Drawing.Point(38, 102);
        this.txtPassword.MaxLength = 100;
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Size = new System.Drawing.Size(342, 27);
        this.txtPassword.TabIndex = 3;
        this.txtPassword.UseSystemPasswordChar = true;
        // 
        // btnTogglePassword
        // 
        this.btnTogglePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
        this.btnTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTogglePassword.FlatAppearance.BorderSize = 0;
        this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnTogglePassword.Location = new System.Drawing.Point(383, 102);
        this.btnTogglePassword.Name = "btnTogglePassword";
        this.btnTogglePassword.Size = new System.Drawing.Size(39, 27);
        this.btnTogglePassword.TabIndex = 4;
        this.btnTogglePassword.Text = "👁";
        this.btnTogglePassword.UseVisualStyleBackColor = false;
        this.btnTogglePassword.Click += new System.EventHandler(this.BtnTogglePassword_Click);
        // 
        // lblErrorMessage
        // 
        this.lblErrorMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
        this.lblErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
        this.lblErrorMessage.Location = new System.Drawing.Point(38, 137);
        this.lblErrorMessage.Name = "lblErrorMessage";
        this.lblErrorMessage.Size = new System.Drawing.Size(384, 38);
        this.lblErrorMessage.TabIndex = 5;
        this.lblErrorMessage.Text = "Identifiant ou mot de passe incorrect.";
        this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblErrorMessage.Visible = false;
        // 
        // btnLogin
        // 
        this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLogin.FlatAppearance.BorderSize = 0;
        this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnLogin.ForeColor = System.Drawing.Color.White;
        this.btnLogin.Location = new System.Drawing.Point(38, 185);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new System.Drawing.Size(384, 42);
        this.btnLogin.TabIndex = 6;
        this.btnLogin.Text = "Se connecter";
        this.btnLogin.UseVisualStyleBackColor = false;
        this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.BackColor = System.Drawing.Color.Transparent;
        this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.FlatAppearance.BorderSize = 0;
        this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        this.btnCancel.Location = new System.Drawing.Point(38, 235);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(384, 32);
        this.btnCancel.TabIndex = 7;
        this.btnCancel.Text = "Quitter l'application";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
        // 
        // LoginForm
        // 
        this.AcceptButton = this.btnLogin;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(460, 430);
        this.Controls.Add(this.pnlCard);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "LoginForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Connexion - Pharmacie";
        this.pnlHeader.ResumeLayout(false);
        this.pnlCard.ResumeLayout(false);
        this.pnlCard.PerformLayout();
        this.ResumeLayout(false);
    }
}
