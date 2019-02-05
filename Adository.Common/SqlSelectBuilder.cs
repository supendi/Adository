using System.Data;

namespace Adository.Common
{
    public class SqlSelectBuilder
    {
        public static string CreateSelectAll(DataTable dataTable)
        {
            var columns = SqlSelectHelper.ArrangeColumnsWithComma(dataTable);
            var tableName = dataTable.TableName;

            return $"SELECT {columns.Trim()} FROM [{tableName.Trim()}];";
        }

        public static string CreateSelectAllWhere(DataTable dataTable, string where)
        {
            return $"{CreateSelectAll(dataTable)} WHERE {where};";
            //var columns = ColArranger.ArrangeAll(dataTable);
            //var tableName = dataTable.TableName;

            //return $"SELECT {columns.Trim()} FROM [{tableName.Trim()}] WHERE {where};";
        }

        public static string CreateSelectByKeyword(DataTable dataTable)
        {
            var columns = SqlSelectHelper.ArrangeColumnsWithComma(dataTable);
            var tableName = dataTable.TableName;
            var keys = SqlPrimaryKeyStringHelper.ArrangeColumnsWithComma(dataTable);
            var whereLikeKeyword = SqlSelectHelper.ArrangeColumeLikeKeyword(dataTable);

            var subQuery = $"(SELECT ROW_NUMBER() OVER (ORDER BY {{orderByColumnName}} {{orderDirection}}) AS RowSequence, {columns.Trim()} FROM [{tableName.Trim()}] WHERE ({whereLikeKeyword})) AS [{tableName.Trim()}]";

            return $"SELECT {columns.Trim()} FROM {subQuery} WHERE RowSequence BETWEEN @Start AND @End;";
        }

        public static string CreateSelectCountByKeyword(DataTable dataTable)
        {
            var tableName = dataTable.TableName;
            var whereLikeKeyword = SqlSelectHelper.ArrangeColumeLikeKeyword(dataTable);

            return $"SELECT COUNT({dataTable.Columns[0]}) FROM [{tableName}] WHERE ({whereLikeKeyword});";
        }

        public static string SelectByPrimaryKey(DataTable dataTable)
        {
            var columns = SqlSelectHelper.ArrangeColumnsWithComma(dataTable);
            var tableName = dataTable.TableName;

            return $"SELECT TOP 1 {columns.Trim()} FROM [{tableName.Trim()}] WHERE {SqlPrimaryKeyStringHelper.ArrangeColumnsWithParam(dataTable)};";
        }
    }

    internal class SqlSelectHelper : SqlStringHelper
    {
        public static string ArrangeColumnsWith(DataTable datatable, string splitter)
        {
            string arrangedColumns = string.Empty;
            foreach (DataColumn clm in datatable.Columns)
            {
                arrangedColumns += $"[{clm.ColumnName}]{splitter} ";
            }
            int lengthToRemove = splitter.Length + 1; //1 is the space character
            arrangedColumns = RemoveLastCharacters(arrangedColumns, lengthToRemove);
            return arrangedColumns;
        }

        /// <summary>
        /// Arrange DT Columns: Id, Name, BirthDate
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static string ArrangeColumnsWithComma(DataTable datatable)
        {
            return ArrangeColumnsWith(datatable, ",");
        }

        public static string ArrangeColumeLikeKeyword(DataTable dataTable)
        {
            string arrangedColumns = string.Empty;
            foreach (DataColumn clm in dataTable.Columns)
            {
                //where clause, only column with string(varchar) datatype which get LIKE keyword
                if (clm.DataType.Name == "String")
                {
                    string clmName = clm.ColumnName.Contains(" ") ? $"[{clm.ColumnName}]" : clm.ColumnName;
                    arrangedColumns += clmName + " LIKE '%' + @Keyword + '%'" + " OR ";
                }
            }
            arrangedColumns = RemoveLastCharacters(arrangedColumns, 4);
            return arrangedColumns;
        }
    }
}
