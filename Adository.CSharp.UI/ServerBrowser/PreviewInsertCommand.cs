using Adository.CSharp.SqlServer.Models;
using Adository.CSharp.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.CSharp.UI.ServerBrowser
{
    public class PreviewInsertCommand : TableNodeCommand
    {
        public PreviewInsertCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.mnuPreviewInsertClass.Click += mnuPreviewInsertClass_Click;
        }

        private void mnuPreviewInsertClass_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private CSDocument GetInsertDocument(TableNode tableNode)
        { 
            var dbName = tableNode.DatabaseNode.Name;
            SetConnectionString(tableNode);
            var document = Generator.InsertProvider.Create(Generator.ServerManager.GetDataSet(dbName), tableNode.Name, tableNode.DatabaseNode.Name, tableNode.DatabaseNode.Name);
            return document;
        }

        public void Preview()
        {
            var selectedNode = Form.SelectedNode;
            if (IsTableNode())
            {
                Form.Cursor = Cursors.WaitCursor;

                var tableNode = selectedNode as TableNode;
                var document = GetInsertDocument(tableNode);
                OpenEditorForm(tableNode, document, $"{tableNode.Name}Insert");

                Form.Cursor = Cursors.Default;
            }
        }
    }
}
