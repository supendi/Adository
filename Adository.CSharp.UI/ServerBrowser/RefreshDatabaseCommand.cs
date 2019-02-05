using Adository.CSharp.UI.Nodes;
using System;

namespace Adository.CSharp.UI.ServerBrowser
{
    public class RefreshDatabaseCommand : ServerBrowserCommandBase
    {
        public RefreshDatabaseCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.refreshDatabaseMenu.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Refresh();
        }

        private bool IsDatabaseNode()
        {
            return (Form.SelectedNode != null && Form.SelectedNode is DatabaseNode);
        }

        public void Refresh()
        {
            if (IsDatabaseNode())
            {
                DatabaseNode databaseNode = Form.SelectedNode as DatabaseNode;
                databaseNode.Refresh();
            }
        }
    }
}
