using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace world.data
{
    public class Invoice
    {
        public Guid id { get; set; }
        public int InvoiceNo { get; set; }
        public string StockCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public float? UnitPrice { get; set; }
        public int? CustomerID { get; set; }
        public string Country { get; set; }

    }
}