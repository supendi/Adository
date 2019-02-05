using Adository.CSharp.UI.Main;
using Adository.CSharp.UI.Nodes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adository.CSharp.UI.ServerBrowser
{
    public partial class ServerBrowserForm : Form
    {
        OpenServerConnectorCommand openServerConnectorCommand;
         
        RefreshServerCommand refreshServerCommand;
        DisconnectServerCommand disconnectServerCommand;
        OpenGeneratorCommand openGeneratorCommand;
        RefreshDatabaseCommand refreshDatabaseCommand;
        RefreshTableCommand refreshTableCommand;
        PreviewModelCommand previewModelCommand;
        PreviewQueryCommand previewSelectCommand;
        PreviewInsertCommand previewInsertCommand;
        PreviewUpdateCommand previewUpdateCommand;
        PreviewDeleteCommand previewDeleteCommand;
        PreviewRepositoryPackCommand previewRepositoryPackCommand;

        public TreeNode SelectedNode
        {
            get
            {
                return treeView.SelectedNode;
            }
        }

        public TreeView TreeView
        {
            get
            {
                return treeView;
            }
        }

        public List<string> DbServers
        {
            get
            {
                var servers = new List<string>();
                foreach (TreeNode server in treeView.Nodes)
                {
                    servers.Add(server.Name);
                }
                return servers;
            }
        }

        public MainForm MainForm { get; set; }

        public ServerBrowserForm()
        {
            InitializeComponent(); 
            InitCommands();
        }
 
        public void InitCommands()
        {
            openServerConnectorCommand = new OpenServerConnectorCommand(this);
            refreshServerCommand = new RefreshServerCommand(this);
            disconnectServerCommand = new DisconnectServerCommand(this);
            openGeneratorCommand = new OpenGeneratorCommand(this);
            refreshDatabaseCommand = new RefreshDatabaseCommand(this);
            refreshTableCommand = new RefreshTableCommand(this);
            previewModelCommand = new PreviewModelCommand(this);
            previewSelectCommand = new PreviewQueryCommand(this);
            previewInsertCommand = new PreviewInsertCommand(this);
            previewUpdateCommand = new PreviewUpdateCommand(this);
            previewDeleteCommand = new PreviewDeleteCommand(this);
            previewRepositoryPackCommand = new PreviewRepositoryPackCommand(this);
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewHitTestInfo hitTest = treeView.HitTest(e.Location);

                if (hitTest.Node != null)
                {
                    treeView.SelectedNode = hitTest.Node;
                    if (treeView.SelectedNode is ServerNode)
                    {
                        serverContextMenu.Show(MousePosition);
                    }
                    if (treeView.SelectedNode is DatabaseNode)
                    {
                        dbContextMenu.Show(MousePosition);
                    }
                    if (treeView.SelectedNode is TableNode)
                    {
                        tableContextMenu.Show(MousePosition);
                    }
                }
            }
        }
    }
}
