using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsApp.Models;

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
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.Find(id);
        }

        public List<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        public void EditArticle(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(int id)
        {
            Article temp = _context.Articles.Find(id);
            _context.Articles.Remove(temp);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _context.Categories.Remove(_context.Categories.Find(id));
            _context.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }
    }
}
