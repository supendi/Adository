using Adository.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Adository.Common
{
    public class DbServerModel
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public List<DataSet> DataSets { get; set; }

        public DbServerModel(string name)
        {
            this.Name = name;
            DataSets = new List<DataSet>();
        }
        private bool changeTest;
    }

    public class DbServerManager : IDisposable
    {
        public SqlServerDbAccess DbAccess { get; set; }

        private string[] skippedDbs
        {
            get
            {
                return new string[] 
                {

                     "ReportServerTempDB",
                     "ReportServer",
                     "msdb",
                     "model",
                     "tempdb"
                };
            }
        }

        public DbServerManager(SqlServerDbAccess dbAccess)
        {
            DbAccess = dbAccess;
        }

        private bool SkipDb(string dbName)
        {
            return false;
            return skippedDbs.Contains(dbName); 
        }

        private List<SysDatabaseModel> GetDatabases()
        {
            var query = new SysDatabaseQuery(DbAccess);
            return query.GetAll();
        }

        public DataSet GetDataSet(string dbName)
        {
            if (DbAccess.Connection.State != ConnectionState.Open)
                DbAccess.Connection.Open();
            DbAccess.Connection.ChangeDatabase(dbName);
            DataSet dataSet = new DataSet(dbName);
            var query = new SysTableQuery(DbAccess);
            var sysTables = query.GetAll(dbName);
            foreach (SysTableModel table in sysTables)
            {
                if (table.Name.Contains("#"))
                    continue;
                var dt = DbAccess.GetDataTable(new SqlCommand($"SELECT * FROM [{table.Name}] WHERE 0=1"));
                dt.TableName = table.Name;

                //naro type  'View' atau 'Table' yaitu : 'V' dan 'U'
                dt.Prefix = table.Type.Trim();

                dataSet.Tables.Add(dt);
            }
            return dataSet;
        }

        public DataTable GetDataTable(string dbName, string tableName)
        {
            if (DbAccess.Connection.State != ConnectionState.Open)
                DbAccess.Connection.Open();
            DbAccess.Connection.ChangeDatabase(dbName);
            return DbAccess.GetDataTable(new SqlCommand($"SELECT * FROM [{tableName.Replace("[", "").Replace("]", "")}]"));
        }

        public DbServerModel Connect()
        {
            DbServerModel server = new DbServerModel(DbAccess.Connection.DataSource);
            server.ConnectionString = DbAccess.Connection.ConnectionString;
            var databases = GetDatabases();

            foreach (var db in databases)
            {
                if (SkipDb(db.Name))
                    continue;
                server.DataSets.Add(GetDataSet(db.Name));
            }
            return server;
        }

        public void Dispose()
        {
            DbAccess.Dispose();
        }
    }
}
