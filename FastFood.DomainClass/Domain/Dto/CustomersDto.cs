using FastFood.DomainClass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DomainClass.Domain.Dto
{
    public class CustomersDto :BaseEntity<Int32>
    {
        //public Int32 CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int StatusCustomer { get; set; } //وضعیت کاربر => 0 غیرفعال شده . 1 فعال . 2 معلق
        public Int32 PasswordCustomer { get; set; }
        public DateTime? CustomerCreateDate { get; set; }
        public DateTime? CustomerUpdateDate { get; set; }
        public DateTime? CustomerDeleteDate { get; set; }
        public bool IsDelete { get; set; }

    }
}
