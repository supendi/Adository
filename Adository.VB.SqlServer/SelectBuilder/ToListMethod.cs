using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class ToListMethod : VBMethod
    {
        private DataTable datatable;

        public ToListMethod(DataTable datatable) : base($"List(Of {datatable.TableName})", "ToList", MethodType.Function, VBMemberModifier.Private)
        {
            this.datatable = datatable;
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            this.MethodArgs.Add(new VBArgument("SqlCommand", "sqlCommand"));
        }

        private void ConstructBody()
        {
            string className = datatable.TableName;
            string instanceName = ProperVarName.Get(datatable.TableName.ToLower());

            this.Statements.Add("Dim dt As DataTable = table.DbAccess.GetDataTable(sqlCommand)");
            this.Statements.Add($"Dim list As List(Of {className}) = New List(Of {className})()");

            VBBlock forEachBlock = new VBBlock(VBBlockStatement.ForEach, "For Each dataRow As DataRow In dt.Rows");
            forEachBlock.Statements.Add($"Dim {instanceName} As {className} = New {className}()");

            foreach (DataColumn clm in datatable.Columns)
            {
                string clmName = ProperVarName.Get(clm.ColumnName, false);
                string propName = ProperVarName.Get(clm.ColumnName, true);
                if (clm.AllowDBNull)
                {
                    forEachBlock.Statements.Add($"{instanceName}.{propName} = CType(If(dataRow({Quotes}{clmName}{Quotes}) Is DBNull.Value, Nothing, dataRow({Quotes}{clmName}{Quotes})), {ProperVBTypeName.Get(clm)})");
                }
                else
                {
                    forEachBlock.Statements.Add($"{instanceName}.{propName} = CType(dataRow({Quotes}{clmName}{Quotes}), {ProperVBTypeName.Get(clm)})");
                }
            }
            forEachBlock.Statements.Add($"list.Add({instanceName})");
            this.Statements.Add(forEachBlock.ToString());
            this.Statements.Add("Return list");
        }
    }
}
