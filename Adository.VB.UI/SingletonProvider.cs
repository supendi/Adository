using Adository.Common;
using Adository.Data.SqlServer;
using Adository.VB;
using System.Data.SqlClient;

namespace Adository
{
    /// <summary>
    /// Sqlconnection instance provider
    /// </summary>
    public static class SqlConnectionSingleton
    {
        private static SqlConnection connection;

        private static string connectionString = string.Empty;

        public static SqlConnection GetInstance()
        {
            if (connection == null)
                connection = SqlConnectionFactory.GetConnection(connectionString,false);

            return connection;
        }

        public static void SetInstance(SqlConnection con)
        {
            connection = con;
        }

        public static void SetConnectionString(string conString)
        {
            connectionString = conString;
            AdositoryGeneratorSingleton.GetInstance().ServerManager.DbAccess.Connection.ConnectionString = conString;
        }
    }

    /// <summary>
    /// DbServerManager instance provider
    /// </summary>
    public static class DbServerManagerSingleton
    {
        private static DbServerManager instance;

        public static DbServerManager GetInstance()
        {
            if (instance == null)
                instance = new DbServerManager(SqlServerDbAccessSingleton.GetInstance());

            return instance;
        }

        public static void SetInstance(DbServerManager instance)
        {
            DbServerManagerSingleton.instance = instance;
        }
    }

    /// <summary>
    /// SqlServerDbAccess instance provider
    /// </summary>
    public static class SqlServerDbAccessSingleton
    {
        private static SqlServerDbAccess instance;

        public static SqlServerDbAccess GetInstance()
        {
            if (instance == null)
                instance = new SqlServerDbAccess(SqlConnectionSingleton.GetInstance());

            return instance;
        }

        public static void SetInstance(SqlServerDbAccess instance)
        {
            SqlServerDbAccessSingleton.instance = instance;
        }
    }

    /// <summary>
    /// AdositoryGenerator instance provider
    /// </summary>
    public static class AdositoryGeneratorSingleton
    {
        private static AdositoryGenerator instance;

        public static AdositoryGenerator GetInstance()
        {
            if (instance == null)
                instance = new AdositoryGenerator(DbServerManagerSingleton.GetInstance());

            return instance;
        }

        public static void SetInstance(AdositoryGenerator instance)
        {
            AdositoryGeneratorSingleton.instance = instance;
        }
    } 
}
