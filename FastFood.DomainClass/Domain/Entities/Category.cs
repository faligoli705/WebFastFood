using FastFood.DomainClass.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DomainClass.Domain.Entities
{
    public class Category :BaseEntity
    {
        //[Key]
        //public Int32 CategoryID { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
        //public DateTime? CategoryCreateDate { get; set; }
        //public DateTime? CategoryUpdateDate { get; set; }
        //public DateTime? CategoryDeleteDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
