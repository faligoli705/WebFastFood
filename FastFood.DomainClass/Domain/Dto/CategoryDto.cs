using FastFood.DomainClass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DomainClass.Domain.Dto
{
    public class CategoryDto : BaseEntity<Int32>
    {
        //public Int32 CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CategoryCreateDate { get; set; }
        public DateTime? CategoryUpdateDate { get; set; }
        public DateTime? CategoryDeleteDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
