﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;
using NewsApp.Models;
using NewsApp.ViewModels;

namespace NewsApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class EditNewsController : Controller
    {
        private NewsService _newsService;
        private CategoryService _categoryService;

        public EditNewsController(NewsService service, CategoryService categoryService)
        {
            _newsService = service;
            _categoryService = categoryService;
        }

        public IActionResult Index() => View(_newsService.GetArticles());

        [HttpGet]
        public IActionResult Create()
        {
            EditNewsViewModel model = new EditNewsViewModel();
            model.Categories = _categoryService.GetCategories();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Article article, int categoryId)
        {
            if (categoryId != 0) 
                article.Category = _categoryService.GetCategory(categoryId);
            _newsService.CreateArticle(article);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _newsService.DeleteArticle(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Article article = _newsService.GetArticle(id);
            EditNewsViewModel model = new EditNewsViewModel();
            model.Categories = _categoryService.GetCategories();
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
                article.Category = _categoryService.GetCategory(categoryId);
            _newsService.EditArticle(article);
            return RedirectToAction("Index");
        }
    }
}