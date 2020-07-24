using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class ProductInvoice
    {
        public string ProductId { get; set; }
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
    }
}