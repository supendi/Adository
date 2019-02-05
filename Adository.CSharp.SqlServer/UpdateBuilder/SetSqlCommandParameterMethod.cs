using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.UpdateBuilder
{
    public class SetSqlCommandParameterMethod : CSMethod
    {
        private DataTable datatable;

        public SetSqlCommandParameterMethod(DataTable datatable) : base("void", "SetSqlCommandParameter", CSMemberModifier.Private)
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
            this.MethodArgs.Add(new CSArgument("SqlCommand", "sqlCommand"));
            this.MethodArgs.Add(new CSArgument(datatable.TableName, ProperVarName.Get(datatable.TableName.ToLower())));
        }

        private void ConstructBody()
        {
            foreach (DataColumn clm in this.datatable.Columns)
            {
                string propName = ProperVarName.Get(clm.ColumnName);
                string parameterName = $"{Quotes}@{clm.ColumnName.Replace(" ","")}{Quotes}";
                string parameterValue = $"{ProperVarName.Get(datatable.TableName.ToLower())}.{propName}";
                if (clm.AllowDBNull)
                {
                    parameterValue += " ?? (object)DBNull.Value";
                }

                string sqlCommandParameter = $"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue});";
                Statements.Add(sqlCommandParameter);
            }
        }
    }
}
