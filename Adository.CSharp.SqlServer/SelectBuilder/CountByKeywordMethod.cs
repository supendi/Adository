using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class CountByKeywordMethod : CSMethod
    {
        private DataTable datatable;

        public CountByKeywordMethod(DataTable datatable) : base($"int", "CountByKeyword", CSMemberModifier.PublicVirtual)
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
            this.MethodArgs.Add(new CSArgument("string", "keyword"));
        }

        private void ConstructBody()
        {
            CSBlock usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string sqlString = $"{Quotes}{SqlSelectBuilder.CreateSelectCountByKeyword(datatable)}{Quotes};";

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");
            usingBlock.Statements.Add($"{NewLine}sqlCommand.Parameters.AddWithValue({$"{Quotes}@Keyword{Quotes}"}, keyword);");
            usingBlock.Statements.Add($"return Convert.ToInt32(table.DbAccess.ExecuteScalar(sqlCommand));");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
