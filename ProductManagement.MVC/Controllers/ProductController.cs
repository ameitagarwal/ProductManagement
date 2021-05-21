using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProductManagement.MVC.Models;
using System.Collections.Generic;

namespace ProductManagement.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productDto = _productRepository.GetAllProducts();
            var prod = _mapper.Map<List<ProductDto>>(productDto);
            return View(prod);
        }

        [HttpPost]
        public IActionResult AddOrEdit(ProductDto productModel)
        {
            return View();
        }

        [HttpGet("{productId}", Name = "Getproduct")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            var prod = _mapper.Map<ProductDto>(product);
            return View(prod);
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var IsDeleted = _productRepository.DeleteProduct(productId);
            return IsDeleted ? NoContent() : BadRequest();
        }
    }
}
