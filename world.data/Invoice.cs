using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace world.data
{
    public class Invoice
    {
        public int InvoiceNo { get; set; }
        public int Stockcode { get; set; }
        public string Description { get; set; }
        public int Quality { get; set; }
        public int InvoiceDate { get; set; }
        public float UnitPrice { get; set; }
        public int CustomerId { get; set; }
        public string Country { get; set; }
    }
}