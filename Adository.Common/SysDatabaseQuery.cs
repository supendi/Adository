using Adository.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Adository.Common
{
    public class SysDatabaseModel
    {
        public string Name { get; set; }
        public int DatabaseId { get; set; }
    }

    public class SysDatabaseQuery
    {
        private SqlServerDbAccess dbAccess;

        public SysDatabaseQuery(SqlServerDbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public List<SysDatabaseModel> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT name, database_id FROM sys.databases;"))
            {
                var dt = dbAccess.GetDataTable(command);

                List<SysDatabaseModel> listSysDatabase = new List<SysDatabaseModel>();
                SysDatabaseModel sysDatabase;

                foreach (DataRow dataRow in dt.Rows)
                {
                    sysDatabase = new SysDatabaseModel();

                    sysDatabase.Name = dataRow[0].ToString();
                    sysDatabase.DatabaseId = Convert.ToInt32(dataRow[1]);

                    listSysDatabase.Add(sysDatabase);
                }
                return listSysDatabase;
            }
        }
    }
}
