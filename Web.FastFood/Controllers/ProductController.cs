using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebFastFood.Models;
using WebFastFood.Services.Contracts;
using WebFastFood.Services.Repository;

namespace WebFastFood.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        IProduct _product;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProduct product, ILogger<ProductController> logger)
        {
            _product = product;
            _logger = logger;
        }
        public IActionResult Product()
        {
            try
            {
                _logger.LogWarning("اجرای متد لیست محصولات");
                string token = User.FindFirst("AccessToken").Value;
                _logger.LogInformation("دریافت توکن ونمایش لیست به کاربر");
                return View(_product.GetAllProduct(token));
            }
            catch (Exception)
            {

                throw new BadRequestException("خطای ناشناخته");

            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(ProductDto customers, bool res)
        {
            try
            {
                _logger.LogWarning("اجرا متد ایجاد محصول جدید");
                _product.AddProduct(customers, res);
                if (res == false)
                {
                    _logger.LogError("نام محصول تکراری است");
                    return BadRequest("product Name is Duplicate");
                }
                _logger.LogInformation("محصول ایجاد شد");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult SubmitOrder(ProductDto productDto, int numberOfOrder, bool res, int id)
        {
            try
            {
                _logger.LogWarning("اجرای متد جمع محصولات");
                string currentIdUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _product.AddSubmitOrder(productDto, res);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
