
using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
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
            CSBlock usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string sqlString = $"{Quotes}{SqlSelectBuilder.CreateSelectAll(datatable)}{Quotes};";
            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");
            usingBlock.Statements.Add($"return ToList(sqlCommand);");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
