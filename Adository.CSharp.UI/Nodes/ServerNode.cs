using Adository.Common;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Adository.CSharp.UI.Nodes
{
    public class ServerNode : TreeNode
    {
        private DbServerModel server;

        public string ConnectionString
        {
            get
            {
                return server.ConnectionString;
            }
        }

        public ServerNode(DbServerModel server)
        {
            this.server = server;
            this.Text = server.Name;
            this.Name = server.Name;
            this.ImageIndex = 0;
            this.SelectedImageIndex = 0;
            InitDatabases();
        }

        private void InitDatabases()
        {
            if (server == null) return;
            server.DataSets = server.DataSets.OrderBy(x => x.DataSetName).ToList();
            foreach (DataSet dataset in server.DataSets)
            {
                var node = new DatabaseNode(dataset);
                this.Nodes.Add(node);
            }
        }

        public void Refresh()
        {
            //using (var serverManager = new DbServerManager(ConnectionString))
            //{
            //    this.Nodes.Clear();
            //    server = serverManager.Connect();
            //    InitDatabases();
            //}

            this.Nodes.Clear();
            server = DbServerManagerSingleton.GetInstance().Connect();
            InitDatabases();
        }
    }
}
