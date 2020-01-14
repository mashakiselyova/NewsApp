using Microsoft.AspNetCore.Mvc;
using NewsApp.Models;
using System.Linq;
using NewsApp.DAL;

namespace NewsApp.Controllers
{
    public class CategoriesController : Controller
    {
        private NewsService _service;

        public CategoriesController(NewsService service)
        {
            _service = service;
        }

        public IActionResult Index() => View(_service.GetCategories());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _service.CreateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}