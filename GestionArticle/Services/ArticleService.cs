using GestionArticle.Models;

namespace GestionArticle.Services
{
    public static class ArticleService
    {
        private static List<Article> liste = new List<Article>();
        private static int Id = 0;

        private static int GetCurrentId()
        {
            return ++Id;
        }
        public static List<Article> GetAll()
        {
            return liste.OrderBy(x => x.Id).ToList();
        }

        public static Article GetById(int id)
        {
            try
            {
                return liste.First(a => a.Id == id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int id)
        {
            liste.Remove(liste.Where(a => a.Id == id).First());
        }

        public static bool Create(Article newArticle)
        {
            if(liste.Where(x => x.Name == newArticle.Name).Count() > 0)
            {
                return false;
            }
            newArticle.Id = Id;
            liste.Add(newArticle);
            return true;
        }

        public static void Update(Article a)
        {
            
            liste.Remove(liste.First(x => x.Id == a.Id));
            liste.Add(a);

        }
    }
}
