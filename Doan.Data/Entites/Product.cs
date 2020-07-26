using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<ProductInvoice> productInvoices { get; set; }
        public ICollection<ProductReceipt> productReceipts { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}