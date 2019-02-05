using Adository.CSharp.SqlServer.Models;
using Adository.CSharp.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.CSharp.UI.ServerBrowser
{
    public class PreviewDeleteCommand : TableNodeCommand
    {
        public PreviewDeleteCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.mnuPreviewDeleteClass.Click += mnuPreviewDeleteClass_Click;
        }

        private void mnuPreviewDeleteClass_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private CSDocument GetDeleteDocument(TableNode tableNode)
        { 
            var dbName = tableNode.DatabaseNode.Name;
            SetConnectionString(tableNode);
            var document = Generator.DeleteProvider.Create(Generator.ServerManager.GetDataSet(dbName), tableNode.Name, tableNode.DatabaseNode.Name, tableNode.DatabaseNode.Name);
            return document;
        }

        public void Preview()
        {
            var selectedNode = Form.SelectedNode;
            if (IsTableNode())
            {
                Form.Cursor = Cursors.WaitCursor;

                var tableNode = selectedNode as TableNode;
                var document = GetDeleteDocument(tableNode);
                OpenEditorForm(tableNode, document, $"{tableNode.Name}Delete");

                Form.Cursor = Cursors.Default;
            }
        }
    }
}
