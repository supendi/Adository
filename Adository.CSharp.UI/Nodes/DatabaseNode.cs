using System.Data;
using System.Windows.Forms;

namespace Adository.CSharp.UI.Nodes
{
    public class DatabaseNode : TreeNode
    {
        public DataSet DataSet { get; set; }

        public ServerNode ServerNode
        {
            get
            {
                return this.Parent as ServerNode;
            }
        }

        public string ConnectionString
        {
            get
            {
                return ServerNode.ConnectionString;
            }
        }

        public DatabaseNode(DataSet dataSet)
        {
            DataSet = dataSet;
            this.Text = dataSet.DataSetName;
            this.Name = dataSet.DataSetName;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
            InitTables();
        }

        private void InitTables()
        {
            if (DataSet == null) return;
            foreach (DataTable table in DataSet.Tables)
            {
                var node = new TableNode(table);
                node.Name = table.TableName;
                node.Text = table.TableName;

                this.Nodes.Add(node);
            }
        }

        public void Refresh()
        {
            this.Nodes.Clear();
            DataSet = DbServerManagerSingleton.GetInstance().GetDataSet(Name);
            InitTables();
        }
    }
}
