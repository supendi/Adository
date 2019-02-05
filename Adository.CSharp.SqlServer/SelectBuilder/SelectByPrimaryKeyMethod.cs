using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
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
                var type = ProperCSTypeName.Get(clm);
                string name = clm.ColumnName.ToLower();

                this.MethodArgs.Add(new CSArgument(type, name));
            }
        }

        private void ConstructBody()
        {
            CSBlock usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string sqlString = $"{Quotes}{SqlSelectBuilder.SelectByPrimaryKey(datatable)}{Quotes};";
            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");

            foreach (DataColumn clm in datatable.PrimaryKey)
            {
                string parameterName = $"{Quotes}@{clm.ColumnName}{Quotes}";
                string parameterValue = clm.ColumnName.ToLower(); 

                usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue});");
            }
            usingBlock.Statements.Add($"var list = ToList(sqlCommand);");

            var ifBlock = new CSBlock("if (list.Count > 0)");
            ifBlock.Statements.Add("return list[0];");

            usingBlock.Statements.Add(ifBlock.ToString());
            usingBlock.Statements.Add($"return null;");
            this.Statements.Add(usingBlock.ToString());
        }
    }
}
