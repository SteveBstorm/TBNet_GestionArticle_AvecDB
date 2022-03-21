using GestionArticle.Models;
using DAL = ModelGlobal_DataAccessLayer.Models;
using ASP = GestionArticle.Models;

namespace GestionArticle.Tools
{
    public static class Mappers
    {
        public static ASP.Article ToASP(this DAL.Article a)
        {
            return new Article
            {
                Id = a.Id,
                Name = a.Name,
                EAN13 = a.EAN13,
                Price = a.Price,
                Description = a.Description,
                CategoryId = a.CategoryId
            };
        }

        public static DAL.Article FormToDAL(this ArticleForm f)
        {
            return new DAL.Article
            {
                Id = f.Id,
                Name = f.Name,
                EAN13 = f.EAN13,
                Price = f.Price,
                Description = f.Description,
                CategoryId = f.CategoryId
            };
        }

        public static ArticleForm ToFormView(this DAL.Article f)
        {
            return new ArticleForm
            {
                Id = f.Id,
                Name = f.Name,
                EAN13 = f.EAN13,
                Price = f.Price,
                Description = f.Description,
                CategoryId=f.CategoryId
            };
        }
    }
}
