using Common.Exceptions;
using FastFood.DataLayer.Services;
using FastFood.DomainClass.Domain.Entities;
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
    public class CategoryRepository : ICategory
    {
        string apiUrl = "http://localhost:64467/api/Category";
        HttpClient _client;
        ILogger<CategoryRepository> _loggr;
        public CategoryRepository(ILogger<CategoryRepository> loggr)
        {
            _client = new HttpClient();
            _loggr = loggr;

        }

        public void AddCategory(CategoryDto categoryDto, bool res)
        {
            try
            {
                _loggr.LogWarning("اجرای متد اضافه کردن دسته بندی");
                string jsonProduct = JsonConvert.SerializeObject(categoryDto);
                StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
                var result =  _client.PostAsync(apiUrl, content).Result;
                var isSuccessStatusCode = result.IsSuccessStatusCode;
                res = isSuccessStatusCode;
                if (res == false)
                {
                    _loggr.LogError("اضافه کردن دسته بندی با خطا مواجه شد");
                    throw new BadRequestException("اضافه کردن دسته بندی با خطا مواجه شد");
                    res = isSuccessStatusCode;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            try
            {
                _loggr.LogWarning("اجرای متد حذف دسته بندی");
                var resuslt = _client.DeleteAsync(apiUrl + "/" + categoryId).Result;
                _loggr.LogInformation("دسته بندی با موفقیت حذف شد");
            }
            catch (Exception)
            {

                throw new BadRequestException("حذف با خطا مواجه شد");

            }
        }

        public List<CategoryDto> GetAllCategory(string token, string mob)
        {
            try
            {
                _loggr.LogWarning("اجرای متد گرفتن همه دسته بندی ها");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = _client.GetStringAsync(apiUrl).Result;
                List<CategoryDto> list = JsonConvert.DeserializeObject<List<CategoryDto>>(result);
                _loggr.LogInformation("با موفقیت دسته بندی ها نمایش داده شد");
                return list;
            }
            catch (Exception)
            {

                throw new BadRequestException("دسته بندی با خطا مواجه شد");

            }
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            try
            {
                _loggr.LogWarning("ایجاد متد دسته بندی با ایدی");
                var result = _client.GetStringAsync(apiUrl + "/" + categoryId).Result;
                CategoryDto category = JsonConvert.DeserializeObject<CategoryDto>(result);
                return category;
            }
            catch (Exception)
            {

                throw new BadRequestException("دسته بندی ایدی با خطا مواجه شد");

            }
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            try
            {
                _loggr.LogWarning("اجرای متد اپذیت دسته بندی");
                string jsonCategory = JsonConvert.SerializeObject(categoryDto);
                StringContent content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
                var result = _client.PutAsync(apiUrl + "/" + categoryDto.CategoryID, content).Result;
            }
            catch (Exception)
            {

                throw new BadRequestException("بروزرسانی دسته بندی با خطا مواجه شد");

            }
        }
    }
}

