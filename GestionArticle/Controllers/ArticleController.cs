using GestionArticle.Models;
using GestionArticle.Tools;
using Microsoft.AspNetCore.Mvc;
using ModelGlobal_DataAccessLayer.Repositories;

namespace GestionArticle.Controllers
{
    public class ArticleController : Controller
    {

        private IArticleRepository _service;

        public ArticleController(IArticleRepository service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll().Select(a => a.ToASP()));
        }

        public IActionResult Instance()
        {
            return Content(_service.InstanceID.ToString());
        }

        public IActionResult Details(int id)
        {
            return View(_service.GetById(id).ToASP());
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

            try
            {
                _service.Create(form.FormToDAL());
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(form);
            }
           
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_service.GetById(id).ToFormView());
        }
        [HttpPost]
        public IActionResult Edit(ArticleForm f)
        {
            if(!ModelState.IsValid) return View(f);

            _service.Update(f.FormToDAL());

            return RedirectToAction("Index");
        }
    }
}
