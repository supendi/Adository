using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.DeleteBuilder
{
    /// <summary>
    /// Generates delete methods based on table column name. Example: DeleteById(int id), DeleteByName(string name)
    /// </summary>
    public class DeleteByColumnMethod : DeleteMethod
    {
        private DataColumn datacolumn;
        private DataTable datatable;

        public DeleteByColumnMethod(DataTable datatable, DataColumn datacolumn) : base($"By{datacolumn.ColumnName.Replace(" ", "")}")
        {
            this.datatable = datatable;
            this.datacolumn = datacolumn;
            Build();
        }

        private void Build()
        {
            CreateParameter();
            ConstructBody();
        }

        private void CreateParameter()
        {
            var type = ProperCSTypeName.Get(datacolumn);
            string name = ProperVarName.Get(datacolumn.ColumnName.ToLower());

            this.MethodArgs.Add(new CSArgument(type, name));
        }

        private void ConstructBody()
        {
            CSBlock usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string sqlString = $"{Quotes}{SqlDeleteBuilder.DeleteByColumn(datatable, datacolumn)}{Quotes};";
            string parameterName = $"{Quotes}@{datacolumn.ColumnName.Replace(" ","")}{Quotes}";
            string parameterValue = ProperVarName.Get(datacolumn.ColumnName.ToLower());

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");
            if (datacolumn.AllowDBNull)
            {
                parameterValue += " ?? (object)DBNull.Value";
            }
             
            usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue});"); 
            usingBlock.Statements.Add($"table.DbAccess.Commands.Add(sqlCommand);");

            this.Statements.Add(usingBlock.ToString());
        }
    }
}
