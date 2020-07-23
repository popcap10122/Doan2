using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class AppUser : IdentityUser<Guid>
    {
        public UserCustomer UserCustomer { get; set; }
        public UserSupplier UserSupplier { get; set; }
    }
}