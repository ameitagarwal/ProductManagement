using ProductManagement.Data.Entities;
using System.Collections.Generic;

namespace ProductManagement.Data.Services
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
    }
}
