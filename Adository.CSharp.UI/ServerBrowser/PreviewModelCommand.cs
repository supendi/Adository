using Adository.CSharp.SqlServer.Models;
using Adository.CSharp.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.CSharp.UI.ServerBrowser
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

        private CSDocument GetModelDocument(TableNode tableNode)
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
