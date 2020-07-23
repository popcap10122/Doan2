using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public DateTime LastLogin { get; set; }
    }
}