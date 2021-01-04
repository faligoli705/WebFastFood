using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataLayer.Services.Contracts
{
    public interface ICustomer
    {
        ServiceResult<Customers> AddCustomer(Customers customers);
        ServiceResult<Customers> UpdateCustomer(Customers customers);
        ServiceResult<Customers> DeleteCustomer(int id);
        ServiceResult<Customers> GetCustomerById(int id);
        ServiceResult<IEnumerable<CustomersDto>> Listcustomers(string mob);


    }
}
