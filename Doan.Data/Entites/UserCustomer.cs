using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class UserCustomer : User
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public decimal Debtfirst { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public AppUser AppUser { get; set; }
    }
}