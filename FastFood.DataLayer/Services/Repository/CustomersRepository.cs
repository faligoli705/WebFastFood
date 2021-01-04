using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.DataLayer.Services.Repository
{
    public class CustomersRepository : ICustomer
    {
        FastFoodContext _context;       
        IMemoryCache _cache;
        public CustomersRepository(FastFoodContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public ServiceResult<Customers> GetCustomerById(int id)
        {
            var errors = new List<string>();
            if (id == 0)
                errors.Add("The id is empty");
            var cacheCustomer = _cache.Get<Customers>(id);
            if (cacheCustomer != null)
            {
                return ServiceResult<Customers>.Succeed(cacheCustomer);
            }
            else
            {
                var customer = _context.Customers.Find(id);
                customer.IsDelete = true;
                var cacheOption = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _cache.Set(customer.CustomerId, customer, cacheOption);
                if (customer != null)
                    return ServiceResult<Customers>.Succeed(customer);
                if (errors.Any())
                    return ServiceResult<Customers>.Failed(errors);
                return ServiceResult<Customers>.Failed(new List<string> { "Nothing found" });
            }

        }

        public ServiceResult<IEnumerable<CustomersDto>> Listcustomers(string mob)
        {
            
            var result = _context.Customers.Where(x => !x.IsDelete )
                .Select(x => new CustomersDto
                {
                    CustomerId = x.CustomerId,
                    FName = x.FName,
                    LName = x.LName,
                    Mobile = x.Mobile,
                    Address = x.Address,
                });

            return ServiceResult<IEnumerable<CustomersDto>>.Succeed(result);
        }
        public ServiceResult<Customers> AddCustomer(Customers customers)
        {

            var errors = new List<string>();
            if (string.IsNullOrEmpty(customers.FName))
                errors.Add("Name is Null");

            if (_context.Customers.Any(a => a.Mobile == customers.Mobile))
                errors.Add("Mobile is dupplicate");

            if (errors.Any())
                return ServiceResult<Customers>.Failed(errors);

            customers.CustomerCreateDate = DateTime.Now;
            customers.IsDelete = false;
            _context.Customers.Add(customers);
            var result = _context.SaveChanges();

            if (result > 0)
                return ServiceResult<Customers>.Succeed(customers);
            return ServiceResult<Customers>.Failed(new List<string> { "Data not inserted!!!" });
        }

        public ServiceResult<Customers> DeleteCustomer(int id)
        {
            var errors = new List<string>();
            if (id < 0)
                errors.Add("Nothing found or not selected");

            if (_context.Customers.Any(x => x.CustomerId == id && x.IsDelete != false))
                errors.Add("It has already been deleted");

            var customer = _context.Customers.Find(id);

            if (customer == null)
                errors.Add("Nothing found ");
            if (errors.Any())
                return ServiceResult<Customers>.Failed(errors);
            customer.CustomerDeleteDate = DateTime.Now;
            customer.IsDelete = true;
            _context.Entry(customer).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
                return ServiceResult<Customers>.Succeed(customer);
            return ServiceResult<Customers>.Failed(new List<string> { "Data not found or Already deleted" });
        }



        public ServiceResult<Customers> UpdateCustomer(Customers customers)
        {
            var errors = new List<string>();
            if (_context.Customers.Any(x => x.CustomerId != customers.CustomerId && x.Mobile == customers.Mobile))
                errors.Add("Mobile is duplicate");

            if (errors.Any())
                return ServiceResult<Customers>.Failed(errors);
            _context.Entry(customers).State = EntityState.Modified;
            customers.IsDelete = true;
            customers.CustomerUpdateDate = DateTime.Now;
            //_context.Add(customers);
            var result = _context.SaveChanges();
            if (result > 0)
                return ServiceResult<Customers>.Succeed(customers);
            return ServiceResult<Customers>.Failed(new List<string> { "Data not inserted" });
        }
    }
}
