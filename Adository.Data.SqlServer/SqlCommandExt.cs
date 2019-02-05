using System;
using System.Data.SqlClient;

namespace Adository.Data.SqlServer
{
    public static class SqlCommandExt
    {
        public static SqlCommand Where(this SqlCommand sqlCommand, string sql, params SqlParameter[] sqlParameters)
        {
            sqlCommand.CommandText = sqlCommand.CommandText.Replace(";", "");
            sqlCommand.CommandText += $" WHERE {sql}";
            foreach (var param in sqlParameters)
            {
                sqlCommand.Parameters.Add(param);
            }
            return sqlCommand;
        }

        public static SqlCommand And(this SqlCommand sqlCommand, string sql)
        {
            sqlCommand.CommandText = sqlCommand.CommandText.Replace(";", "");
            sqlCommand.CommandText += $" AND {sql}";
            return sqlCommand;
        }

        public static SqlCommand Or(this SqlCommand sqlCommand, string sql)
        {
            sqlCommand.CommandText = sqlCommand.CommandText.Replace(";", "");
            sqlCommand.CommandText += $" OR {sql}";
            return sqlCommand;
        }

        public static SqlCommand OrderBy(this SqlCommand sqlCommand, string columnName, string orderDirection = "ASC")
        {
            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("Order by column name cannot be empty.");

            columnName = GetFirstWord(columnName);
            orderDirection = GetFirstWord(orderDirection);

            sqlCommand.CommandText = sqlCommand.CommandText.Replace(";", "");
            sqlCommand.CommandText += $" ORDER BY {columnName} {orderDirection}";
            sqlCommand.CommandText = sqlCommand.CommandText.Replace("--", "");
            return sqlCommand;
        }

        /// <summary>
        /// Securing sql injection. Example: If user define column name = 'Username', it's safe. if columnname is 'Username; Delete from User --', we are dead.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private static string GetFirstWord(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
                return string.Empty;
            var arr = columnName.Split(' ');
            return arr[0].Replace(";", "");
        }
    }
}
