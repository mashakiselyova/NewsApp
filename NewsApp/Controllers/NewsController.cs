using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class NewsController : Controller
    {
        private NewsService _service;

        public NewsController(NewsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Article> articles = (from a in _service.GetArticles()
                            orderby a.Date descending
                            select a).ToList();
            return View(articles);
        }

        public IActionResult ShowArticle(int id)
        {
            return View(_service.GetArticle(id));
        }
    }
}