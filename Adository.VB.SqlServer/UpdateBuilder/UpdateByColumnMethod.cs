using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.UpdateBuilder
{
    public class UpdateByColumnMethod : UpdateMethod
    {
        private DataColumn datacolumn;
        private DataTable datatable;

        public UpdateByColumnMethod(DataTable datatable, DataColumn datacolumn) : base($"By{datacolumn.ColumnName.Replace(" ", "")}")
        {
            this.datatable = datatable;
            this.datacolumn = datacolumn;
            Build();
        }

        private void Build()
        {
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
            string sqlString = $"{Quotes}{SqlUpdateBuilder.UpdateByColumn(datatable, datacolumn)}{Quotes}";
            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");
            usingBlock.Statements.Add($"SetSqlCommandParameter(sqlCommand, {ProperVarName.Get(datatable.TableName.ToLower())})");
            usingBlock.Statements.Add($"table.DbAccess.Commands.Add(sqlCommand)");

            this.Statements.Add(usingBlock.ToString());
        }
    }
}
