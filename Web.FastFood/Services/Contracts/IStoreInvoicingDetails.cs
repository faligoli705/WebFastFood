using FastFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Services.Contracts
{
   public interface IStoreInvoicingDetails
    {
        List<ShowCartViewModel> GetAllStoreInvoicingDetails(string token, string mobile);

    }
}
