using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class CountMethod : CSMethod
    {
        private DataTable datatable;

        public CountMethod(DataTable datatable) : base($"int", "Count", CSMemberModifier.PublicVirtual)
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
            usingBlock.Statements.Add($"sqlCommand.CommandText = {Quotes}SELECT COUNT(*) FROM [{datatable.TableName}];{Quotes};");
            usingBlock.Statements.Add($"return Convert.ToInt32(table.DbAccess.ExecuteScalar(sqlCommand));");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
