using ModelGlobal_DataAccessLayer.Models;

namespace ModelGlobal_DataAccessLayer.Repositories
{
    public interface IAppUserRepository
    {
        AppUser Login(string email, string password);
        bool Register(string email, string password);
    }
}