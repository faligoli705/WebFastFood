using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebFastFood.Services.Contracts;

namespace WebFastFood.Controllers
{
    [Authorize]
    public class StoreInvoicingController : Controller
    {
        IStoreInvoicing _storeInvoicing;
        public StoreInvoicingController(IStoreInvoicing storeInvoicing)
        {
            _storeInvoicing = storeInvoicing;
        }
        public IActionResult AddToStoreInvoicing(string id)
        {
            
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id1 = Convert.ToInt32(currentUserId);
            _storeInvoicing.AddStoreInvoicing(id, id1);
            return RedirectToAction("Index");
        }
    }
}
