using FastFood.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebFastFood.Services.Contracts;

namespace WebFastFood.Services.Repository
{
    public class StoreInvoicingDetailsRepository : IStoreInvoicingDetails
    {
        string apiUrl = "http://localhost:64467/api/customer";
        HttpClient _client;
        ILogger<StoreInvoicingDetailsRepository> _logge;
        public StoreInvoicingDetailsRepository(ILogger<StoreInvoicingDetailsRepository> logger)
        {
            _client = new HttpClient();
            _logge = logger;

        }
        public List<ShowCartViewModel> GetAllStoreInvoicingDetails(string token, string mobile)
        {
            try
            {
                _logge.LogWarning("نمایش لیست محصولات خریداری شده");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = _client.GetStringAsync(apiUrl).Result;
                List<ShowCartViewModel> list = JsonConvert.DeserializeObject<List<ShowCartViewModel>>(result);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
