namespace Adository.Data.SqlServer
{
    public class SqlServerTable //: IDisposable
    {
        public SqlServerDbAccess DbAccess { get; set; }

        public SqlServerTable(SqlServerDbAccess dbAccess)
        {
            DbAccess = dbAccess;
        }

        //public void Dispose()
        //{
        //    DbAccess.Dispose();
        //}
    }
}
