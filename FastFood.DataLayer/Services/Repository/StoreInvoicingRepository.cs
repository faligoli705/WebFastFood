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
    public class StoreInvoicingRepository : IStoreInvoicing
    {
        FastFoodContext _context;
        public StoreInvoicingRepository(FastFoodContext context)
        {
            _context = context;
        }

        public ServiceResult<StoreInvoicing> AddstoreInvoicing(string productId, int customerId)
        {
            
            var errors = new List<string>();
            if (errors.Any())
                return ServiceResult<StoreInvoicing>.Failed(errors);
            StoreInvoicing storeInvoicing = _context.StoreInvoicings.SingleOrDefault(s => s.CustomerId == 1 && s.StoreInvoicingStatus!=1);
            if (storeInvoicing == null)
            {
                storeInvoicing = new StoreInvoicing
                {
                    CustomerId = 1,//customerId,                    
                    //StoreInvoicingCreateDate = DateTime.Now,
                    StoreInvoicingStatus = 0,                    
                    IsDelete = false
                };
                _context.StoreInvoicings.Add(storeInvoicing);
                _context.StoreInvoicingDetails.Add(new StoreInvoicingDetails()
                {
                    InvoicingId = storeInvoicing.InvoicingDetailId,
                    ProductId = 1,//productId,
                    CurrentPrice = _context.Products.Find(productId).UnitPrice,
                    Qty = _context.Products.Find(productId).NumberOfOrders,
                    TotalAmount = 0,
                    LaborCustomerItem = 5000,
                    InvoicingDetailCreateDate = DateTime.Now,
                    InvoicingDetailStatus = 1,
                    IsDelete = false
                });
                var result = _context.SaveChanges();

                if (result > 0)
                    return ServiceResult<StoreInvoicing>.Succeed(storeInvoicing);

            }
            else
            {
                var details = _context.StoreInvoicingDetails.SingleOrDefault(s =>
                 s.InvoicingId == storeInvoicing.InvoicingDetailId
                 && s.ProductId == 1/*productId*/);
                if (details == null)
                {
                    _context.StoreInvoicingDetails.Add(new StoreInvoicingDetails()
                    {
                        InvoicingId = storeInvoicing.InvoicingDetailId,
                        ProductId = 1,//productId,
                        CurrentPrice = _context.Products.Find(productId).UnitPrice,
                        Qty = _context.Products.Find(productId).NumberOfOrders,
                        TotalAmount = 0,
                        LaborCustomerItem = 5000,
                        InvoicingDetailCreateDate = DateTime.Now,
                        InvoicingDetailStatus = 1,
                        IsDelete = false
                    });
                }
                else
                {
                    details.Qty += 1;
                    _context.Update(details);
                }
                
                var result = _context.SaveChanges();
                UpdateTotalAmount(storeInvoicing.InvoicingDetailId);
                if (result > 0)
                    return ServiceResult<StoreInvoicing>.Succeed(storeInvoicing);

            }


            return ServiceResult<StoreInvoicing>.Failed(new List<string> { "Data not inserted!!!" });

        }

        public void UpdateTotalAmount(int productId)
        {
            var product = _context.StoreInvoicingDetails.Find(productId);
            product.TotalAmount = _context.StoreInvoicingDetails.Where(s => s.ProductId == product.ProductId).Select(d => d.Qty * d.CurrentPrice).Sum();
            _context.Update(product);
            _context.SaveChanges();
        }

        public ServiceResult<StoreInvoicing> DeletestoreInvoicing(int id)
        {
            var errors = new List<string>();
            if (id < 0)
                errors.Add("Nothing found or not selected");

            if (_context.StoreInvoicings.Any(x => x.InvoicingDetailId == id && x.IsDelete != false))
                errors.Add("It has already been deleted");

            var storeInvoicing = _context.StoreInvoicings.Find(id);

            if (storeInvoicing == null)
                errors.Add("Nothing found ");
            if (errors.Any())
                return ServiceResult<StoreInvoicing>.Failed(errors);

            var result = _context.SaveChanges();
            if (result > 0)
            {
                storeInvoicing.StoreInvoicingDeleteDate = DateTime.Now;
                storeInvoicing.IsDelete = true;
            }
            if (result > 0)
                return ServiceResult<StoreInvoicing>.Succeed(storeInvoicing);
            return ServiceResult<StoreInvoicing>.Failed(new List<string> { "Data not found or Already deleted" });

        }

        public ServiceResult<StoreInvoicing> GetstoreInvoicingById(int id)
        {
            var errors = new List<string>();
            if (id == 0)
                errors.Add("The id is empty");

            var storeInvoicing = _context.StoreInvoicings.Find(id);
            storeInvoicing.IsDelete = true;
            if (errors.Any())
                return ServiceResult<StoreInvoicing>.Failed(errors);

            if (storeInvoicing != null)
                return ServiceResult<StoreInvoicing>.Succeed(storeInvoicing);
            return ServiceResult<StoreInvoicing>.Failed(new List<string> { "Nothing found" });

        }

        public ServiceResult<IEnumerable<StoreInvoicingDto>> ListstoreInvoicing()
        {
            var result = _context.Customers.Where(x => !x.IsDelete)
                .Select(x => new StoreInvoicingDto
                {
                    CustomerId = x.Id
                });

            return ServiceResult<IEnumerable<StoreInvoicingDto>>.Succeed(result);

        }

        public ServiceResult<StoreInvoicing> UpdatestoreInvoicing(StoreInvoicing storeInvoicing)
        {
            var errors = new List<string>();
            if (_context.StoreInvoicings.Any(x => x.Id == storeInvoicing.Id))
            {
                storeInvoicing.IsDelete = true;
                storeInvoicing.StoreInvoicingUpdateDate = DateTime.Now;
                // errors.Add("Mobile is duplicate");
            }

            if (errors.Any())
                return ServiceResult<StoreInvoicing>.Failed(errors);
            _context.Add(storeInvoicing);
            // _context.Entry(storeInvoicing).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
                return ServiceResult<StoreInvoicing>.Succeed(storeInvoicing);
            return ServiceResult<StoreInvoicing>.Failed(new List<string> { "Data not inserted" });

        }
    }
}
