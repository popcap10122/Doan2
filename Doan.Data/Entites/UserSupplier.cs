using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class UserSupplier : User
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string NameContact { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public AppUser AppUser { get; set; }
    }
}