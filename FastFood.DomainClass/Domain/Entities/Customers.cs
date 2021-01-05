using FastFood.DomainClass.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DomainClass.Domain.Entities
{
    public class Customers :BaseEntity<Int32>
    {
        //[Key]
        //public Int32 CustomerId { get; set; }
        [MaxLength(20)]
        public string FName { get; set; }
        [MaxLength(30)]
        public string LName { get; set; }
        public string Mobile { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }
        public int StatusCustomer { get; set; }
        public Int32 PasswordCustomer { get; set; }
        public DateTime? CustomerCreateDate { get; set; }
        //public DateTime CustomerCreateTime { get; set; }
        public DateTime? CustomerUpdateDate { get; set; }
        //public DateTime CustomerUpdateTime { get; set; }
        public DateTime? CustomerDeleteDate { get; set; }
        //public DateTime CustomerDeleteTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
