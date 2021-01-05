using Microsoft.Extensions.Logging;
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
        ILogger<ProductRepository> _logger;

        public ProductRepository(ILogger<ProductRepository> logger)
        {
            _client = new HttpClient();
            _logger = logger;
        }

        public void AddProduct(ProductDto productDto, bool res)
        {
            try
            {
                _logger.LogWarning("اضافه کردن محصول");
                string jsonProduct = JsonConvert.SerializeObject(productDto);
                StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
                var result = _client.PostAsync(apiUrl, content).Result;
                var isSuccessStatusCode = result.IsSuccessStatusCode;
                res = isSuccessStatusCode;
                if (res == false)
                    res = isSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool AddSubmitOrder(ProductDto productDto, bool res)
        {
            try
            {
                _logger.LogWarning("اضافه کردن جمع بندی محصولات");
                string jsonProduct = JsonConvert.SerializeObject(productDto);
                StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
                var result = _client.PostAsync(apiUrl, content).Result;
                var isSuccessStatusCode = result.IsSuccessStatusCode;
                res = isSuccessStatusCode;
                if (res == false)
                    res = isSuccessStatusCode;
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProduct(int Id)
        {
            try
            {
                _logger.LogWarning("اجرای متد حذف محصول");
                var resuslt = _client.DeleteAsync(apiUrl + "/" + Id).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductDto> GetAllProduct(string token)
        {
            try
            {
                _logger.LogWarning("گرفتن همه محصولات");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = _client.GetStringAsync(apiUrl).Result;
                List<ProductDto> list = JsonConvert.DeserializeObject<List<ProductDto>>(result);
                return list;
            }
            catch
            {
                throw;
            }
        }

        public ProductDto GetProductById(int Id)
        {
            try
            {
                _logger.LogWarning("گرفتن محصول براساس ایدی");
                var result = _client.GetStringAsync(apiUrl + "/" + Id).Result;
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(result);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateProduct(ProductDto productDto)
        {
            try
            {
                _logger.LogWarning("بروزرسانی محصول");
                string jsonProduct = JsonConvert.SerializeObject(productDto);
                StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
                var result = _client.PutAsync(apiUrl + "/" + productDto.Id, content).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
