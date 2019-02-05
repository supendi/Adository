using Adository.VB.SqlServer.Models;
using Adository.VB.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.VB.UI.ServerBrowser
{
    public class PreviewModelCommand : TableNodeCommand
    {
        public PreviewModelCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.mnuPreviewModelClass.Click += mnuPreviewModelClass_Click;
        }

        private void mnuPreviewModelClass_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private VBDocument GetModelDocument(TableNode tableNode)
        { 
            var dbName = tableNode.DatabaseNode.Name;
            SetConnectionString(tableNode);
            var document = Generator.ModelProvider.CreateDocument(Generator.ServerManager.GetDataSet(dbName), tableNode.Name, tableNode.DatabaseNode.Name, tableNode.DatabaseNode.Name);
            return document;
        }

        public void Preview()
        {
            var selectedNode = Form.SelectedNode;
            if (IsTableNode())
            {
                Form.Cursor = Cursors.WaitCursor;

                var tableNode = selectedNode as TableNode;
                var document = GetModelDocument(tableNode);
                OpenEditorForm(tableNode, document, $"{tableNode.Name}");

                Form.Cursor = Cursors.Default;
            }
        }
    }
}
