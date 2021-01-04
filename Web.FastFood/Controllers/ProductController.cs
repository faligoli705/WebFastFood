using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebFastFood.Models;
using WebFastFood.Services.Repository;

namespace WebFastFood.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        ProductRepository _product;
        public ProductController()
        {
            _product = new ProductRepository();
        }
        public IActionResult Product()
        {
            string token = User.FindFirst("AccessToken").Value;
            return View(_product.GetAllProduct(token));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(ProductDto customers, bool res)
        {
            _product.AddProduct(customers, res);
            if (res == false)
                return BadRequest("product Name is Duplicate");
            return RedirectToAction("Index");
        }

        
        public IActionResult SubmitOrder(ProductDto productDto,int numberOfOrder, bool res,int id)
        {
            string currentIdUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _product.AddSubmitOrder(productDto,res);
            return View();
        }

    }
}
