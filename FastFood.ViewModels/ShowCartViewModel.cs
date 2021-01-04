using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.ViewModels
{
  public  class ShowCartViewModel
    {
      
        public decimal CurrentPrice { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public int LaborCustomerItem { get; set; }
        public DateTime? InvoicingDetailCreateDate { get; set; }
        public DateTime? InvoicingDetailUpdateDate { get; set; }
        public DateTime? InvoicingDetailDeleteDate { get; set; }
        public int InvoicingDetailStatus { get; set; }

    }
}
