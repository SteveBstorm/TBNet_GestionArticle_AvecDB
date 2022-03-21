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
    public class ArticleService : IArticleRepository
    {
        public Guid InstanceID { get; set; } = Guid.NewGuid();

        private string _connectionString; 

        private readonly IConfiguration _config;

        public ArticleService(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("default");
        }

        internal Article Converter(SqlDataReader reader)
        {
            return new Article
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                EAN13 = reader["EAN13"].ToString(),
                Price = (decimal)reader["Price"],
                Description = reader["Description"].ToString(),
                CategoryId = (int)reader["CategoryId"]
            };
        }

        public IEnumerable<Article> GetAll()
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("SELECT * FROM Article");

            return cnx.ExecuteReader(cmd, Converter);
        }

        public IEnumerable<Article> GetByCategory(int Id)
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("SELECT * FROM Article WHERE CategoryId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converter);
        }

        public Article GetById(int Id)
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("SELECT * FROM Article WHERE Id = @id");
            cmd.AddParameter("id", Id);

            return cnx.ExecuteReader(cmd, Converter).FirstOrDefault();
        }

        public bool Create(Article article)
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("AddArticle", true);

            cmd.AddParameter("name", article.Name);
            cmd.AddParameter("EAN13", article.EAN13);
            cmd.AddParameter("price", article.Price);
            cmd.AddParameter("desc", article.Description);
            cmd.AddParameter("catId", article.CategoryId);
            try
            {
                return cnx.ExecuteNonQuery(cmd) == 1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Article article)
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("UpdateArticle", true);

            cmd.AddParameter("name", article.Name);
            cmd.AddParameter("EAN13", article.EAN13);
            cmd.AddParameter("price", article.Price);
            cmd.AddParameter("desc", article.Description);
            cmd.AddParameter("id", article.Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int Id)
        {
            Connection cnx = new Connection(_connectionString);

            Command cmd = new Command("DeleteArticle", true);

            cmd.AddParameter("id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}
