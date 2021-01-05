using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CategoryController> _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        public CategoryController(ICategory category, ILogger<CategoryController> logger)
        {
            _category = category;
            _logger = logger;
        }

        // GET: Categories
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CategoryList()
        {
            try
            {
                _logger.LogWarning("اجرای متد ایجاد دسته بندی");
                var result = _category.ListCategory();
                if (result.IsSucceed)
                {
                    if (result.Data != null && result.Data.Any())
                    {
                        _logger.LogInformation("نمایش لیست محصولات");
                        return Ok(result.Data);
                    }
                    else
                    {
                        return NotFound();
                        _logger.LogError("محصولی یافت نشد");
                    }
                }
                return BadRequest(string.Join(",", result.Errors));
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult CategoryById(int id)
        {
            try
            {
                _logger.LogWarning("اجرای متد پیدا کردن دسته بندی بر اساس آیدی");
                var result = _category.GetCategoryById(id);
                if (result.IsSucceed)
                {
                    if (result.Data != null)
                    {
                        _logger.LogError(" نمایش دسته بندی ها بر اساس ایدی");
                        return Ok(result.Data);
                    }
                    else
                    {
                        _logger.LogError("دسته بندی یافت نشد");
                        return NotFound();
                    }
                }
                return BadRequest(string.Join(",", result.Errors));
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                _logger.LogInformation("وارد شدن به متدAddCategory");
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                    _logger.LogError("mode not valid");
                    return BadRequest(string.Join(",", errors));
                }
                var result = _category.AddCategory(new Category
                {
                    CategoryName = category.CategoryName,
                });

                if (result.IsSucceed)
                {
                    _logger.LogInformation("دسته بندی با موفقیت اضافه شد");
                    return Ok(result.Data);
                }
                return BadRequest(string.Join(",", result.Errors));
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                _logger.LogInformation("ورود به UpdateCategory");
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                    _logger.LogError("The Model state not valid");
                    return BadRequest(string.Join(",", errors));
                }
                var result = _category.UpdateCategory(category);
                if (result.IsSucceed)
                {
                    _logger.LogInformation("دسته بندی اپدیت شد", category.Id);
                    return Ok(result.Data);
                }
                _logger.LogError("دسته بندی اپدیت نشد", category.Id);
                return BadRequest(string.Join(",", result.Errors));
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                var result = _category.DeleteCategory(id);
                if (result.IsSucceed)
                {
                    if (result.Data != null)
                    {
                        _logger.LogInformation("دسته بندی حذف شد", category.Id);
                        return Ok(result.Data);
                    }
                    _logger.LogError("دسته بندی قبلا حذف شده است", category.Id);

                    return NotFound();
                }
                return BadRequest(string.Join(",", result.Errors));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
