using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebFastFood.Models;
using WebFastFood.Services.Contracts;

namespace WebFastFood.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategory _category;
        ILogger<CategoryController> _logger;
        public CategoryController(ICategory category, ILogger<CategoryController> logger)
        {
            _category = category;
            _logger = logger;
        }
        public IActionResult ListCategory()
        {
            try
            {
                _logger.LogWarning("متد ListCategory اجرا شد");
                string mob = User.Identity.Name;
                string token = User.FindFirst("AccessToken").Value;
                _logger.LogInformation("توکن دریافت و لیست بیته بندی ها اجرا شد");
                return View(_category.GetAllCategory(token, mob));
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult CreateCategory()
        {
            return View();
        }
        public IActionResult CreateCategory(CategoryDto category, bool res)
        {
            _logger.LogWarning("متد CreateCategory اجرا شد ");
            _category.AddCategory(category, res);
            if (res == false)
            {
                _logger.LogError("نام دسته بندی تکراری است");
                return BadRequest("Category is Duplicate");
            }
            _logger.LogInformation("دسته بندی ایجاد شد");
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            try
            {
                _logger.LogWarning("متد editeCategory  همراه با ورودی id");
                var category = _category.GetCategoryById(id);
                _logger.LogInformation("دسته بندی ویرایش شد");
                return View(category);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult EditCategory(CategoryDto categoryDto)
        {
            try
            {
                _logger.LogWarning("متد editeCategory  همراه با ورودی categoryDto");

                _category.UpdateCategory(categoryDto);
                _logger.LogInformation("دسته بندی ویرایش شد");

                return RedirectToAction("Category");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _logger.LogWarning("اجرای متد DeleteCategory");
                _category.DeleteCategory(id);
                _logger.LogInformation("با موفقیت حذف شد");
                return RedirectToAction("ListCategory");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
