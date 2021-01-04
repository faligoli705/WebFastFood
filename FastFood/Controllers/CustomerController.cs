using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public CustomerController(ICustomer customer)
        {
            this._customer = customer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CustomerList()
        {
            string mob= User.FindFirstValue(ClaimTypes.Name);
            var result = _customer.Listcustomers(mob);
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
        public IActionResult CustomerById(int id)
        {
            var result = _customer.GetCustomerById(id);
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
        /// <param name="customers"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCustomer(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
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
                return Ok(result.Data);
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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _customer.UpdateCustomer(customers);
            if (result.IsSucceed)
                return Ok(result.Data);
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
            var result = _customer.DeleteCustomer(id);
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

