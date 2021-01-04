using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastFood.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[EnableCors("EnableCors")]
    [Route("api/[Controller]")]
    [ApiController]
   // [Authorize]
    
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        ILogger<CustomerController> _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public CustomerController(ICustomer customer,ILogger<CustomerController> logger)
        {
            this._customer = customer;
            this._logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CustomerList()
        {
            _logger.LogError("اجرای متد CustomerList");
            string mob= User.FindFirstValue(ClaimTypes.Name);
            var result = _customer.Listcustomers(mob);
            if (result.IsSucceed)
            {
                if (result.Data != null && result.Data.Any())
                {
                    _logger.LogError("دریافت لیست کاربرها");
                    return Ok(result.Data);
                }
                else {
                    _logger.LogError("کاربری یافت نشد");
                return NotFound(); }
            }
            return BadRequest(string.Join(",", result.Errors));
        }
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult CustomerById(int id)
        {
            _logger.LogInformation("اجرای متد CustomerById");
            var result = _customer.GetCustomerById(id);
            if (result.IsSucceed)
            {
                if (result.Data != null)
                {
                    _logger.LogInformation("کاربر پیدا شد");
                    return Ok(result.Data);
                }
                else
                {
                    _logger.LogError("کاربری یافت نشد");
                    return NotFound();
                }
            }
            return BadRequest(string.Join(",", result.Errors));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCustomer(Customers customers)
        {
            _logger.LogInformation("اجرای متد AddCustomer");
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                _logger.LogError("Model in Not valid");
                return BadRequest(string.Join(",", errors));
            }
            var result = _customer.AddCustomer(new Customers
            {
                FName = customers.FName,
                LName = customers.LName,
                Mobile = customers.Mobile,
                Address = customers.Address,
                StatusCustomer = customers.StatusCustomer,
                PasswordCustomer = customers.PasswordCustomer,
                CustomerCreateDate = DateTime.Now
            });

            if (result.IsSucceed)
            {
                _logger.LogInformation("کاربر با موفقیت اضافه شد");
                return Ok(result.Data);
            }
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customers"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customers customers)
        {
            _logger.LogInformation("اجرای متد UpdateCustomer");
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                _logger.LogError("Model not valid");
                return BadRequest(string.Join(",", errors));
            }
            var result = _customer.UpdateCustomer(customers);
            if (result.IsSucceed)
            {
                _logger.LogWarning("با موفقیت اپدیت شد");
                return Ok(result.Data);
            }
            _logger.LogError("دستورات نامشخص");
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _logger.LogWarning("اجرای متد DeleteCustomer");
            var result = _customer.DeleteCustomer(id);
            if (result.IsSucceed)
            {

                if (result.Data != null)
                {
                    _logger.LogInformation("کاربر حذف شد");
                    return Ok(result.Data);
                }
                _logger.LogError("حذف با خطا مواجه شد ");
                return NotFound();
            }
            return BadRequest(string.Join(",", result.Errors));
        }


    }
}

