using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebFastFood.Models;
using WebFastFood.Services.Contracts;
namespace WebFastFood.Services.Repository
{
    [Authorize]
    public class ProductRepository : IProduct
    {
        string apiUrl = "http://localhost:64467/api/Product";
        HttpClient _client;

        public ProductRepository()
        {
            _client = new HttpClient();
        }

        public void AddProduct(ProductDto productDto, bool res)
        {
            string jsonProduct = JsonConvert.SerializeObject(productDto);
            StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var result = _client.PostAsync(apiUrl, content).Result;
            var isSuccessStatusCode = result.IsSuccessStatusCode;
            res = isSuccessStatusCode;
            if (res == false)
                res = isSuccessStatusCode;
        }
        public bool  AddSubmitOrder(ProductDto productDto, bool res)
        {
            string jsonProduct =  JsonConvert.SerializeObject(productDto);
            StringContent content =  new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var result =  _client.PostAsync(apiUrl, content).Result;
            var isSuccessStatusCode =  result.IsSuccessStatusCode;
            res =  isSuccessStatusCode;
            if (res == false)
                res =  isSuccessStatusCode;
            return  res;
        }

        public void DeleteProduct(int productId)
        {
            var resuslt = _client.DeleteAsync(apiUrl + "/" + productId).Result;
        }

        public List<ProductDto> GetAllProduct(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = _client.GetStringAsync(apiUrl).Result;
            List<ProductDto> list = JsonConvert.DeserializeObject<List<ProductDto>>(result);
            return list;
        }

        public ProductDto GetProductById(int productId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + productId).Result;
            ProductDto product = JsonConvert.DeserializeObject<ProductDto>(result);
            return product;
        }

        public void UpdateProduct(ProductDto productDto)
        {
            string jsonProduct = JsonConvert.SerializeObject(productDto);
            StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var result = _client.PutAsync(apiUrl + "/" + productDto.ProductID, content).Result;
            throw new NotImplementedException();
        }
    }
}
