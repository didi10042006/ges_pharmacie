using System.Text;

namespace GestionPharmacie.UI.Forms;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();
        LoadLicenseText();
    }

    private void LoadLicenseText()
    {
        var sb = new StringBuilder();
        sb.AppendLine("MIT License");
        sb.AppendLine();
        sb.AppendLine("Copyright (c) 2026 Dzaba Diliane Merveille");
        sb.AppendLine();
        sb.AppendLine("Permission is hereby granted, free of charge, to any person obtaining a copy");
        sb.AppendLine("of this software and associated documentation files (the \"Software\"), to deal");
        sb.AppendLine("in the Software without restriction, including without limitation the rights");
        sb.AppendLine("to use, copy, modify, merge, publish, distribute, sublicense, and/or sell");
        sb.AppendLine("copies of the Software, and to permit persons to whom the Software is");
        sb.AppendLine("furnished to do so, subject to the following conditions:");
        sb.AppendLine();
        sb.AppendLine("The above copyright notice and this permission notice shall be included in all");
        sb.AppendLine("copies or substantial portions of the Software.");
        sb.AppendLine();
        sb.AppendLine("THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR");
        sb.AppendLine("IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,");
        sb.AppendLine("FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE");
        sb.AppendLine("AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER");
        sb.AppendLine("LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,");
        sb.AppendLine("OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE");
        sb.AppendLine("SOFTWARE.");

        txtLicenseFull.Text = sb.ToString();
        txtLicenseFull.SelectionStart = 0;
        txtLicenseFull.SelectionLength = 0;
    }
}
