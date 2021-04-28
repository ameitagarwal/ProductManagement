using ProductManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Data.Services
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
    }
}
