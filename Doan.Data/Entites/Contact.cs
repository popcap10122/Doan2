using Doan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Entites
{
    public class Contact
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
    }
}