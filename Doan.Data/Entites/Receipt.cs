using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Receipt
    {
        public string Id { get; set; }
        public string SupplierId { get; set; }
        public DateTime DateAdd { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<ProductReceipt> ProductReceipts { get; set; }
    }
}