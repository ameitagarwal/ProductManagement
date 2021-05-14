using ProductManagement.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Data.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public bool AddProduct(Product product)
        {
            _context.Products.Add(product);
            return SaveChanges();
        }

        public bool AddProductList(List<Product> products)
        {
            _context.Products.AddRange(products);
            return SaveChanges();
        }
        public bool UpdateProductList(List<Product> products)
        {
            _context.Products.UpdateRange(products);
            return SaveChanges();
        }
        public bool UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return SaveChanges();
        }
        public bool DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                return SaveChanges();
            }
            return true;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {

            //var a = _context.Products.First(a => a.ProductId == productId);
            //var c = _context.Products.Single(a => a.ProductId == productId);
            //var b = _context.Products.SingleOrDefault(a => a.ProductId == productId);            
            //var d = _context.Products.Where(a => a.ProductId == productId).FirstOrDefault();
            //var e = _context.Products.Find();
            return _context.Products.FirstOrDefault(a => a.ProductId == productId);
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
