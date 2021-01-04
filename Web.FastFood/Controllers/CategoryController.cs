using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebFastFood.Models;
using WebFastFood.Services.Repository;

namespace WebFastFood.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryRepository _category;
        public CategoryController()
        {
            _category = new CategoryRepository();
        }
        public IActionResult ListCategory()
        {
            string mob = User.Identity.Name;
            string token = User.FindFirst("AccessToken").Value;
            return View(_category.GetAllCategory(token, mob));
        }

        
        public IActionResult CreateCategory()
        {
            return View();
        }
        public IActionResult CreateCategory(CategoryDto category, bool res)
        {
            _category.AddCategory(category, res);
            if (res == false)
                return BadRequest("Mobile is Duplicate");
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            var category = _category.GetCategoryById(id);
            return View(category);
        }

        public IActionResult EditCategory(CategoryDto categoryDto)
        {
            _category.UpdateCategory(categoryDto);
            return RedirectToAction("Category");
        }

        public IActionResult DeleteCategory(int id)
        {
            _category.DeleteCategory(id);
            return RedirectToAction("ListCategory");

        }
    }
}
