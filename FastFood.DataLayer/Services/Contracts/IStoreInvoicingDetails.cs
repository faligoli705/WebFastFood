using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataLayer.Services.Contracts
{
    public interface IStoreInvoicingDetails
    {
        ServiceResult<StoreInvoicingDetails> AddstoreInvoicingDetails(StoreInvoicingDetails storeInvoicingDetails);
        ServiceResult<StoreInvoicingDetails> UpdatestoreInvoicingDetails(StoreInvoicingDetails storeInvoicingDetails);
        ServiceResult<StoreInvoicingDetails> DeletestoreInvoicingDetails(int id);
        ServiceResult<StoreInvoicingDetails> GetstoreInvoicingDetailsById(int id);
        ServiceResult<IEnumerable<StoreInvoicingDetailsDto>> ListstoreInvoicingDetails();
    }
}
