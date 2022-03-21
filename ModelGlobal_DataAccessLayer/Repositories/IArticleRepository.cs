using ModelGlobal_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGlobal_DataAccessLayer.Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article GetById(int Id);
        bool Create(Article article);
        bool Update(Article article);
        bool Delete(int Id);
        Guid InstanceID { get; set; }
        IEnumerable<Article> GetByCategory(int Id);

    }
}
