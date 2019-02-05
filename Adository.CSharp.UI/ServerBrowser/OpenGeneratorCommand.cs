using Adository.CSharp.UI.Generator;
using Adository.CSharp.UI.Nodes;
using System;

namespace Adository.CSharp.UI.ServerBrowser
{
    public class OpenGeneratorCommand : ServerBrowserCommandBase
    {
        public OpenGeneratorCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.generateRepositoryMenu.Click += OnClick;
        }

        private bool IsDatabaseNode()
        {
            return (Form.SelectedNode != null && Form.SelectedNode is DatabaseNode);
        }

        private void OnClick(object sender, EventArgs e)
        {
            OpenGeneratorForm();
        }

        public void OpenGeneratorForm()
        {
            if (IsDatabaseNode())
            {
                var databaseNode = Form.SelectedNode as DatabaseNode;
                using (var frm = new GeneratorForm(databaseNode))
                {
                    frm.ShowDialog();
                }
            }
        }
    }
}
