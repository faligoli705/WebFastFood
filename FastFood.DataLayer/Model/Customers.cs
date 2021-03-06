﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DataLayer.Model
{
    public class Customers
    {
        [Key]
        public Int32 CustomerId { get; set; }
        [Required]
        [MaxLength(20)]
        public string FName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LName { get; set; }
        [MaxLength(11)]
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
