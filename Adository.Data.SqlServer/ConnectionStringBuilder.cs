using System;

namespace Adository.Data.SqlServer
{
    public class ConnectionStringBuilder
    {
        private string connectionStringName;

        public string ConnectionString
        {
            get
            {
                return GetConnectionString();
            }
        }
        public string MasterConnectionString
        {
            get
            {
                if (IntegratedSecurity)
                    return $"data source={DataSource};initial catalog=master;integrated security={IntegratedSecurity};";
                return $"data source={DataSource};initial catalog=master;persist security info=True;user id={UserId};password={Password};";
            }
        }
        public string DataSource { get; set; }
        public string DatabaseName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        private string GetConnectionString()
        {
            if (string.IsNullOrEmpty(connectionStringName))
                throw new ArgumentException("Connection string must not empty.");

            if (!string.IsNullOrEmpty(connectionStringName))
            {
                var connectionStringObject = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
                if (connectionStringObject == null)
                    throw new ArgumentException($"Connection string named '{connectionStringName}' not found");
                return connectionStringObject.ConnectionString;
            }

            if (IntegratedSecurity)
                return $"data source={DataSource};initial catalog={DatabaseName};integrated security={IntegratedSecurity};";
            return $"data source={DataSource};initial catalog={DatabaseName};persist security info=True;user id={UserId};password={Password};";
        }

        public ConnectionStringBuilder(string dataSource, string databaseName, string userId, string password, bool integratedSecurity = true)
        {
            DataSource = dataSource;
            DatabaseName = databaseName;
            UserId = userId;
            Password = password;
            IntegratedSecurity = integratedSecurity;
        }

        public ConnectionStringBuilder(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
        }
    }
}
