using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Services.Contracts;
using WebFastFood.Services.Repository;

namespace WebFastFood.Controllers
{
    public class StoreInvoicingDetailsController : Controller
    {
        IStoreInvoicingDetails _storeInvoicingDetails;
        public StoreInvoicingDetailsController(IStoreInvoicingDetails storeInvoicingDetail)
        {
            _storeInvoicingDetails = storeInvoicingDetail;
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
