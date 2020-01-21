using Microsoft.EntityFrameworkCore;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsApp.DAL
{
    public class NewsService
    {
        private ApplicationContext _context;

        public NewsService(ApplicationContext context)
        {
            _context = context;
        }

        public void CreateArticle(Article article)
        {
            article.Date = DateTime.Now;
            article.SetPreview();
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.Include(a => a.Category).ToList().Find(a => a.Id == id);
        }

        public List<Article> GetArticles()
        {
            return _context.Articles.Include(a => a.Category).ToList();
        }

        public void EditArticle(Article article)
        {
            article.SetPreview();
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(int id)
        {
            Article temp = _context.Articles.Find(id);
            _context.Articles.Remove(temp);
            _context.SaveChanges();
        }        
    }
}
