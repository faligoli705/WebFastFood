using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DataLayer.Model
{
    public class Products
    {
        [Key]
        public Int32 ProductID { get; set; }
        [MaxLength(50)]
        public string ProductName { get; set; }
        public Int32 CategoryId { get; set; }
        public int NumberOfOrders { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ProductPreparationTime { get; set; }
        public DateTime ProductCreateDate { get; set; }
        //public DateTime ProductCreateTime { get; set; }
        public DateTime ProductUpdateDate { get; set; }
        //public DateTime ProductUpdateTime { get; set; }
        public DateTime ProductDeleteDate { get; set; }
        //public DateTime ProductDeleteTime { get; set; }
        public string ProductPicUrl { get; set; }
        public int Status { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
