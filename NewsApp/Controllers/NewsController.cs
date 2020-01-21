using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;
using NewsApp.Models;
using NewsApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NewsApp.Controllers
{
    public class NewsController : Controller
    {
        private NewsService _newsService;
        private CategoryService _categoryService;

        public NewsController(NewsService service, CategoryService categoryService)
        {
            _newsService = service;
            _categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {
            List<Article> articles = (from a in _newsService.GetArticles()
                            orderby a.Date descending
                            select a).ToList();
            return View(Pagination(articles, page));
        }

        public IActionResult NewsByCategory(int categoryId, int page = 1)
        {
            List<Article> articles = (from a in _categoryService.GetCategoryWithNews(categoryId).Articles
                                orderby a.Date descending
                                select a).ToList();
            return View(Pagination(articles, page));
        }

        public IActionResult ShowArticle(int id)
        {
            return View(_newsService.GetArticle(id));
        }

        private NewsViewModel Pagination(List<Article> articles, int page)
        {
            int pageSize = 5;
            int count = articles.Count;
            List<Article> items = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            NewsViewModel model = new NewsViewModel
            {
                Articles = items,
                PageViewModel = pageViewModel
            };
            return model;
        }
    }
}