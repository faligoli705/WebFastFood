using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Models
{
    public class StoreInvoicingDetailsDto
    {
        public Int64 InvoicingDetailId { get; set; }
        public int InvoicingId { get; set; }
        public int ProductId { get; set; }
        public Decimal CurrentPrice { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public int LaborCustomerItem { get; set; }
        public DateTime? InvoicingDetailCreateDate { get; set; }
        //public DateTime InvoicingDetailCreateTime { get; set; }
        public DateTime? InvoicingDetailUpdateDate { get; set; }
        //public DateTime InvoicingDetailUpdateTime { get; set; }
        public DateTime? InvoicingDetailDeleteDate { get; set; }
        //public DateTime InvoicingDetailDeleteTime { get; set; }
        public int InvoicingDetailStatus { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<StoreInvoicing> StoreInvoicings { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
