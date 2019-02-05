using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
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
            this.MethodArgs.Add(new VBArgument("String", "keyword"));
            this.MethodArgs.Add(new VBArgument("Integer", "start"));
            this.MethodArgs.Add(new VBArgument("Integer", "_end"));
            this.MethodArgs.Add(new VBArgument("String", "orderByColumnName"));
            this.MethodArgs.Add(new VBArgument($"String", $"orderDirection", $"{Quotes}ASC{Quotes}"));
        }

        private void ConstructBody()
        {
            VBBlock usingBlock = new VBBlock(VBBlockStatement.Using, "Using sqlCommand As New SqlCommand()");
            string sqlString = $"${Quotes}{SqlSelectBuilder.CreateSelectByKeyword(datatable)}{Quotes}";

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString} ");

            usingBlock.Statements.Add($"{NewLine}sqlCommand.Parameters.AddWithValue({$"{Quotes}@Keyword{Quotes}"}, keyword)");
            usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({Quotes}@Start{Quotes}, start)");
            usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({Quotes}@End{Quotes}, _end)");
            usingBlock.Statements.Add($"Return ToList(sqlCommand)");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
