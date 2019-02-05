using Adository.WFL;
using System;
using System.Windows.Forms;

namespace Adository.VB.UI.ServerBrowser
{
    public class DisconnectServerCommand : ServerBrowserCommandBase
    {
        public DisconnectServerCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.disconnectServerMenu.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Disconnect();
        }
      
        private void Disconnect()
        {
            Form.Cursor = Cursors.WaitCursor;
            var selectedNode = Form.SelectedNode;
            if (MsgBox.YesNo($"Disconnect from '{selectedNode.Text}'?") == DialogResult.Yes)
            {
                Form.TreeView.Nodes.Remove(selectedNode);
            }
            Form.Cursor = Cursors.Default;
        }
    }
}
