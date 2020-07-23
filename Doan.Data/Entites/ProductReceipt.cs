using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class ProductReceipt
    {
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Product Product { get; set; }
        public Receipt Receipt { get; set; }
    }
}