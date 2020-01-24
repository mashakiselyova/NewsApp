using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;
using System.Linq;

namespace NewsApp.Components
{
    public class LastNews : ViewComponent
    {
        private NewsService _service;

        public LastNews(NewsService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            return View(_service.GetArticles().OrderByDescending(a => a.Date).Take(3).ToList());
        }
    }
}
