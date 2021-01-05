using Common.Exceptions;
using Microsoft.Extensions.Logging;
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
        ILogger<CustomerRepository> _logger;
        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _client = new HttpClient();
            _logger = logger;

        }
        public List<CustomersDto> GetAllCustomer(string token, string mobile)
        {
            try
            {
                _logger.LogWarning("اجرای متد گرفتن همه کاستومرها");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = _client.GetStringAsync(apiUrl).Result;
                List<CustomersDto> list = JsonConvert.DeserializeObject<List<CustomersDto>>(result);
                return list;
            }
            catch (Exception)
            {

                throw new BadRequestException("کاستومر با خطا مواجه شد");

            }
        }

        public CustomersDto GetCustomerById(int customerId)
        {
            try
            {
                _logger.LogWarning("گرفتن کاستومر بر اساس ایدی");
                var result = _client.GetStringAsync(apiUrl + "/" + customerId).Result;
                CustomersDto customer = JsonConvert.DeserializeObject<CustomersDto>(result);
                return customer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddCustomer(CustomersDto customersDto, bool res)
        {
            try
            {
                _logger.LogWarning("اضافه کردن کاستومر جدید");
                string jsonCustomer = JsonConvert.SerializeObject(customersDto);
                StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
                var result = _client.PostAsync(apiUrl, content).Result;
                var isSuccessStatusCode = result.IsSuccessStatusCode;
                res = isSuccessStatusCode;
                return res;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void UpdateCustomer(CustomersDto customersDto)
        {
            try
            {
                _logger.LogWarning("بروزرسانی کاستومر");
                string jsonCustomer = JsonConvert.SerializeObject(customersDto);
                StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
                var result = _client.PutAsync(apiUrl + "/" + customersDto.CustomerId, content).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteCustomer(int customerId)
        {
            try
            {
                _logger.LogWarning("حذف کاستومر");
                var resuslt = _client.DeleteAsync(apiUrl + "/" + customerId).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }

}
