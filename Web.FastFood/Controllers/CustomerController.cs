using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebFastFood.Models;
using WebFastFood.Services.Contracts;

namespace WebFastFood.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ICustomer _customer;
        ILogger<CustomerController> _logger;

        public CustomerController(ICustomer customer, ILogger<CustomerController> logger)
        {
            _customer = customer;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                _logger.LogError("اجرای اکشن Index");
                string mob = User.Identity.Name;
                string token = User.FindFirst("AccessToken").Value;
                _logger.LogInformation("کاربر وارد شد");
                return View(_customer.GetAllCustomer(token, mob));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomersDto customers, bool res)
        {
            try { 
            _logger.LogInformation("اجرای متد Create کاستومر");
            _customer.AddCustomer(customers, res);
            if (res == false)
            {
                _logger.LogError("موبایل تکراری است");
                return BadRequest("Mobile is Duplicate");
            }
            _logger.LogInformation("کاربر ایجاد شد");
            return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                _logger.LogWarning("اجرای متد ویرایش کاربر");
                var customer = _customer.GetCustomerById(id);
                _logger.LogInformation("کاربر ویرایش شد");
                return View(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]

        public IActionResult Edit(CustomersDto customersDto)
        {
            try
            {
                _logger.LogWarning("اجرای متد ویرایش کاربر باcustomersDto ");
                _customer.UpdateCustomer(customersDto);
                _logger.LogInformation("با موفقیت ویرایش شد");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogWarning("اجرای متد حذف کاربر");
                _customer.DeleteCustomer(id);
                _logger.LogInformation("کاربر حذف شد");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

    }

}
