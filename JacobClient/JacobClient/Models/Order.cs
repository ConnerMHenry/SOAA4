using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JacobClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string PONumber { get; set; }
        public DateTime OrderDate { get; set; }

    }
}