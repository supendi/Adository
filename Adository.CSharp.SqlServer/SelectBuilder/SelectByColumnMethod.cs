using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class SelectByColumnMethod : SelectMethod
    {
        private DataColumn datacolumn;
        private DataTable datatable;

        public SelectByColumnMethod(DataTable datatable, DataColumn datacolumn) : base(datatable, $"By{datacolumn.ColumnName.Replace(" ","")}")
        {
            this.datatable = datatable;
            this.datacolumn = datacolumn;
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            var type = ProperCSTypeName.Get(datacolumn);
            string name = ProperVarName.Get(datacolumn.ColumnName.ToLower());

            this.MethodArgs.Add(new CSArgument(type, name));
        }

        private void ConstructBody()
        {
            CSBlock usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string parameterName = $"{Quotes}@{datacolumn.ColumnName.Replace(" ","")}{Quotes}";
            string parameterValue = ProperVarName.Get(datacolumn.ColumnName.ToLower());
            string columnName = datacolumn.ColumnName.Contains(" ") ? $"[{datacolumn.ColumnName}]" : datacolumn.ColumnName;
            string sqlString = $"{Quotes}{SqlSelectBuilder.CreateSelectAllWhere(datatable, $"{columnName} = @{datacolumn.ColumnName.Replace(" ", "")}")}{Quotes};";

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");
            usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue});");
            usingBlock.Statements.Add($"return ToList(sqlCommand);");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
