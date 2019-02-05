using Adository.Data.SqlServer;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Adository.Common
{
    public class SysTableModel
    {
        public string Name { get; set; }
        public string ObjectId { get; set; }
        public string Type { get; set; }
    }

    public class SysTableQuery
    {
        private SqlServerDbAccess dbAccess;

        public SysTableQuery(SqlServerDbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public List<SysTableModel> GetAll(string dbName)
        {
            //var sql = (dbName.ToLower() == "master") ? $"USE {dbName}; select name, object_id, type from sys.tables;" : $"USE {dbName}; SELECT * FROM sys.objects WHERE TYPE='U' or TYPE='V';";
            var sql = $"USE {dbName}; SELECT name, object_id, type FROM sys.objects WHERE TYPE='U' or TYPE='V' order by name;";
            using (SqlCommand command = new SqlCommand(sql))
            {
                var dt = dbAccess.GetDataTable(command);

                List<SysTableModel> listSysTable = new List<SysTableModel>();
                SysTableModel sysTable;

                foreach (DataRow dataRow in dt.Rows)
                {
                    sysTable = new SysTableModel();
                 
                    sysTable.Name = dataRow[0].ToString();
                    sysTable.ObjectId = dataRow[1].ToString();
                    sysTable.Type = dataRow[2].ToString();

                    listSysTable.Add(sysTable);
                }
                return listSysTable;
            }
        }
    }
}
