using ProductManagement.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Data.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _context;

        public CategoryRepository(ProductDbContext context)
        {
            _context = context;
        }

        public bool AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            return SaveChanges();
        }

        public bool AddCategoryList(List<Category> Categorys)
        {
            _context.Categories.AddRange(Categorys);
            return SaveChanges();
        }
        public bool UpdateCategoryList(List<Category> Categorys)
        {
            _context.Categories.UpdateRange(Categorys);
            return SaveChanges();
        }
        public bool UpdateCategory(Category Category)
        {
            _context.Categories.Update(Category);
            return SaveChanges();
        }
        public bool DeleteCategory(int CategoryId)
        {
            var Category = GetCategoryById(CategoryId);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                return SaveChanges();
            }
            return true;
        }
        public List<Category> GetAllCategorys()
        {
            return _context.Categories
                .ToList();
        }

        public Category GetCategoryById(int CategoryId)
        {

            //var a = _context.Categorys.First(a => a.CategoryId == CategoryId);
            //var c = _context.Categorys.Single(a => a.CategoryId == CategoryId);
            //var b = _context.Categorys.SingleOrDefault(a => a.CategoryId == CategoryId);            
            //var d = _context.Categorys.Where(a => a.CategoryId == CategoryId).FirstOrDefault();
            //var e = _context.Categorys.Find();            
            return _context.Categories.FirstOrDefault(a => a.CategoryId == CategoryId);
        }

        private bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            };
            return false;
        }
    }
}
