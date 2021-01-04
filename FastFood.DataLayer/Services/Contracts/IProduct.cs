using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataLayer.Services.Contracts
{
    public interface IProduct
    {
        ServiceResult<Products> AddProduct(Products product);
        ServiceResult<Products> UpdateProduct(Products product);
        ServiceResult<Products> DeleteProduct(int id);
        ServiceResult<Products> GetProductById(int id);
        ServiceResult<Products> AddSubmitOrder(Products product, int customerId);
        ServiceResult<IEnumerable<ProductsDto>> ListProduct();
    }
}
