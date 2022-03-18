using GestionArticle.Models;
using Microsoft.AspNetCore.Mvc;
using ModelGlobal_DataAccessLayer.Repositories;
using System.Diagnostics;

namespace GestionArticle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticleRepository _service;
        public HomeController(IArticleRepository service, ILogger<HomeController> logger)
        {
            _logger = logger;
            _service = service;
        }
        public IActionResult Instance()
        {
            return Content(_service.InstanceID.ToString());
        }


        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}