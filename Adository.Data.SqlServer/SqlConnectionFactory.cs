using System.Data.SqlClient;

namespace Adository.Data.SqlServer
{
    public class SqlConnectionFactory
    {
        public static void TestConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static SqlConnection GetConnection(string connectionString, bool testConnection = true)
        {
            var connection = new SqlConnection(connectionString);
            if(testConnection)
                TestConnection(connection);
            return connection;
        }

        public static SqlConnection GetConnection(ConnectionStringBuilder connectionStringBuilder)
        {
            var connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            TestConnection(connection);
            return connection;
        }
    }
}
