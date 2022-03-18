using GestionArticle.Models;
using GestionArticle.Services;
using GestionArticle.Tools;
using Microsoft.AspNetCore.Mvc;
using DAL = ModelGlobal_DataAccessLayer.Services;

namespace GestionArticle.Controllers
{
    public class ArticleController : Controller
    {

        private DAL.ArticleService _service;

        public ArticleController()
        {
            _service = new DAL.ArticleService();
        }
        public IActionResult Index()
        {
            return View(_service.GetAll().Select(a => a.ToASP()));
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
