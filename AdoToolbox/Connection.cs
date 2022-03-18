using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoToolbox
{
    public class Connection
    {
        private string _connectionString;

        public Connection(string connectionString)
        {
            if(string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }

        private SqlCommand CreateCommand(Command command, SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();

            cmd.CommandText = command.Query;
            cmd.CommandType = (command.IsStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;

            foreach (KeyValuePair<string, object> item in command.Parameters)
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = item.Key,
                    Value = (item.Value is null) ? DBNull.Value : item.Value
                };

                cmd.Parameters.Add(parameter);
            }

            return cmd;
        }

        public int ExecuteNonQuery(Command cmd)
        {
            using(SqlConnection c = CreateConnection())
            {
                using(SqlCommand command = CreateCommand(cmd, c))
                {
                    c.Open();
                    int result = command.ExecuteNonQuery();
                    c.Close();
                    return result;
                }
            }
        }

        public object ExecuteScalar(Command cmd)
        {
            using(SqlConnection c = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(cmd, c))
                {
                    c.Open();
                    object result = command.ExecuteScalar();
                    c.Close();
                    return (result is DBNull) ? null : result;
                }
            }
        }

        public IEnumerable<T> ExecuteReader<T>(Command cmd, Func<SqlDataReader, T> Convert)
        {
            using(SqlConnection c = CreateConnection())
            {
                using(SqlCommand command = CreateCommand(cmd,c))
                {
                    c.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Convert(reader);
                        }
                    }
                }
            }
        }

        public DataTable GetDataTable(Command cmd)
        {
            using(SqlConnection c = CreateConnection())
            {
                using(SqlCommand command = CreateCommand(cmd, c))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = command;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
        }
    }
}
