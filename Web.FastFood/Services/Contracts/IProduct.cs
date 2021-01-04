using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Models;

namespace WebFastFood.Services.Contracts
{
   public interface IProduct
    {
        List<ProductDto> GetAllProduct(string token);
        ProductDto GetProductById(int productId);
        void AddProduct(ProductDto productDto, bool res);
        void UpdateProduct(ProductDto productDto);
        void DeleteProduct(int productId);
    }
}
