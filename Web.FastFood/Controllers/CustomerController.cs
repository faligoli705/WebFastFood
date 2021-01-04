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
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        public IActionResult Index()
        {
            string mob = User.Identity.Name;
            string token = User.FindFirst("AccessToken").Value;
            return View(_customer.GetAllCustomer(token, mob));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomersDto customers, bool res)
        {
            _customer.AddCustomer(customers, res);
            if (res == false)
                return BadRequest("Mobile is Duplicate");
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _customer.GetCustomerById(id);
            return View(customer);
        }
        [HttpPut]

        public IActionResult Edit(CustomersDto customersDto)
        {
            _customer.UpdateCustomer(customersDto);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            _customer.DeleteCustomer(id);
            return RedirectToAction("Index");

        }

    }

}
