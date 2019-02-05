using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class SelectByKeywordKeyMethod : SelectMethod
    {
        private DataTable datatable;

        public SelectByKeywordKeyMethod(DataTable datatable) : base(datatable, "ByKeyword")
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
            this.MethodArgs.Add(new CSArgument("int", "start"));
            this.MethodArgs.Add(new CSArgument("int", "end"));
            this.MethodArgs.Add(new CSArgument("string", "orderByColumnName"));
            this.MethodArgs.Add(new CSArgument("string", $"orderDirection = {Quotes}ASC{Quotes}"));
        }

        private void ConstructBody()
        {
            var usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string sqlString = $"${Quotes}{SqlSelectBuilder.CreateSelectByKeyword(datatable)}{Quotes};";

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString} ");

            usingBlock.Statements.Add($"{NewLine}sqlCommand.Parameters.AddWithValue({$"{Quotes}@Keyword{Quotes}"}, keyword);");
            usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({Quotes}@Start{Quotes}, start);");
            usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({Quotes}@End{Quotes}, end);");
            usingBlock.Statements.Add($"return ToList(sqlCommand);");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
