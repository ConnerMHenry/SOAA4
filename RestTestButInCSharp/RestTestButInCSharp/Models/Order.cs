using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestTestButInCSharp.Models
{
	public class Order
	{
		public int orderId { get; set; }
		public int custId { get; set; }
		public DateTime orderDate { get; set;}
		public string poNumber { get; set; }
	}
}