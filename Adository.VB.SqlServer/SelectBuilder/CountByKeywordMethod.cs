using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class CountByKeywordMethod : VBMethod
    {
        private DataTable datatable;

        public CountByKeywordMethod(DataTable datatable) : base($"Integer", "CountByKeyword", MethodType.Function, VBMemberModifier.PublicOverridable)
        {
            this.datatable = datatable;
            Build();
        }

        private void Build()
        {
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            this.MethodArgs.Add(new VBArgument("String", "keyword"));
        }

        private void ConstructBody()
        {
            VBBlock usingBlock = new VBBlock(VBBlockStatement.Using, "Using sqlCommand As New SqlCommand()");
            string sqlString = $"{Quotes}{SqlSelectBuilder.CreateSelectCountByKeyword(datatable)}{Quotes}";

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");
            usingBlock.Statements.Add($"{NewLine}sqlCommand.Parameters.AddWithValue({$"{Quotes}@Keyword{Quotes}"}, keyword)");
            usingBlock.Statements.Add($"Return Convert.ToInt32(table.DbAccess.ExecuteScalar(sqlCommand))");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
