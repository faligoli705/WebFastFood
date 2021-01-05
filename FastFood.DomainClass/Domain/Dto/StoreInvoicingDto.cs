using FastFood.DomainClass.Domain.Common;
using FastFood.DomainClass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DomainClass.Domain.Dto
{
    public class StoreInvoicingDto : BaseEntity<Int32>
    {
        //public Int32 InvoicingId { get; set; }
        public Int32 CustomerId { get; set; }
        public DateTime? StoreInvoicingCreateDate { get; set; }
        public DateTime? StoreInvoicingUpdateDate { get; set; }
        public DateTime? StoreInvoicingDeleteDate { get; set; }
        public int StoreInvoicingStatus { get; set; } // وضعیت فاکتور => 0 کنسل شده . 1 پرداخت نشده .2 پرداخت شده
        public bool IsDelete { get; set; }

        public ICollection<Customers> Customers { get; set; }

        public ICollection<StoreInvoicingDetails> StoreInvoicingDetails { get; set; }
    }
}
