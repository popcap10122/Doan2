using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Bill
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime BillDate { get; set; }

        public decimal Price { get; set; }
        public AppUser AppUser { get; set; }
    }
}