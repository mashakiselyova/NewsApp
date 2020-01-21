using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;

namespace NewsApp.Components
{
    public class Categories : ViewComponent
    {
        private CategoryService _service;

        public Categories(CategoryService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            return View(_service.GetCategories());
        }
    }
}
