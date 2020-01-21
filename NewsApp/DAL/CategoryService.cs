using NewsApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NewsApp.DAL
{
    public class CategoryService
    {
        private ApplicationContext _context;

        public CategoryService(ApplicationContext context)
        {
            _context = context;
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

        public Category GetCategoryWithNews(int id)
        {
            return _context.Categories.Include(c => c.Articles).ToList().Find(c => c.Id == id);
        }
    }
}
