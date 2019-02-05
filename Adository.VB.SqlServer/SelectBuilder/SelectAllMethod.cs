
using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class SelectAllMethod : SelectMethod
    {
        private DataTable datatable;

        public SelectAllMethod(DataTable datatable) : base(datatable, "All")
        {
            this.datatable = datatable;
            Build();
        }

        private void Build()
        {
            ConstructBody();
        }

        private void ConstructBody()
        {
            VBBlock usingBlock = new VBBlock(VBBlockStatement.Using, "Using sqlCommand As New SqlCommand()");
            string sqlString = $"{Quotes}{SqlSelectBuilder.CreateSelectAll(datatable)}{Quotes}";
            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");
            usingBlock.Statements.Add($"Return ToList(sqlCommand)");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
