using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
	public class Customer
	{
		public int custId { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string phoneNumber { get; set; }
	}
}