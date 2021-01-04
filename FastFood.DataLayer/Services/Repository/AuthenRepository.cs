using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.DataLayer.Services.Repository
{
    public class AuthenRepository : IAuthen
    {
        FastFoodContext _context;
        IMemoryCache _cache;
        public AuthenRepository(FastFoodContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public Customers ListcustomersLogin(string mobile, int passwordCustomer)
        {
            return _context.Customers.Where(x => !x.IsDelete
                 && x.Mobile == mobile
                && x.PasswordCustomer == passwordCustomer
                ).SingleOrDefault();
        }
    }
}
