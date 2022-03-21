using ModelGlobal_DataAccessLayer.Models;

namespace GestionArticle.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
