using Adository.VB.SqlServer.Models;
using Adository.VB.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.VB.UI.ServerBrowser
{
    public class PreviewUpdateCommand : TableNodeCommand
    {
        public PreviewUpdateCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.mnuPreviewUpdateClass.Click += mnuPreviewUpdateClass_Click;
        }

        private void mnuPreviewUpdateClass_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private VBDocument GetUpdateDocument(TableNode tableNode)
        { 
            var dbName = tableNode.DatabaseNode.Name;
            SetConnectionString(tableNode);
            var document = Generator.UpdateProvider.CreateDocument(Generator.ServerManager.GetDataSet(dbName), tableNode.Name, tableNode.DatabaseNode.Name, tableNode.DatabaseNode.Name);
            return document;
        }

        public void Preview()
        {
            var selectedNode = Form.SelectedNode;
            if (IsTableNode())
            {
                Form.Cursor = Cursors.WaitCursor;

                var tableNode = selectedNode as TableNode;
                var document = GetUpdateDocument(tableNode);
                OpenEditorForm(tableNode, document, $"{tableNode.Name}Update");

                Form.Cursor = Cursors.Default;
            }
        }
    }
}
