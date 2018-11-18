using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JacobClient.Models
{
	[JsonObject]
    public class Product
    {
		[JsonProperty]
		public int Id { get; set; }
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public float Price { get; set; }
		[JsonProperty]
		public float Weight { get; set; }
		[JsonProperty]
		public bool IsInStock { get; set; }
        public bool IsControlEnabled { get; set; } = true;
    }
}