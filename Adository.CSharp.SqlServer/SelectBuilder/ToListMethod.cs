using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class ToListMethod : CSMethod
    {
        private DataTable datatable;

        public ToListMethod(DataTable datatable) : base($"List<{datatable.TableName}>", "ToList", CSMemberModifier.Private)
        {
            this.datatable = datatable;
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            this.MethodArgs.Add(new CSArgument("SqlCommand", "sqlCommand"));
        }

        private void ConstructBody()
        {
            string className = datatable.TableName;
            string instanceName = ProperVarName.Get(datatable.TableName.ToLower());

            this.Statements.Add("var dt = table.DbAccess.GetDataTable(sqlCommand);");
            this.Statements.Add($"List<{className}> list = new List<{className}>();");

            CSBlock forEachBlock = new CSBlock("foreach (DataRow dataRow in dt.Rows)");
            forEachBlock.Statements.Add($"{className} {instanceName} = new {className}();");

            foreach (DataColumn clm in datatable.Columns)
            {
                string clmName = ProperVarName.Get(clm.ColumnName, false);
                string propName = ProperVarName.Get(clm.ColumnName, true);
                if (clm.AllowDBNull)
                {
                    forEachBlock.Statements.Add($"{instanceName}.{propName} = ({ProperCSTypeName.Get(clm)})(dataRow[{Quotes}{clmName}{Quotes}] == DBNull.Value ? null : dataRow[{Quotes}{clmName}{Quotes}]);");
                }
                else
                {
                    forEachBlock.Statements.Add($"{instanceName}.{propName} = ({ProperCSTypeName.Get(clm)})dataRow[{Quotes}{clmName}{Quotes}];");
                }
            }
            forEachBlock.Statements.Add($"list.Add({instanceName});");
            this.Statements.Add(forEachBlock.ToString());
            this.Statements.Add("return list;");
        }
    }
}
