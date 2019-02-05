using Adository.CSharp.SqlServer.Models;
using Adository.CSharp.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.CSharp.UI.ServerBrowser
{
    public class PreviewRepositoryPackCommand : TableNodeCommand
    {
        public PreviewRepositoryPackCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.mnuPreviewRepositoryPackClass.Click += mnuPreviewRepositoryPackClass_Click;
        }

        private void mnuPreviewRepositoryPackClass_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private CSDocument GetRepositoryPackDocument(TableNode tableNode)
        { 
            var dbName = tableNode.DatabaseNode.Name;
            SetConnectionString(tableNode);
            var document = Generator.RepositoryPackProvider.CreateDocument(Generator.ServerManager.GetDataSet(dbName), tableNode.Name, tableNode.DatabaseNode.Name, tableNode.DatabaseNode.Name);
            return document;
        }

        public void Preview()
        {
            var selectedNode = Form.SelectedNode;
            if (IsTableNode())
            {
                Form.Cursor = Cursors.WaitCursor;

                var tableNode = selectedNode as TableNode;
                var document = GetRepositoryPackDocument(tableNode);
                OpenEditorForm(tableNode, document, $"{tableNode.Name}RepositoryPack");

                Form.Cursor = Cursors.Default;
            }
        }
    }
}
