using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.UpdateBuilder
{
    public class SetSqlCommandParameterMethod : VBMethod
    {
        private DataTable datatable;

        public SetSqlCommandParameterMethod(DataTable datatable) : base("", "SetSqlCommandParameter", MethodType.Sub, VBMemberModifier.Private)
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
            this.MethodArgs.Add(new VBArgument("SqlCommand", "sqlCommand"));
            this.MethodArgs.Add(new VBArgument(datatable.TableName, ProperVarName.Get(datatable.TableName.ToLower())));
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
                    parameterValue = $"If({parameterValue}, CType(DBNull.Value, Object))";
                }

                string sqlCommandParameter = $"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue})";
                Statements.Add(sqlCommandParameter);
            }
        }
    }
}
