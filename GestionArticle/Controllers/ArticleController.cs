using GestionArticle.Models;
using GestionArticle.Tools;
using Microsoft.AspNetCore.Mvc;
using ModelGlobal_DataAccessLayer.Repositories;

namespace GestionArticle.Controllers
{
    public class ArticleController : Controller
    {

        private IArticleRepository _service;
        private ICategoryRepository _catService;

        public ArticleController(IArticleRepository service, ICategoryRepository catService)
        {
            _service = service;
            _catService = catService;
        }
        public IActionResult Index(int id = 0)
        {
            IndexViewModel model = new IndexViewModel();
            
            if (id == 0)
                model.Articles = _service.GetAll().Select(a => a.ToASP());
            else
                //model.Articles = _service.GetAll().Where(c => c.CategoryId == id).Select(a => a.ToASP());
                model.Articles = _service.GetByCategory(id).Select(a => a.ToASP());
            model.Categories = _catService.GetAll();
            return View(model);
        }
        public IActionResult Instance()
        {
            return Content(_service.InstanceID.ToString());
        }

        public IActionResult Details(int id)
        {
            Article currentArticle = _service.GetById(id).ToASP();
            currentArticle.CategoryName = _catService.GetNameById(currentArticle.CategoryId);
            return View(currentArticle);
        }

        public IActionResult Create()
        {
            ArticleForm form = new ArticleForm();
            form.CategoryList = _catService.GetAll();
            return View(form);
        }

        [HttpPost]
        public IActionResult Create(ArticleForm form)
        {
            form.CategoryList = _catService.GetAll();
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
