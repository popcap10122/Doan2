using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Bill
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Price { get; set; }
        public UserCustomer UserCustomer { get; set; }
    }
}