using System.Data;
using System.Windows.Forms;

namespace Adository.VB.UI.Nodes
{
    public class ColumnNode : TreeNode
    {
        public DataColumn DataColumn { get; set; }

        public ColumnNode(DataColumn dataColumn)
        {
            DataColumn = dataColumn;
            this.Text = dataColumn.ColumnName;
            this.Name = dataColumn.ColumnName;
            this.ImageIndex = 3;
            this.SelectedImageIndex = 3;
        }
    }
}