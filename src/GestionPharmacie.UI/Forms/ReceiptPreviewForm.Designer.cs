namespace GestionPharmacie.UI.Forms;

partial class ReceiptPreviewForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.RichTextBox rtbReceipt;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Button btnPrint;
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
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.rtbReceipt = new System.Windows.Forms.RichTextBox();
        this.pnlFooter = new System.Windows.Forms.Panel();
        this.btnPrint = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.pnlHeader.SuspendLayout();
        this.pnlFooter.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
        this.pnlHeader.Size = new System.Drawing.Size(430, 45);
        this.pnlHeader.TabIndex = 0;
        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
        this.lblHeaderTitle.Location = new System.Drawing.Point(15, 12);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new System.Drawing.Size(188, 20);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "🧾 Aperçu Ticket de Caisse";
        // 
        // rtbReceipt
        // 
        this.rtbReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
        this.rtbReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtbReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtbReceipt.Font = new System.Drawing.Font("Consolas", 9.5F);
        this.rtbReceipt.Location = new System.Drawing.Point(0, 45);
        this.rtbReceipt.Name = "rtbReceipt";
        this.rtbReceipt.ReadOnly = true;
        this.rtbReceipt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        this.rtbReceipt.Size = new System.Drawing.Size(430, 475);
        this.rtbReceipt.TabIndex = 1;
        this.rtbReceipt.Text = "";
        // 
        // pnlFooter
        // 
        this.pnlFooter.BackColor = System.Drawing.Color.White;
        this.pnlFooter.Controls.Add(this.btnPrint);
        this.pnlFooter.Controls.Add(this.btnClose);
        this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlFooter.Location = new System.Drawing.Point(0, 520);
        this.pnlFooter.Name = "pnlFooter";
        this.pnlFooter.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
        this.pnlFooter.Size = new System.Drawing.Size(430, 55);
        this.pnlFooter.TabIndex = 2;
        // 
        // btnPrint
        // 
        this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(87)))));
        this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnPrint.FlatAppearance.BorderSize = 0;
        this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnPrint.ForeColor = System.Drawing.Color.White;
        this.btnPrint.Location = new System.Drawing.Point(180, 10);
        this.btnPrint.Name = "btnPrint";
        this.btnPrint.Size = new System.Drawing.Size(145, 34);
        this.btnPrint.TabIndex = 1;
        this.btnPrint.Text = "🖨 Imprimer Ticket";
        this.btnPrint.UseVisualStyleBackColor = false;
        this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
        this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.btnClose.FlatAppearance.BorderSize = 0;
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnClose.Location = new System.Drawing.Point(335, 10);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(80, 34);
        this.btnClose.TabIndex = 0;
        this.btnClose.Text = "Fermer";
        this.btnClose.UseVisualStyleBackColor = false;
        this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
        // 
        // ReceiptPreviewForm
        // 
        this.AcceptButton = this.btnPrint;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnClose;
        this.ClientSize = new System.Drawing.Size(430, 575);
        this.Controls.Add(this.rtbReceipt);
        this.Controls.Add(this.pnlFooter);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ReceiptPreviewForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Ticket de caisse";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFooter.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
