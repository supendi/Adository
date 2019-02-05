using System.Data;

namespace Adository.Common
{
    public class SqlUpdateBuilder
    {
        public static string UpdateByPrimaryKey(DataTable dataTable)
        {
            var columns = SqlUpdateHelper.ArrangeColumns(dataTable);
            var tableName = dataTable.TableName;

            return $"UPDATE [{tableName.Trim()}] SET {columns.Trim()} WHERE {SqlPrimaryKeyStringHelper.ArrangeColumnsWithParam(dataTable)};";
        }

        public static string UpdateByColumn(DataTable dataTable, DataColumn dataColumn)
        {
            var columns = SqlUpdateHelper.ArrangeColumns(dataTable, dataColumn);
            var tableName = dataTable.TableName;
            var clmName = dataColumn.ColumnName.Contains(" ") ? $"[{dataColumn.ColumnName}]" : dataColumn.ColumnName;

            return $"UPDATE [{tableName.Trim()}] SET {columns.Trim()} WHERE {clmName}=@{dataColumn.ColumnName.Replace(" ", "")};";
        }

        public static string UpdateColumnByPrimaryKey(DataTable dataTable, DataColumn dataColumn)
        {
            var tableName = dataTable.TableName;

            return $"UPDATE [{tableName.Trim()}] SET {dataColumn.ColumnName.Trim()}=@{dataColumn.ColumnName.Trim()} WHERE {SqlPrimaryKeyStringHelper.ArrangeColumnsWithParam(dataTable)};";
        }
    }

    internal class SqlUpdateHelper : SqlStringHelper
    {
        public static string ArrangeColumns(DataTable dataTable)
        {
            string result = string.Empty;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                DataColumn clm = dataTable.Columns[i];
                if (clm.AutoIncrement) continue;
                foreach (DataColumn key in dataTable.PrimaryKey)
                {
                    if (clm == key)
                    {
                        i += 1;
                        if (i < dataTable.Columns.Count)
                        {
                            clm = dataTable.Columns[i];
                        }
                    }
                }
                //clm = dataTable.Columns[i];
                if (!clm.AutoIncrement)
                {
                    string field = clm.ColumnName.Contains(" ") ? $"[{clm.ColumnName}]" : clm.ColumnName;
                    string parameter = clm.ColumnName.Replace(" ", "");
                    result += field + "=@" + parameter + ", ";
                }
            }
            result = RemoveLastCharacters(result, 2);
            return result;
        }

        public static string ArrangeColumns(DataTable dataTable, DataColumn skipColumn)
        {
            string result = string.Empty;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                DataColumn clm = dataTable.Columns[i];
                if (clm.ColumnName == skipColumn.ColumnName) continue;
                if (clm.AutoIncrement) continue;
                foreach (DataColumn key in dataTable.PrimaryKey)
                {
                    if (clm == key)
                    {
                        i += 1;
                        if (i < dataTable.Columns.Count)
                        {
                            clm = dataTable.Columns[i];
                        }
                    }
                }
                //clm = dataTable.Columns[i];
                if (!clm.AutoIncrement)
                {
                    string field = clm.ColumnName.Contains(" ") ? $"[{clm.ColumnName}]" : clm.ColumnName;
                    string parameter = clm.ColumnName.Replace(" ", "");
                    result += field + "=@" + parameter + ", ";
                }
            }
            result = RemoveLastCharacters(result, 2);
            return result;
        }
    }
}
