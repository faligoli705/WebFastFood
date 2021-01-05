using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.DataLayer.Services.Repository
{
    public class StoreInvoicingDetailsRepository : IStoreInvoicingDetails
    {
        FastFoodContext _context;
        public StoreInvoicingDetailsRepository(FastFoodContext context)
        {
            _context = context;
        }
        public ServiceResult<StoreInvoicingDetails> AddstoreInvoicingDetails(StoreInvoicingDetails storeInvoicingDetails)
        {
            var errors = new List<string>();
            //if (string.IsNullOrEmpty(StoreInvoicingDetails.InvoicingId))
            //    errors.Add("Name is Null");

            //if (_context.Customers.Any(a => a.Mobile == storeInvoicingDetails.Mobile))
            //    errors.Add("Mobile is dupplicate");

            if (errors.Any())
                return ServiceResult<StoreInvoicingDetails>.Failed(errors);

            storeInvoicingDetails.InvoicingDetailCreateDate = DateTime.Now;
            storeInvoicingDetails.IsDelete = false;
            _context.StoreInvoicingDetails.Add(storeInvoicingDetails);
            var result = _context.SaveChanges();

            if (result > 0)
                return ServiceResult<StoreInvoicingDetails>.Succeed(storeInvoicingDetails);
            return ServiceResult<StoreInvoicingDetails>.Failed(new List<string> { "Data not inserted!!!" });

        }

        public ServiceResult<StoreInvoicingDetails> DeletestoreInvoicingDetails(int id)
        {
            var errors = new List<string>();
            if (id < 0)
                errors.Add("Nothing found or not selected");

            if (_context.StoreInvoicingDetails.Any(x => x.Id == id && x.IsDelete != false))
                errors.Add("It has already been deleted");

            var storeInvoicingDetails = _context.StoreInvoicingDetails.Find(id);

            if (storeInvoicingDetails == null)
                errors.Add("Nothing found ");
            if (errors.Any())
                return ServiceResult<StoreInvoicingDetails>.Failed(errors);

            var result = _context.SaveChanges();
            if (result > 0)
            {
                storeInvoicingDetails.InvoicingDetailDeleteDate = DateTime.Now;
                storeInvoicingDetails.IsDelete = true;
            }
            if (result > 0)
                return ServiceResult<StoreInvoicingDetails>.Succeed(storeInvoicingDetails);
            return ServiceResult<StoreInvoicingDetails>.Failed(new List<string> { "Data not found or Already deleted" });

        }

        public ServiceResult<StoreInvoicingDetails> GetstoreInvoicingDetailsById(int id)
        {
            var errors = new List<string>();
            if (id == 0)
                errors.Add("The id is empty");

            var storeInvoicingDetails = _context.StoreInvoicingDetails.Find(id);
            storeInvoicingDetails.IsDelete = true;
            if (errors.Any())
                return ServiceResult<StoreInvoicingDetails>.Failed(errors);

            if (storeInvoicingDetails != null)
                return ServiceResult<StoreInvoicingDetails>.Succeed(storeInvoicingDetails);
            return ServiceResult<StoreInvoicingDetails>.Failed(new List<string> { "Nothing found" });

        }

        public ServiceResult<IEnumerable<StoreInvoicingDetailsDto>> ListstoreInvoicingDetails()
        {
            var result = _context.StoreInvoicingDetails.Where(x => !x.IsDelete)
               .Select(x => new StoreInvoicingDetailsDto
               {
                   InvoicingId = x.InvoicingId,
                   ProductId = x.ProductId,
                   CurrentPrice = x.CurrentPrice,
                   Qty = x.Qty,
                   TotalAmount = x.TotalAmount,
               });

            return ServiceResult<IEnumerable<StoreInvoicingDetailsDto>>.Succeed(result);

        }

        public ServiceResult<StoreInvoicingDetails> UpdatestoreInvoicingDetails(StoreInvoicingDetails storeInvoicingDetails)
        {
            throw new NotImplementedException();
        }
    }
}
