using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] Product product)
        {
            var productDto = _productRepository.AddProduct(product);
            if (productDto)
            {
                var productToReturn = product;
                return CreatedAtRoute("Getproduct",
                    new { productId = product.ProductId },
                    productToReturn);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            //IEnumerable<Product> productDto = new List<Product>();
            var productDto = _productRepository.GetAllProducts();
            if (productDto != null && productDto.Count > 0)
            {
                return Ok(productDto);
            }
            return NoContent();
        }
        [HttpGet("{productId}", Name = "Getproduct")]
        public IActionResult GetProductById(int productId)
        {

            var product = _productRepository.GetProductById(productId);
            if (product is null)
            {
                return NoContent();
            }
            return Ok(product);
        }
    }
}
