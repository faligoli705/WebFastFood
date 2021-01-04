using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataLayer.Services.Contracts
{
    public interface IStoreInvoicing
    {
        ServiceResult<StoreInvoicing> AddstoreInvoicing(string productId, int customerId);
        ServiceResult<StoreInvoicing> UpdatestoreInvoicing(StoreInvoicing storeInvoicing);
        ServiceResult<StoreInvoicing> DeletestoreInvoicing(int id);
        ServiceResult<StoreInvoicing> GetstoreInvoicingById(int id);
        ServiceResult<IEnumerable<StoreInvoicingDto>> ListstoreInvoicing();
    }
}
