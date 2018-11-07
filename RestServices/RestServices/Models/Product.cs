using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
	public class Product
	{
		public int prodId { get; set; }
		public string prodName { get; set; }
		public decimal price { get; set; }
		public decimal prodWeight { get; set; }
		public bool inStock { get; set; }
	}
}