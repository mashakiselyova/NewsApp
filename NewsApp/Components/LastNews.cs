using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsApp.Models;
using System.Linq;

namespace NewsApp.Components
{
    public class LastNews : ViewComponent
    {
        private ApplicationContext _context;

        public LastNews(ApplicationContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Articles.Include(a => a.Category).OrderByDescending(a => a.Date).Take(3).ToList());
        }
    }
}
