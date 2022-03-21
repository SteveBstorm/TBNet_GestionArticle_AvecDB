using GestionArticle.Models;
using Microsoft.AspNetCore.Mvc;
using ModelGlobal_DataAccessLayer.Repositories;

namespace GestionArticle.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryForm form)
        {
            if (!ModelState.IsValid) return View(form);

            _repo.Create(form.Name);

            return RedirectToAction("Index");
        }
    }
}
