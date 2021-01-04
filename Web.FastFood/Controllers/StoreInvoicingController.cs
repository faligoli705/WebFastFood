using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebFastFood.Services.Repository;

namespace WebFastFood.Controllers
{
    [Authorize]
    public class StoreInvoicingController : Controller
    {
        StoreInvoicingRepository _customer;
        public StoreInvoicingController()
        {
            _customer = new StoreInvoicingRepository();
        }
        public IActionResult AddToStoreInvoicing(string id)
        {
            
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id1 = Convert.ToInt32(currentUserId);
            _customer.AddStoreInvoicing(id, id1);
            return RedirectToAction("Index");
        }
    }
}
