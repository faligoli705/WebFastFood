using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Models;

namespace WebFastFood.Services.Contracts
{
   public interface ICategory
    {
        List<CategoryDto> GetAllCategory(string token, string mob);
        CategoryDto GetCategoryById(int categoryId);
        void AddCategory(CategoryDto categoryDto, bool res);
        void UpdateCategory(CategoryDto categoryDto);
        void DeleteCategory(int categoryId);
    }
}
