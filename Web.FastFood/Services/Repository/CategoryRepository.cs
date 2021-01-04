using FastFood.DataLayer.Services;
using FastFood.DomainClass.Domain.Entities;
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
    public class CategoryRepository : ICategory
    {
        string apiUrl = "http://localhost:64467/api/Category";
        HttpClient _client;
        public CategoryRepository()
        {
            _client = new HttpClient();

        }

        public void AddCategory(CategoryDto categoryDto, bool res)
        {
            string jsonProduct = JsonConvert.SerializeObject(categoryDto);
            StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var result = _client.PostAsync(apiUrl, content).Result;
            var isSuccessStatusCode = result.IsSuccessStatusCode;
            res = isSuccessStatusCode;
            if (res == false)
                res = isSuccessStatusCode;
        }

        public void DeleteCategory(int categoryId)
        {
            var resuslt = _client.DeleteAsync(apiUrl + "/" + categoryId).Result;

        }

        public List<CategoryDto> GetAllCategory(string token, string mob)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = _client.GetStringAsync(apiUrl).Result;
            List<CategoryDto> list = JsonConvert.DeserializeObject<List<CategoryDto>>(result);
            return list;
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + categoryId).Result;
            CategoryDto category = JsonConvert.DeserializeObject<CategoryDto>(result);
            return category;
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {

            string jsonCategory = JsonConvert.SerializeObject(categoryDto);
            StringContent content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var result = _client.PutAsync(apiUrl + "/" + categoryDto.CategoryID, content).Result;
        }
    }
}
