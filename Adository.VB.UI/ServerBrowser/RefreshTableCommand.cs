using Adository.VB.UI.Nodes;
using System;

namespace Adository.VB.UI.ServerBrowser
{
    public class RefreshTableCommand : ServerBrowserCommandBase
    {
        public RefreshTableCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.refreshTableMenu.Click += refreshTableMenu_Click;
        }
 
        private void refreshTableMenu_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private bool IsTableNode()
        {
            return (Form.SelectedNode != null && Form.SelectedNode is TableNode);
        }

        private void Refresh()
        {
            var selectedNode = Form.SelectedNode;
            if (selectedNode != null && selectedNode is TableNode)
            {
                TableNode tableNode = selectedNode as TableNode;
                tableNode.Refresh();
            }
        }
    }
}
