using Adository.Common;
using System.Windows.Forms;

namespace Adository.VB.UI.SourceEditor
{
    public partial class SCEditorForm : Form
    {
        public IDocument Document { get; set; }
        public SCEditorForm()
        {
            InitializeComponent();
        }

        public SCEditorForm(IDocument document)
        {
            InitializeComponent();
            Document = document;
            browser.DocumentText = document.GetSourceCode();
            txtSource.Text = document.GetSourceCode();
        }

        public void SetText(string text)
        {
            browser.DocumentText = text;
            txtSource.Text = text;
        }

        public void SaveFile()
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.FileName = this.Text.Replace(" ", "");
                dlg.Filter = "VB File | .cs";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Document.Save(dlg.FileName);
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveFile();
        }
    }
}
