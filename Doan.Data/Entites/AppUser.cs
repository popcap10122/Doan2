using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public decimal Debtfirst { get; set; }
        public string NameContact { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public DateTime DoB { get; set; }
        public DateTime LastLogin { get; set; }

        public ICollection<Bill> Bills
        {
            get; set;
        }
    }
}