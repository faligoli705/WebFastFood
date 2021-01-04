using FastFood;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FastFoodTest
{
    [TestClass]
    public class CustomerTest
    {
        HttpClient _client;
        public CustomerTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public void CustomerList()
        { 
            var request = new HttpRequestMessage(new HttpMethod("Get"), "/api/Customer");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
            //Assert.AreEqual(request, response);
        }
    }
}
