using System.Data;

namespace Adository.Common
{
    internal class SqlStringHelper
    {
        /// <summary>
        /// Remove last characters
        /// </summary>
        /// <param name="arrangedColumns"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected static string RemoveLastCharacters(string arrangedColumns, int length)
        {
            if (arrangedColumns.Length > 0)
            {
                arrangedColumns = arrangedColumns.Substring(0, arrangedColumns.Length - length);
            }

            return arrangedColumns;
        }
    }

    internal class SqlPrimaryKeyStringHelper: SqlStringHelper
    {
        public static string ArrangeColumnsWithParam(DataTable dataTable)
        {
            string arrangedColumns = string.Empty;
            foreach (DataColumn clm in dataTable.PrimaryKey)
            {
                string primaryKey = clm.ColumnName;
                string parameterName = clm.ColumnName;
                arrangedColumns += primaryKey + "=@" + parameterName + " AND ";
            }
            arrangedColumns = RemoveLastCharacters(arrangedColumns, 5);
            return arrangedColumns;
        }

        public static string ArrangeColumnsWithComma(DataTable dataTable)
        {
            string arrangedColumns = string.Empty;
            foreach (DataColumn clm in dataTable.PrimaryKey)
            {
                string primaryKey = clm.ColumnName;
                string parameterName = clm.ColumnName;
                arrangedColumns += primaryKey + ", ";
            }
            arrangedColumns = RemoveLastCharacters(arrangedColumns, 2);
            return arrangedColumns;
        }
    }
}
