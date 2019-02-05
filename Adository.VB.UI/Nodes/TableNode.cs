using System.Data;
using System.Windows.Forms;

namespace Adository.VB.UI.Nodes
{
    public class TableNode : TreeNode
    {
        public DataTable DataTable { get; set; }

        public ServerNode ServerNode
        {
            get
            {
                return this.Parent.Parent as ServerNode;
            }
        }

        public DatabaseNode DatabaseNode
        {
            get
            {
                return this.Parent as DatabaseNode;
            }
        }

        public string ConnectionString
        {
            get
            {
                return ServerNode.ConnectionString;
            }
        }

        public TableNode(DataTable dataTable)
        {

            DataTable = dataTable;
            this.Text = dataTable.TableName;
            this.Name = dataTable.TableName;
            this.ImageIndex = 2;
            this.SelectedImageIndex = 2;

            InitColumns();
        }

        private void InitColumns()
        {
            if (DataTable == null) return;

            foreach (DataColumn column in DataTable.Columns)
            {
                var node = new ColumnNode(column);
                node.Name = column.ColumnName;
                node.Text = column.ColumnName;

                this.Nodes.Add(node);
            }
        }

        public void Refresh()
        {
            this.Nodes.Clear();
            DataTable = DbServerManagerSingleton.GetInstance().GetDataTable(DatabaseNode.Name, Name);
            InitColumns();
        }
    }
}
