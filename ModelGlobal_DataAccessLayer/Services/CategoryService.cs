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
    public class CategoryService : ICategoryRepository
    {
        private string _connectionString;

        private readonly IConfiguration _config;

        public CategoryService(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("default");
        }

        internal Category Converter(SqlDataReader reader)
        {
            return new Category
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()
            };
        }

        public IEnumerable<Category> GetAll()
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("SELECT * FROM Category");

            return cnx.ExecuteReader(cmd, Converter);
        }

        public bool Create(string name)
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("AddCategory", true);

            cmd.AddParameter("name", name);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public string GetNameById(int Id)
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("SELECT [Name] FROM Category WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteScalar(cmd).ToString() ?? "";
        }
    }
}
