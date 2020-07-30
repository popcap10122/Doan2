using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Systems.Users
{
    public class RegisterRequestSupplier : RegisterBase
    {
        public string NameSupplier { get; set; }
        public string Address { get; set; }
        public string NameContract { get; set; }
    }
}