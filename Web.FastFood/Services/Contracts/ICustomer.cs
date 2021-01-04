using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Models;

namespace WebFastFood.Services.Contracts
{
    public interface ICustomer
    {
        List<CustomersDto> GetAllCustomer(string token, string mob);
        CustomersDto GetCustomerById(int customerId);
        bool AddCustomer(CustomersDto customersDto, bool res);
        void UpdateCustomer(CustomersDto customersDto);
        void DeleteCustomer(int customerId);

    }
}
