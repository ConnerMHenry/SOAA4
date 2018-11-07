using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
    [JsonObject]
	public class Product
	{
        [JsonProperty]
		public int prodId { get; set; }

        [JsonProperty]
        public string prodName { get; set; }

        [JsonProperty]
        public decimal price { get; set; }

        [JsonProperty]
        public decimal prodWeight { get; set; }

        [JsonProperty]
        public bool inStock { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Product FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Product>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}