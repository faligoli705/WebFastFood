using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
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
        ILogger<AuthenRepository> _logger;
        public AuthenRepository(FastFoodContext context, IMemoryCache cache,ILogger<AuthenRepository> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public Customers ListcustomersLogin(string mobile, int passwordCustomer)
        {
            _logger.LogError("ارتباط با جدول customer");
            return _context.Customers.Where(x => !x.IsDelete
                 && x.Mobile == mobile
                && x.PasswordCustomer == passwordCustomer
                ).SingleOrDefault();

        }
    }
}
