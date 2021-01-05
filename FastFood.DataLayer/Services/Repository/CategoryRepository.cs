using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.DataLayer.Services.Repository
{
    public class CategoryRepository : ICategory
    {
        FastFoodContext _context;
        public CategoryRepository(FastFoodContext context)
        {
            _context = context;
        }
        public ServiceResult<Category> AddCategory(Category category)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(category.CategoryName))
                errors.Add("Name is Null");

            if (_context.Categories.Any(a => a.CategoryName == category.CategoryName))
                errors.Add("Mobile is dupplicate");

            if (errors.Any())
                return ServiceResult<Category>.Failed(errors);

            category.CategoryCreateDate = DateTime.Now;
            category.IsDelete = false;
            _context.Categories.Add(category);
            var result = _context.SaveChanges();

            if (result > 0)
                return ServiceResult<Category>.Succeed(category);
            return ServiceResult<Category>.Failed(new List<string> { "Data not inserted!!!" });
        }

        public ServiceResult<Category> DeleteCategory(int id)
        {
            var errors = new List<string>();
            if (id < 0)
                errors.Add("Nothing found or not selected");

            if (_context.Categories.Any(x => x.Id == id && x.IsDelete != false))
                errors.Add("It has already been deleted");

            var category = _context.Categories.Find(id);

            if (category == null)
                errors.Add("Nothing found ");
            if (errors.Any())
                return ServiceResult<Category>.Failed(errors);

            var result = _context.SaveChanges();
            if (result > 0)
            {
                category.CategoryDeleteDate = DateTime.Now;
                category.IsDelete = true;
            }
            if (result > 0)
                return ServiceResult<Category>.Succeed(category);
            return ServiceResult<Category>.Failed(new List<string> { "Data not found or Already deleted" });

        }

        public ServiceResult<Category> GetCategoryById(int id)
        {
            var errors = new List<string>();
            if (id == 0)
                errors.Add("The id is empty");

            var category = _context.Categories.Find(id);
            //  category.IsDelete = true;
            if (errors.Any())
                return ServiceResult<Category>.Failed(errors);

            if (category != null)
                return ServiceResult<Category>.Succeed(category);
            return ServiceResult<Category>.Failed(new List<string> { "Nothing found" });

        }

        public ServiceResult<IEnumerable<CategoryDto>> ListCategory()
        {
            var result = _context.Categories.Where(x => !x.IsDelete)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName
                });

            return ServiceResult<IEnumerable<CategoryDto>>.Succeed(result);

        }

        public ServiceResult<Category> UpdateCategory(Category category)
        {
            var errors = new List<string>();
            if (_context.Categories.Any(x => x.Id != category.Id && x.CategoryName == category.CategoryName))
                errors.Add("Name is duplicate");

            if (errors.Any())
                return ServiceResult<Category>.Failed(errors);
            category.CategoryUpdateDate = DateTime.Now;
            category.IsDelete = true;
            _context.Categories.Add(category);
            //_context.Entry(category).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
                return ServiceResult<Category>.Succeed(category);
            return ServiceResult<Category>.Failed(new List<string> { "Data not inserted" });

        }
    }
}

