using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DateCreated { get; set; }
        public decimal Discount { get; set; }
        public UserCustomer UserCustomer { get; set; }
        public ICollection<ProductInvoice> productInvoices { get; set; }
    }
}