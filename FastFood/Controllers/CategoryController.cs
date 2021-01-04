using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoryController : Controller
    {       
        
        private readonly ICategory _category;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        // GET: Categories
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CategoryList()
        {
            var result = _category.ListCategory();
            if (result.IsSucceed)
            {
                if (result.Data != null && result.Data.Any())
                    return Ok(result.Data);
                return NotFound();
            }
            return BadRequest(string.Join(",", result.Errors));
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult CategoryById(int id)
        {
            var result = _category.GetCategoryById(id);
            if (result.IsSucceed)
            {
                if (result.Data != null)
                    return Ok(result.Data);
                return NotFound();
            }
            return BadRequest(string.Join(",", result.Errors));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _category.AddCategory(new Category
            {
                CategoryName = category.CategoryName
            });

            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _category.UpdateCategory(category);
            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id, Category category)
        {
            var result = _category.DeleteCategory(id);
            if (result.IsSucceed)
            {
                if (result.Data != null)
                    return Ok(result.Data);
                return NotFound();
            }
            return BadRequest(string.Join(",", result.Errors));
        }
    }
}
