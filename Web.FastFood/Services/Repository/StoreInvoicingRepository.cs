﻿using Newtonsoft.Json;
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
        public StoreInvoicingRepository()
        {
            _client = new HttpClient();

        }
        public async Task AddCustomer(string productId, int currentUserId)
        {
            var d = new StoreInvoicingDto
            {
                CustomerId = currentUserId

            };
            //var value = new
            //{
            //    productId = productId,
            //    currentUserId = currentUserId
            //};
            // string queryString = "productId=" + productId + "&currentUserId=" + currentUserId;
            //formVars.Add("productId", "currentUserId");
            string jsonstoreInvoicing = JsonConvert.SerializeObject(d);
            StringContent content = new StringContent(jsonstoreInvoicing, Encoding.UTF8, "application/json");
            var result = _client.PostAsJsonAsync(apiUrl, content).Result;
            var isSuccessStatusCode = result.IsSuccessStatusCode;



        }
    }
}