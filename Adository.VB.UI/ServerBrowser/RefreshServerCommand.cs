using Adository.VB.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.VB.UI.ServerBrowser
{
    public class RefreshServerCommand : ServerBrowserCommandBase
    {

        public RefreshServerCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.refreshServerMenu.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            Form.Cursor = Cursors.WaitCursor;
            var selectedNode = Form.SelectedNode;
            if (selectedNode != null && selectedNode is ServerNode)
            {
                ServerNode serverNode = selectedNode as ServerNode;
                serverNode.Refresh();
            }
            Form.Cursor = Cursors.Default;
        }
    }
}
