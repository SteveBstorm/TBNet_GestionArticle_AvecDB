using ModelGlobal_DataAccessLayer.Models;

namespace ModelGlobal_DataAccessLayer.Repositories
{
    public interface ICategoryRepository
    {
        bool Create(string name);
        IEnumerable<Category> GetAll();
        string GetNameById(int Id);
    }
}