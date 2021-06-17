using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LuggageSystem
{
    public class DBConnection
    {
        /// <summary>
        /// 
        /// </summary>
        private NpgsqlConnection _Connection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        public DBConnection(string host, string username, string password, string database)
        {
            string connectionString = $"Host={host};Username={username};Password={username};Database={database}";
            NpgsqlConnection _Connection = new NpgsqlConnection(connectionString);
        }
        /// <summary>
        /// Open a connection to a database
        /// </summary>
        public void Open()
        {
            try
            {
                _Connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("A connection is already open");
            }
        }
        /// <summary>
        /// Close the connectiong to the database
        /// </summary>
        public void Close()
        {
            try
            {
                _Connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("A connection is already closed");
            }
        }
        /// <summary>
        /// Query the database
        /// </summary>
        /// <param name="sql">Sql sentence</param>
        /// <returns>This method returns an object containing the response from the DB server</returns>
        public object Query(string sql)
        {
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, _Connection);

            return cmd.ExecuteScalar();
        }
    }
}
