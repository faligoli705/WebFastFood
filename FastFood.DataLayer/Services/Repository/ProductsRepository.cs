using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.DataLayer.Services.Repository
{
    public class ProductsRepository : IProduct
    {
        private readonly FastFoodContext _context;

        public ProductsRepository(FastFoodContext context)
        {
            this._context = context;
        }
        public ServiceResult<Products> AddProduct(Products product)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(product.ProductName))
                errors.Add("Name is Null");

            if (_context.Products.Any(a => a.ProductName == product.ProductName))
                errors.Add("Name Food is dupplicate");

            if (errors.Any())
                return ServiceResult<Products>.Failed(errors);


            _context.Products.Add(product);
            var result = _context.SaveChanges();

            if (result > 0)
                return ServiceResult<Products>.Succeed(product);
            return ServiceResult<Products>.Failed(new List<string> { "Data not inserted!!!" });
        }

        public ServiceResult<Products> AddSubmitOrder(Products product,int customerId)
        {
            StoreInvoicingDetails storeInvoicingDetails = new StoreInvoicingDetails();
            StoreInvoicing storeInvoicing = new StoreInvoicing();
            storeInvoicingDetails.ProductId = product.Id;
            storeInvoicingDetails.CurrentPrice = product.UnitPrice;
            storeInvoicingDetails.Qty = product.NumberOfOrders;
            storeInvoicingDetails.InvoicingDetailCreateDate = DateTime.Now;
            storeInvoicingDetails.InvoicingDetailStatus = 1;//sabte sefaresh

            storeInvoicing.CustomerId = customerId;
            storeInvoicing.StoreInvoicingCreateDate = DateTime.Now;
            storeInvoicing.InvoicingDetailId = storeInvoicingDetails.Id;
            _context.StoreInvoicingDetails.Add(storeInvoicingDetails);
            _context.StoreInvoicings.Add(storeInvoicing);


            var result = _context.SaveChanges();
            if (result > 0)
                return ServiceResult<Products>.Succeed(product);
            return ServiceResult<Products>.Failed(new List<string> { "Data not inserted!!!" });
        }
        public ServiceResult<Products> DeleteProduct(int id)
        {
            var errors = new List<string>();
            if (id < 0)
                errors.Add("Nothing found or not selected");

            if (_context.Products.Any(x => x.Id == id && x.IsDelete != false))
                errors.Add("It has already been deleted");

            var product = _context.Products.Find(id);

            if (product == null)
                errors.Add("Nothing found ");
            if (errors.Any())
                return ServiceResult<Products>.Failed(errors);

            var result = _context.SaveChanges();
            if (result > 0)
            {
                product.ProductDeleteDate = DateTime.Now;
                product.IsDelete = true;
            }
            if (result > 0)
                return ServiceResult<Products>.Succeed(product);
            return ServiceResult<Products>.Failed(new List<string> { "Data not found or Already deleted" });

        }

        public ServiceResult<Products> GetProductById(int id)
        {
            var errors = new List<string>();
            if (id == 0)
                errors.Add("The id is empty");

            var product = _context.Products.Find(id);
            product.IsDelete = true;
            if (errors.Any())
                return ServiceResult<Products>.Failed(errors);

            if (product != null)
                return ServiceResult<Products>.Succeed(product);
            return ServiceResult<Products>.Failed(new List<string> { "Nothing found" });

        }

        public ServiceResult<IEnumerable<ProductsDto>> ListProduct()
        {
            var result = _context.Products.Where(x => !x.IsDelete)
               .Select(x => new ProductsDto
               {
                   Id = x.Id,
                   ProductName = x.ProductName,
                   CategoryId = x.CategoryId,
                   UnitPrice = x.UnitPrice,
                   NumberOfOrders=x.NumberOfOrders,
                 //  ProductPreparationTime = (DateTime)x.ProductPreparationTime,
                   // ProductCreateDate = (DateTime)x.ProductCreateDate,
                   // ProductCreateTime = x.ProductCreateTime,
                   //ProductUpdateDate = x.ProductUpdateDate,
                  // ProductPicUrl = x.ProductPicUrl,
                   Status = x.Status
               });

            return ServiceResult<IEnumerable<ProductsDto>>.Succeed(result);
        }

        public ServiceResult<Products> UpdateProduct(Products product)
        {
            var errors = new List<string>();

            if (errors.Any())
                return ServiceResult<Products>.Failed(errors);
            _context.Entry(product).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
                return ServiceResult<Products>.Succeed(product);
            return ServiceResult<Products>.Failed(new List<string> { "Data not inserted" });

        }
    }
}
