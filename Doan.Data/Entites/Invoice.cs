using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime DateContract { get; set; }
        public decimal Discount { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<ProductInvoice> productInvoices { get; set; }
    }
}