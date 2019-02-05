using System.Data;

namespace Adository.Common
{
    public class SqlDeleteBuilder
    {
        public static string DeleteByPrimaryKey(DataTable dataTable)
        {
            var tableName = dataTable.TableName;

            return $"DELETE [{tableName.Trim()}] WHERE {SqlPrimaryKeyStringHelper.ArrangeColumnsWithParam(dataTable)};";
        }

        public static string DeleteByColumn(DataTable dataTable, DataColumn dataColumn)
        {
            var tableName = dataTable.TableName;
            string columnName = dataColumn.ColumnName.Contains(" ") ? $"[{dataColumn.ColumnName}]" : dataColumn.ColumnName;
            string parameterName = dataColumn.ColumnName.Replace(" ", "");

            return $"DELETE [{tableName.Trim()}] WHERE {columnName}=@{parameterName};";
        }
    }
}
