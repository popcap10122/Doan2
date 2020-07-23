using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Receipt
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public DateTime DateCreated { get; set; }
        public UserSupplier UserSupplier { get; set; }
        public ICollection<ProductReceipt> ProductReceipts { get; set; }
    }
}