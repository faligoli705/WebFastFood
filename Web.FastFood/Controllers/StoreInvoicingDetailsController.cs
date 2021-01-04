using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Services.Repository;

namespace WebFastFood.Controllers
{
    public class StoreInvoicingDetailsController : Controller
    {
        StoreInvoicingDetailsRepository _storeInvoicingDetails;
        public StoreInvoicingDetailsController()
        {
            _storeInvoicingDetails = new StoreInvoicingDetailsRepository();
        }

        public IActionResult StoreInvoicingDetails()
        {
            return View();
        }

        //public IActionResult Invoke()
        //{
        //    string mob = User.Identity.Name;
        //    string token = User.FindFirst("AccessToken").Value;
        //    return View(_storeInvoicingDetails(token, mob));
        //}
    }
}
