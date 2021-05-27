using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProductManagement.MVC.Models;
using System;
using System.Collections.Generic;

namespace ProductManagement.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, IMapper mapper,
            ILogger<ProductController> log)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = log;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var productDto = _productRepository.GetAllProducts();
                var prod = _mapper.Map<List<ProductDto>>(productDto);
                _logger.LogInformation("Index method executed");
                return View(prod);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Index method -- " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) // Insert
            {
                return View();
            }
            else // Update
            {
                return RedirectToAction("GetProductById", new { productId = id });
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var prod = _mapper.Map<Product>(product);
                if (product.ProductId > 0)
                {
                    var productDto = _productRepository.UpdateProduct(prod);
                }
                else
                {
                    var productDto = _productRepository.AddProduct(prod);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            var prod = _mapper.Map<ProductDto>(product);
            return View("AddOrEdit", prod);
        }

        [HttpGet]
        public IActionResult DeleteProduct(int productId)
        {
            var IsDeleted = _productRepository.DeleteProduct(productId);
            return RedirectToAction("Index");
        }
    }
}
