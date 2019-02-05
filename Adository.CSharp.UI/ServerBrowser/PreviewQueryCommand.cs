using Adository.CSharp.SqlServer.Models;
using Adository.CSharp.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.CSharp.UI.ServerBrowser
{
    public class PreviewQueryCommand : TableNodeCommand
    {
        public PreviewQueryCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.mnuPreviewSelectClass.Click += mnuPreviewSelectClass_Click;
        }

        private void mnuPreviewSelectClass_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private CSDocument GetSelectDocument(TableNode tableNode)
        { 
            var dbName = tableNode.DatabaseNode.Name;
            SetConnectionString(tableNode);
            var document = Generator.SelectProvider.CreateDocument(Generator.ServerManager.GetDataSet(dbName), tableNode.Name, tableNode.DatabaseNode.Name, tableNode.DatabaseNode.Name);
            return document;
        }

        public void Preview()
        {
            var selectedNode = Form.SelectedNode;
            if (IsTableNode())
            {
                Form.Cursor = Cursors.WaitCursor;

                var tableNode = selectedNode as TableNode;
                var document = GetSelectDocument(tableNode);
                OpenEditorForm(tableNode, document, $"{tableNode.Name}Query");

                Form.Cursor = Cursors.Default;
            }
        }
    }
}
