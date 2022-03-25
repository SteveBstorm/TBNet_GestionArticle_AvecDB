using GestionArticle.Models;
using System.Text.Json;

namespace GestionArticle.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public AppUser? CurrentUser
        {
            get {
                if(string.IsNullOrWhiteSpace(_session.GetString("user")))
                {
                    return null;
                }
                return JsonSerializer.Deserialize<AppUser>(_session.GetString("user")); }
            set { _session.SetString("user", JsonSerializer.Serialize(value)); }
        }

        public void Disconnect()
        {
            _session.Clear();
        }

    }
}
