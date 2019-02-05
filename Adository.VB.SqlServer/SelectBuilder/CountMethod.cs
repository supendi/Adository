using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class CountMethod : VBMethod
    {
        private DataTable datatable;

        public CountMethod(DataTable datatable) : base($"Integer", "Count", MethodType.Function, VBMemberModifier.PublicOverridable)
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
            usingBlock.Statements.Add($"sqlCommand.CommandText = {Quotes}SELECT COUNT(*) FROM [{datatable.TableName}];{Quotes}");
            usingBlock.Statements.Add($"Return Convert.ToInt32(table.DbAccess.ExecuteScalar(sqlCommand))");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
