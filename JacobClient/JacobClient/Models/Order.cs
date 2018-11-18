using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JacobClient.Models
{
	[JsonObject]
    public class Order
    {
		[JsonProperty]
		public int Id { get; set; }
		[JsonProperty]
		public int CustomerId { get; set; }
		[JsonProperty]
		public string PONumber { get; set; }
		[JsonProperty]
		public DateTime OrderDate { get; set; }
        public bool IsControlEnabled { get; set; } = true;
    }
}