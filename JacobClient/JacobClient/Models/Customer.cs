using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JacobClient.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsControlEnabled { get; set; } = true;
    }
}