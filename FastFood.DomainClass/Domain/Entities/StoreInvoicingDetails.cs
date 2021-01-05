using FastFood.DomainClass.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DomainClass.Domain.Entities
{
    public class StoreInvoicingDetails :BaseEntity<Int32>
    {
        [Key]
        //public Int32 InvoicingDetailId { get; set; }
        public Int32 InvoicingId { get; set; }
        public Int32 ProductId { get; set; }
        public decimal CurrentPrice { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public int LaborCustomerItem { get; set; }
        public DateTime? InvoicingDetailCreateDate { get; set; }
        public DateTime? InvoicingDetailUpdateDate { get; set; }
        public DateTime? InvoicingDetailDeleteDate { get; set; }
        public int InvoicingDetailStatus { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Products> Products { get; set; }
        public ICollection<StoreInvoicing> StoreInvoicings { get; set; }

    }
}
