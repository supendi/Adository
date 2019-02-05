using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Adository.Data.SqlServer
{
    public class SqlServerDbAccess : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public List<SqlCommand> Commands { get; set; }

        public SqlServerDbAccess(SqlConnection connection)
        {
            this.Connection = connection;
            Commands = new List<SqlCommand>();
        }

        public SqlServerDbAccess(ConnectionStringBuilder connectionStringBuilder)
        {
            this.Connection = SqlConnectionFactory.GetConnection(connectionStringBuilder);
            Commands = new List<SqlCommand>();
        }

        public DataTable GetDataTable(SqlCommand command)
        {
            using (command)
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            using (DataTable datatable = new DataTable())
            {
                command.CommandText = command.CommandText.Replace(" User ", " [User] ");
                command.Connection = Connection;
                adapter.Fill(datatable); // Fill data
                adapter.FillSchema(datatable, SchemaType.Source); // fill schema to get field information such primary key or isautoincrement.
                return datatable;
            }
        }

        public DataTable GetDataTable(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    using (DataTable datatable = new DataTable())
                    {
                        command.Connection = Connection;
                        adapter.Fill(datatable); // Fill data
                        adapter.FillSchema(datatable, SchemaType.Source); // fill schema to get field information such primary key or isautoincrement.
                        return datatable;
                    }
                }
            }
        }

        public List<T> Query<T>(string sql) where T : class, new()
        {
            return Query<T>(new SqlCommand(sql));
        }

        public List<T> Query<T>(SqlCommand command) where T : class, new()
        {
            var dt = GetDataTable(command);

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                //var instanceOfT = Activator.CreateInstance<T>();
                var instanceOfT = new T();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }

        public int ExecuteSql(SqlCommand command)
        {
            using (command)
            {
                int result = 0;
                command.Connection = Connection;
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                result += command.ExecuteNonQuery();
                return result;
            }
        }

        public int ExecuteSql(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql))
            {
                int result = 0;
                command.Connection = Connection;
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                result += command.ExecuteNonQuery();
                return result;
            }
        }

        public int ExecuteSql(string sqlQuery, string transactionName)
        {
            using (SqlTransaction transaction = Connection.BeginTransaction(transactionName))
            {
                int result = 0;
                string[] sqlList;

                sqlList = sqlQuery.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var sql in sqlList)
                {
                    using (SqlCommand command = new SqlCommand(sql))
                    {
                        command.Connection = Connection;
                        command.Transaction = transaction;
                        result += command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                Connection.Close();
                return result;
            }
        }

        public int ExecuteSql(List<SqlCommand> commandList, string transactionName)
        {
            using (SqlTransaction transaction = Connection.BeginTransaction(transactionName))
            {
                int scalarOutput = 0;
                try
                {
                    foreach (var cmd in commandList)
                    {
                        cmd.Connection = Connection;
                        cmd.Transaction = transaction;
                        scalarOutput = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    transaction.Commit();
                    commandList.Clear();
                    commandList = null;
                    return scalarOutput;
                }
                catch (System.Exception exExecute)
                {
                    scalarOutput = -1;
                    commandList.Clear();
                    commandList = null;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (System.Exception exRollBack)
                    {
                        throw new Exception(exRollBack.Message);
                    }
                    throw new Exception(exExecute.Message);
                }
            }
        }

        public object ExecuteScalar(SqlCommand command)
        {
            using (command)
            {
                object result = null;
                command.Connection = Connection;
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                result = command.ExecuteScalar();
                //Connection.Close();
                return result;
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql))
            {
                object result = null;
                command.Connection = Connection;
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                result = command.ExecuteScalar();
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// Execute all sql command in this database context to the server. Return scalar output of the last insert command.
        /// </summary>
        /// <returns></returns>
        public virtual int SaveChanges()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            var scalarOutput = ExecuteSql(Commands, "PendTransaction");
            //Connection.Close();
            return scalarOutput;
        }
        #region ***IDisposable Members***
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            //GC.Collect();
            //GC.WaitForPendingFinalizers(); //Ini bikin lambat, contoh saat login, contoh saat get all method, CARI TAUUU
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Connection.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~SqlServerDbAccess()
        {
            Dispose(false);
        }
        #endregion
    }
}
