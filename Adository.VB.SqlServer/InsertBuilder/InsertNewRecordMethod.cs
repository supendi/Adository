using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.InsertBuilder
{
    public class InsertNewRecordMethod : InsertMethod
    {
        private DataTable datatable;

        public InsertNewRecordMethod(DataTable datatable)
        {
            this.datatable = datatable;
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            var type = datatable.TableName;
            string name = ProperVarName.Get(datatable.TableName.ToLower());

            this.MethodArgs.Add(new VBArgument(type, name));
        }

        private void ConstructBody()
        {
            VBBlock usingBlock = new VBBlock(VBBlockStatement.Using, "Using sqlCommand As New SqlCommand()");
            string sqlString = $"{Quotes}{SqlInsertBuilder.CreateInsertSql(datatable)} SELECT SCOPE_IDENTITY() AS INT;{Quotes}";
            string parameterName = string.Empty;
            string propertyName = string.Empty;
            string parameterValue = string.Empty;

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");

            foreach (DataColumn clm in datatable.Columns)
            {
                if (clm.AutoIncrement)
                    continue;

                parameterName = $"{Quotes}@{clm.ColumnName.Replace(" ", "")}{Quotes}";
                propertyName = ProperVarName.Get(clm.ColumnName);
                parameterValue = $"{ProperVarName.Get(datatable.TableName.ToLower())}.{propertyName}";

                if (clm.AllowDBNull)
                {
                    parameterValue = $"If({parameterValue}, CType(DBNull.Value, Object))";
                }

                usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue})");
            }

            usingBlock.Statements.Add($"table.DbAccess.Commands.Add(sqlCommand)");

            this.Statements.Add(usingBlock.ToString());
        }
    }
}
