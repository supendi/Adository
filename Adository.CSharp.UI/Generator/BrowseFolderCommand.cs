using System;
using System.Windows.Forms;

namespace Adository.CSharp.UI.Generator
{
    public class BrowseFolderCommand : GeneratorCommandBase
    {
        public BrowseFolderCommand(GeneratorForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.Browse.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Browse();
        }

        private void Browse()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Form.ProjectFolder = dialog.SelectedPath;
                }
            }
        }
    }
}
