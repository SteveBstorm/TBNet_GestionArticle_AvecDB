using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestionArticle.Tools
{
    //Création de l'attribut [AuthRequired] qui nécéssite l'utilisation d'un Filtre
    public class AuthRequiredAttribute : TypeFilterAttribute   
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter)) { }
    }

    //Création du filtre d'autorisation qui vérifie dans le session manager si l'utilisateur est bien connecté
    public class AuthRequiredFilter : IAuthorizationFilter
    {
        private readonly SessionManager _sessionManager;
        public AuthRequiredFilter(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(_sessionManager.CurrentUser is null)
            {
                context.Result = new RedirectToRouteResult(new { action = "Login", controller = "Auth" });
            }
        }
    }
}
