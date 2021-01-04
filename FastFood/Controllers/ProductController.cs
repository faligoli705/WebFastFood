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
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly ILogger<ProductController> _logger;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public ProductController(IProduct product,ILogger<ProductController> logger)
        {
            this._product = product;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ProductList()
        {
            _logger.LogWarning("اجرای متد PRoductList");
            var result = _product.ListProduct();
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
        public IActionResult ProductById(int id)
        {
            var result = _product.GetProductById(id);
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
        /// <param name="Products"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProduct(Products Products)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _product.AddProduct(new Products
            {
                ProductName = Products.ProductName,
                CategoryId = Products.CategoryId,
                UnitPrice = Products.UnitPrice
            });

            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
      
        [HttpPost("SubmitOrder",Name = "AddSubmitOrder")]
        public IActionResult AddSubmitOrder(Products Products)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _product.AddProduct(new Products
            {
                ProductName = Products.ProductName,
                CategoryId = Products.CategoryId,
                UnitPrice = Products.UnitPrice
            });

            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Products"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Products Products)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _product.UpdateProduct(Products);
            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Products"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id, Products Products)
        {
            var result = _product.DeleteProduct(id);
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
