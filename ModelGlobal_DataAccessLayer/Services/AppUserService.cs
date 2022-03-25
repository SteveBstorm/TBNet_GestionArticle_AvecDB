using AdoToolbox;
using Microsoft.Extensions.Configuration;
using ModelGlobal_DataAccessLayer.Models;
using ModelGlobal_DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGlobal_DataAccessLayer.Services
{
    public class AppUserService : IAppUserRepository
    {
        private string _connectionString;

        public AppUserService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        internal AppUser Converter(SqlDataReader reader)
        {
            return new AppUser
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString()
            };
        }

        public bool Register(string email, string password)
        {
            Connection cnx = new Connection(_connectionString);
            Command cmd = new Command("AddUser", true);
            cmd.AddParameter("email", email);
            cmd.AddParameter("passwd", password);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public AppUser Login(string email, string password)
        {
            Connection cnx = new Connection(_connectionString);
            Command cmd = new Command("LoginUser", true);
            cmd.AddParameter("email", email);
            cmd.AddParameter("passwd", password);

            return cnx.ExecuteReader(cmd, Converter).FirstOrDefault();
        }
    }
}
