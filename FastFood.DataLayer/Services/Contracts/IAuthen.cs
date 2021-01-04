using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataLayer.Services.Contracts
{
    public interface IAuthen
    {
        Customers ListcustomersLogin(string mobile, int passwordCustomer);

    }
}
