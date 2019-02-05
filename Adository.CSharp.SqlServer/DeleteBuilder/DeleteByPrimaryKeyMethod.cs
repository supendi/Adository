﻿using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.DeleteBuilder
{
    public class DeleteByPrimaryKeyMethod : DeleteMethod
    {
        private DataTable datatable;

        public DeleteByPrimaryKeyMethod(DataTable datatable) : base("ByPrimaryKey")
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
            string sqlString = $"{Quotes}{SqlDeleteBuilder.DeleteByPrimaryKey(datatable)}{Quotes};";
            string parameterName = string.Empty;
            string parameterValue = string.Empty;

            usingBlock.Statements.Add($"sqlCommand.CommandText = {sqlString}");

            foreach (DataColumn clm in this.datatable.PrimaryKey)
            {
                parameterName = $"{Quotes}@{clm.ColumnName}{Quotes}";
                parameterValue = GetParameterValue(clm);

                usingBlock.Statements.Add($"sqlCommand.Parameters.AddWithValue({parameterName}, {parameterValue});");
            }

            usingBlock.Statements.Add($"table.DbAccess.Commands.Add(sqlCommand);");

            this.Statements.Add(usingBlock.ToString());
        }

        private static string GetParameterValue(DataColumn clm)
        {
            string parameterValue = clm.ColumnName.ToLower();
            if (clm.AllowDBNull)
            {
                parameterValue += " ?? (object)DBNull.Value";
            }

            return parameterValue;
        }
    }
}
