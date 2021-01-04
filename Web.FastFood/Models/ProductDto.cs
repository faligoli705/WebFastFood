using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Models
{
    public class ProductDto
    { 
            public int ProductID { get; set; }
            [MaxLength(50)]
            public string ProductName { get; set; }
            public int CategoryId { get; set; }
            public int NumberOfOrders { get; set; }
            public decimal UnitPrice { get; set; }
            public DateTime? ProductPreparationTime { get; set; }
            public DateTime? ProductCreateDate { get; set; }
            //public DateTime ProductCreateTime { get; set; }
            public DateTime? ProductUpdateDate { get; set; }
            //public DateTime ProductUpdateTime { get; set; }
            public DateTime? ProductDeleteDate { get; set; }
            //public DateTime ProductDeleteTime { get; set; }
            public string ProductPicUrl { get; set; }
            public int Status { get; set; }
            public bool IsDelete { get; set; }
        
    }
  
}
