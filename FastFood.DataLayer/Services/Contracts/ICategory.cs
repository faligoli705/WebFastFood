using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataLayer.Services.Contracts
{
    public interface ICategory
    {
        ServiceResult<Category> AddCategory(Category type);
        ServiceResult<Category> UpdateCategory(Category type);
        ServiceResult<Category> DeleteCategory(int id);
        ServiceResult<Category> GetCategoryById(int id);
        ServiceResult<IEnumerable<CategoryDto>> ListCategory();
    }
}
