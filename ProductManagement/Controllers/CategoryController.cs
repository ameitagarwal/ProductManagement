using AutoMapper;
using CategoryManagement.Data.Services;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Models;
using System.Collections.Generic;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _categoryRepository = CategoryRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult InsertCategory([FromBody] CategoryModel CategoryModel)
        {
            var category = _mapper.Map<Category>(CategoryModel);
            var categoryDto = _categoryRepository.AddCategory(category);
            if (categoryDto)
            {
                var categoryToReturn = category;
                return CreatedAtRoute("GetCategory",
                    new { categoryId = category.CategoryId },
                    categoryToReturn);
            }
            return BadRequest();
        }

        [HttpPost("BulkInsert")]
        public IActionResult InsertMultiple([FromBody] List<CategoryModel> categories)
        {
            var categoryEntity = _mapper.Map<List<Category>>(categories);
            var categoryDto = _categoryRepository.AddCategoryList(categoryEntity);

            return Ok();
            //if (categoryDto)
            //{
            //    var categoryToReturn = category;
            //    return CreatedAtRoute("GetCategory",
            //        new { productId = category.CategoryId },
            //        categoryToReturn);
            //}
            //return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categoryDto = _categoryRepository.GetAllCategorys();
            var category = _mapper.Map<List<CategoryModel>>(categoryDto);
            if (category != null && category.Count > 0)
            {
                return Ok(category);
            }
            return NoContent();
        }

        [HttpGet("{categoryId}", Name = "GetCategory")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            var cate = _mapper.Map<CategoryModel>(category);
            if (cate is null)
            {
                return NoContent();
            }
            return Ok(cate);
        }
    }
}
