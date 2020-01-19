using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;
using NewsApp.Models;
using NewsApp.ViewModels;

namespace NewsApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class EditNewsController : Controller
    {
        private NewsService _service;

        public EditNewsController(NewsService service)
        {
            _service = service;
        }

        public IActionResult Index() => View(_service.GetArticles());

        [HttpGet]
        public IActionResult Create()
        {
            EditNewsViewModel model = new EditNewsViewModel();
            model.Categories = _service.GetCategories();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Article article, int categoryId)
        {
            if (categoryId != 0) 
                article.Category = _service.GetCategory(categoryId);
            _service.CreateArticle(article);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeleteArticle(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Article article = _service.GetArticle(id);
            EditNewsViewModel model = new EditNewsViewModel();
            model.Categories = _service.GetCategories();
            model.Title = article.Title;
            model.Author = article.Author;
            model.Category = article.Category;
            model.Text = article.Text;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Article article, int categoryId)
        {
            if (categoryId != 0)
                article.Category = _service.GetCategory(categoryId);
            _service.EditArticle(article);
            return RedirectToAction("Index");
        }
    }
}