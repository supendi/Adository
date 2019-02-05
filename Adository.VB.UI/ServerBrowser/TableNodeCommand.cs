using Adository.Common;
using Adository.VB.UI.Nodes;
using Adository.VB.UI.SourceEditor;

namespace Adository.VB.UI.ServerBrowser
{
    public class TableNodeCommand : ServerBrowserCommandBase
    {
        protected AdositoryGenerator Generator { get; private set; }

        public TableNodeCommand(ServerBrowserForm form) : base(form)
        {
            Generator = AdositoryGeneratorSingleton.GetInstance();
        }

        protected override void InitEvents()
        {
        }

        protected bool IsTableNode()
        {
            return (Form.SelectedNode != null && Form.SelectedNode is TableNode);
        }

        protected void OpenEditorForm(TableNode tableNode, IDocument document, string fileName)
        {
            var frmTextEditor = new SCEditorForm(document);

            frmTextEditor.Text = $"{fileName}.cs";
            Form.MainForm.Tab.OpenForm(frmTextEditor, true);
        }

        protected void SetConnectionString(TableNode tableNode)
        {
            if (Generator.ServerManager.DbAccess.Connection.ConnectionString == tableNode.ConnectionString)
                return;
            if (Generator.ServerManager.DbAccess.Connection.State == System.Data.ConnectionState.Open)
                Generator.ServerManager.DbAccess.Connection.Close();
            Generator.ServerManager.DbAccess.Connection.ConnectionString = tableNode.ConnectionString;
        }
    }
}
