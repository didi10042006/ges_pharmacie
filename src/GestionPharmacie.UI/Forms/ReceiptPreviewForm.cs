using System.Drawing.Printing;

namespace GestionPharmacie.UI.Forms;

public partial class ReceiptPreviewForm : Form
{
    private readonly string _receiptText;

    public ReceiptPreviewForm(string receiptText)
    {
        _receiptText = receiptText ?? string.Empty;
        InitializeComponent();

        rtbReceipt.Text = _receiptText;
    }

    private void BtnPrint_Click(object? sender, EventArgs e)
    {
        try
        {
            var printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) =>
            {
                using var font = new Font("Consolas", 8.5F, FontStyle.Regular);
                var margin = 20;
                ev.Graphics?.DrawString(_receiptText, font, Brushes.Black, margin, margin);
                ev.HasMorePages = false;
            };

            using var printDialog = new PrintDialog { Document = printDoc };
            if (printDialog.ShowDialog(this) == DialogResult.OK)
            {
                printDoc.Print();
                MessageBox.Show("Impression envoyée avec succès à l'imprimante.", "Impression terminée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'impression : {ex.Message}", "Erreur d'impression", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
