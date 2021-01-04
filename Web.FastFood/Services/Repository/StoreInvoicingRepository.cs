using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebFastFood.Models;
using WebFastFood.Services.Contracts;

namespace WebFastFood.Services.Repository
{
    public class StoreInvoicingRepository : IStoreInvoicing
    {
        string apiUrl = "http://localhost:64467/api/StoreInvoicing";
        HttpClient _client;
        ILogger<StoreInvoicingRepository> _logger;
        public StoreInvoicingRepository(ILogger<StoreInvoicingRepository> logger)
        {
            _client = new HttpClient();
            _logger = logger;

        }
        public void AddStoreInvoicing(string productId, int currentUserId)
        {
            try
            {
                _logger.LogWarning("اضافه کردن محصول به لیست خرید");
                var value = new
                {
                    productId = productId,
                    currentUserId = currentUserId
                };
                string jsonstoreInvoicing = JsonConvert.SerializeObject(value);
                StringContent content = new StringContent(jsonstoreInvoicing, Encoding.UTF8, "application/json");
                var result = _client.PostAsJsonAsync(apiUrl, content).Result;
                var isSuccessStatusCode = result.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
