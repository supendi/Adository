using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class SelectByPrimaryKeyMethod : SelectSingleMethod
    {
        private DataTable datatable;

        public SelectByPrimaryKeyMethod(DataTable datatable) : base(datatable, "ByPrimaryKey")
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
            foreach (DataColumn clm in this.datatable.PrimaryKey)
            {
                var type = ProperVBTypeName.Get(clm);
                string name = clm.ColumnName.ToLower();

                this.MethodArgs.Add(new VBArgument(type, name));
            }
        }

        private void ConstructBody()
        {
            VBBlock usingBlock = new VBBlock(VBBlockStatement.Using, "Using sqlCommand As New SqlCommand()");
            string sqlString = $"{Quotes}{SqlSelectBuilder.SelectByPrimaryKey(datatable)}{Quotes}";
            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");

            foreach (DataColumn clm in datatable.PrimaryKey)
            {
                string parameterName = $"{Quotes}@{clm.ColumnName}{Quotes}";
                string parameterValue = clm.ColumnName.ToLower();

                usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue})");
            }
            usingBlock.Statements.Add($"Dim list As List(Of {datatable.TableName}) = ToList(sqlCommand)");

            var ifBlock = new VBBlock(VBBlockStatement.If, "If list.Count > 0 Then");
            ifBlock.Statements.Add("Return list(0)");

            usingBlock.Statements.Add(ifBlock.ToString());
            usingBlock.Statements.Add($"Return Nothing");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
