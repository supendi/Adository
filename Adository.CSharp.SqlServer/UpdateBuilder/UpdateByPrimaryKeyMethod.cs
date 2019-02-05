using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.UpdateBuilder
{
    public class UpdateByPrimaryKeyMethod : UpdateMethod
    {
        private DataTable datatable;

        public UpdateByPrimaryKeyMethod(DataTable datatable) : base("ByPrimaryKey")
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
            var type = datatable.TableName;
            string name = ProperVarName.Get(datatable.TableName.ToLower());

            this.MethodArgs.Add(new CSArgument(type, name));
        }

        private void ConstructBody()
        {
            CSBlock usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string sqlString = $"{Quotes}{SqlUpdateBuilder.UpdateByPrimaryKey(datatable)}{Quotes}";
            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString};");
            usingBlock.Statements.Add($"SetSqlCommandParameter(sqlCommand, {ProperVarName.Get(datatable.TableName.ToLower())});");
            usingBlock.Statements.Add($"table.DbAccess.Commands.Add(sqlCommand);");

            this.Statements.Add(usingBlock.ToString());
        }
    }
}
