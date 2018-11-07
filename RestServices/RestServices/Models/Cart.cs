using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
	public class Cart
	{
		public int orderId { get; set; }
		public int prodId { get; set; }
		public int quantity { get; set; }
	}
}