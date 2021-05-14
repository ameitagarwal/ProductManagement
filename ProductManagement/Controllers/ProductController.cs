using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProductManagement.Models;
using System.Collections.Generic;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] ProductModel productModel)
        {
            var prod = _mapper.Map<Product>(productModel);
            //Product prod = new Product
            //{
            //    Price = product.Price,
            //    Description = product.Description,
            //    ProductCode = product.ProductCode,
            //    ProductName = product.ProductName,
            //};
            var productDto = _productRepository.AddProduct(prod);
            if (productDto)
            {
                var productToReturn = prod;
                return CreatedAtRoute("Getproduct",
                    new { productId = prod.ProductId },
                    productToReturn);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            //IEnumerable<Product> productDto = new List<Product>();
            var productDto = _productRepository.GetAllProducts();
            var prod = _mapper.Map<List<ProductModel>>(productDto);
            if (prod != null && prod.Count > 0)
            {
                return Ok(prod);
            }
            return NoContent();
        }

        [HttpGet("V2")]

        public IActionResult GetAllProductV2()
        {
            //IEnumerable<Product> productDto = new List<Product>();
            var productDto = _productRepository.GetAllProducts();
            var prod = _mapper.Map<List<ProductModel>>(productDto);
            if (prod != null && prod.Count > 0)
            {
                return Ok(prod);
            }
            return NoContent();
        }
        [HttpGet("{productId}", Name = "Getproduct")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            var prod = _mapper.Map<ProductModel>(product);
            if (prod is null)
            {
                return NoContent();
            }
            return Ok(prod);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductModel productModel)
        {
            var prod = _mapper.Map<Product>(productModel);
            //Product prod = new Product
            //{
            //    Price = product.Price,
            //    Description = product.Description,
            //    ProductCode = product.ProductCode,
            //    ProductName = product.ProductName,
            //};
            var productDto = _productRepository.UpdateProduct(prod);
            if (productDto)
            {
                var productToReturn = prod;
                return CreatedAtRoute("Getproduct",
                    new { productId = prod.ProductId },
                    productToReturn);
            }
            return BadRequest();
        }
        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var IsDeleted = _productRepository.DeleteProduct(productId);
            if (IsDeleted)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
