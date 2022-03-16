using GestionArticle.Models;
using GestionArticle.Services;
using GestionArticle.Tools;
using Microsoft.AspNetCore.Mvc;

namespace GestionArticle.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View(ArticleService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(ArticleService.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticleForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            if (ArticleService.Create(form.ToData()))
            {
                return RedirectToAction("Index");
            }

            ViewBag.ErrorMessage = "Le nom des articles doivent être unique";
            return View(form);
        }

        public IActionResult Delete(int id)
        {
            ArticleService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(ArticleService.GetById(id).ToView());
        }
        [HttpPost]
        public IActionResult Edit(ArticleForm f)
        {
            if(!ModelState.IsValid) return View(f);

            ArticleService.Update(f.ToData());

            return RedirectToAction("Index");
        }
    }
}
