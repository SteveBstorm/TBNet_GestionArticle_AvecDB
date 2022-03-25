using GestionArticle.Models;
using GestionArticle.Tools;
using Microsoft.AspNetCore.Mvc;
using ModelGlobal_DataAccessLayer.Repositories;

namespace GestionArticle.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserRepository _repo;
        private readonly SessionManager _sessionManager;

        public AuthController(IAppUserRepository repo, SessionManager sessionManager)
        {
            _repo = repo;
            _sessionManager = sessionManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserForm form)
        {
            if(!ModelState.IsValid) return View(form);

            _repo.Register(form.Email, form.Password);
            return RedirectToAction("Index", "Article");
        }
        
        public IActionResult Login()
        {
            return View();
        }
  
        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid) return View(form);

            AppUser currentUser = _repo.Login(form.Email, form.Password).ToASP();
            //HttpContext.Session.SetString("ScreenName", currentUser.ScreenName);
            //HttpContext.Session.SetInt32("Id", currentUser.Id);
            _sessionManager.CurrentUser = currentUser;

            return RedirectToAction("Index", "Article");
        }

        public IActionResult LogOut()
        {
            //HttpContext.Session.Clear();
            _sessionManager.Disconnect();
            return RedirectToAction("Login");
        }
    }
}
