using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JacobClient.Models
{
	[JsonObject]
    public class Cart
    {
		[JsonProperty]
		public int OrderId { get; set; }
		[JsonProperty]
		public int ProductId { get; set; }
		[JsonProperty]
		public int Quantity { get; set; }
        public bool IsControlEnabled { get; set; } = true;
    }
}