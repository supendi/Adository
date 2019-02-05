using System.Data;

namespace Adository.Common
{
    public class SqlInsertBuilder
    {
        public static string CreateInsertSql(DataTable dataTable)
        {
            var insertToColumns = SqlInsertHelper.ArrangeColumns(dataTable, "").Trim();
            string insertWith = SqlInsertHelper.ArrangeColumns(dataTable, "@", false);
            var tableName = dataTable.TableName;

            return $"INSERT INTO [{tableName.Trim()}] ({insertToColumns}) VALUES ({insertWith});";
        }
    }

    internal class SqlInsertHelper : SqlStringHelper
    {
        public static string ArrangeColumns(DataTable dataTable, string prefix, bool addKurungKotak = true)
        {
            string arrangedColumns = string.Empty;
            string columnName = string.Empty;
            foreach (DataColumn clm in dataTable.Columns)
            {
                if (!clm.AutoIncrement)
                {
                    if (addKurungKotak)
                    {
                        columnName = clm.ColumnName.Contains(" ") ? $"[{clm.ColumnName}]" : clm.ColumnName;
                    }
                    else
                    {
                        columnName = clm.ColumnName.Replace(" ", "");
                    }
                    arrangedColumns += $"{prefix}{columnName}, ";
                }
            }
            arrangedColumns = RemoveLastCharacters(arrangedColumns, 2);

            return arrangedColumns;
        }
    }
}
