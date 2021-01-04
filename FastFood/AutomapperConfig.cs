using AutoMapper;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood
{
    /// <summary>
    /// 
    /// </summary>
    public class AutomapperConfig : Profile
    {/// <summary>
    /// 
    /// </summary>
        public void Init()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Customers, CustomersDto>();
            CreateMap<Products, ProductsDto>();
            CreateMap<StoreInvoicing, StoreInvoicingDto>();
            CreateMap<StoreInvoicingDetails, StoreInvoicingDetailsDto>();

        }
    }
}
