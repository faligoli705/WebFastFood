using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebFastFood.Models;
using WebFastFood.Services.Contracts;

namespace WebFastFood.Services.Repository
{
    public class CustomerRepository : ICustomer
    {
        string apiUrl = "http://localhost:64467/api/customer";
        HttpClient _client;
        public CustomerRepository()
        {
            _client = new HttpClient();

        }
        public List<CustomersDto> GetAllCustomer(string token,string mobile)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = _client.GetStringAsync(apiUrl).Result;
            List<CustomersDto> list = JsonConvert.DeserializeObject<List<CustomersDto>>(result);
            return list;
        }

        public CustomersDto GetCustomerById(int customerId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + customerId).Result;
            CustomersDto customer = JsonConvert.DeserializeObject<CustomersDto>(result);
            return customer;
        }

        public bool AddCustomer(CustomersDto customersDto, bool res)
        {
            string jsonCustomer = JsonConvert.SerializeObject(customersDto);
            StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
            var result = _client.PostAsync(apiUrl, content).Result;
            var isSuccessStatusCode = result.IsSuccessStatusCode;
            res = isSuccessStatusCode;
            return res;
            
        }
        public void UpdateCustomer(CustomersDto customersDto)
        {

            string jsonCustomer = JsonConvert.SerializeObject(customersDto);
            StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
            var result = _client.PutAsync(apiUrl + "/" + customersDto.CustomerId, content).Result;
        }
        public void DeleteCustomer(int customerId)
        {
            var resuslt = _client.DeleteAsync(apiUrl + "/" + customerId).Result;
        }



    }

}
