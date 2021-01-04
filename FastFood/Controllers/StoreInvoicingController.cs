using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Entities;
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
    [Route("api/[Controller]")]
    [ApiController]
    public class StoreInvoicingController : Controller
    {
        private readonly IStoreInvoicing _storeInvoicing;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeInvoicing"></param>
        public StoreInvoicingController(IStoreInvoicing storeInvoicing)
        {
            this._storeInvoicing = storeInvoicing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListstoreInvoicing()
        {
            var result = _storeInvoicing.ListstoreInvoicing();
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
        public IActionResult StoreInvoicingById(int id)
        {
            var result = _storeInvoicing.GetstoreInvoicingById(id);
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
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddStoreInvoicing(string productId, int customerId)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var name = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _storeInvoicing.AddstoreInvoicing(productId, customerId);

            //CustomerId = storeInvoicings.CustomerId,
            //StoreInvoicingStatus = storeInvoicings.StoreInvoicingStatus


            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storeInvoicings"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateStoreInvoicing(int id, StoreInvoicing storeInvoicings)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _storeInvoicing.UpdatestoreInvoicing(storeInvoicings);
            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storeInvoicings"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteStoreInvoicing(int id, StoreInvoicing storeInvoicings)
        {
            var result = _storeInvoicing.DeletestoreInvoicing(id);
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
