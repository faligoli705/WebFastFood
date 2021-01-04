using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DomainClass.Domain.Dto
{
    public class ProductsDto
    {
        public Int32 ProductID { get; set; }
        public string ProductName { get; set; }
        public Int32 CategoryId { get; set; }
        public int NumberOfOrders { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? ProductCreateDate { get; set; }
        public DateTime? ProductUpdateDate { get; set; }
        public DateTime? ProductDeleteDate { get; set; }
        public string ProductPicUrl { get; set; }
        public int Status { get; set; }
        public bool IsDelete { get; set; }
    }
}

