using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.UpdateBuilder
{
    public class UpdateColumnByPrimaryKeyMethod : UpdateMethod
    {
        private DataColumn datacolumn;
        private DataTable datatable;

        public UpdateColumnByPrimaryKeyMethod(DataTable datatable, DataColumn datacolumn) : base($"{datacolumn.ColumnName.Replace(" ", "")}ByPrimaryKey")
        {
            this.datatable = datatable;
            this.datacolumn = datacolumn;
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            var type = ProperCSTypeName.Get(datacolumn);
            string name = ProperVarName.Get(datacolumn.ColumnName.ToLower());
            this.MethodArgs.Add(new CSArgument(type, name));

            foreach (DataColumn clm in this.datatable.PrimaryKey)
            {
                var keyType = ProperCSTypeName.Get(clm);
                string keyName = ProperVarName.Get(clm.ColumnName.ToLower());

                this.MethodArgs.Add(new CSArgument(keyType, keyName));
            }
        }

        private void ConstructBody()
        {
            CSBlock usingBlock = new CSBlock("using (SqlCommand sqlCommand = new SqlCommand())");
            string sqlString = $"{Quotes}{SqlUpdateBuilder.UpdateColumnByPrimaryKey(datatable, datacolumn)}{Quotes}";

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString};");

            #region Updated Column
            string parameterName = $"{Quotes}@{datacolumn.ColumnName.Replace(" ","")}{Quotes}";
            string parameterValue = ProperVarName.Get(datacolumn.ColumnName.ToLower().Replace(" ",""));
            if (datacolumn.AllowDBNull)
            {
                parameterValue += " ?? (object)DBNull.Value";
            }
            usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue});");
            #endregion

            #region Primary Key Column
            string keyParameterName = string.Empty;
            string keyParameterValue = string.Empty;
            foreach (DataColumn clm in this.datatable.PrimaryKey)
            {
                keyParameterName = $"{Quotes}@{clm.ColumnName.Replace(" ", "")}{Quotes}";
                keyParameterValue = ProperVarName.Get(clm.ColumnName.ToLower());
                if (clm.AllowDBNull)
                {
                    keyParameterValue += " ?? (object)DBNull.Value";
                }
                 
                usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({keyParameterName}, {keyParameterValue});");
            }
            #endregion

            usingBlock.Statements.Add($"table.DbAccess.Commands.Add(sqlCommand);");

            this.Statements.Add(usingBlock.ToString());
        }
    }
}
