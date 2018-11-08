using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
    [JsonObject]
	public class Cart
	{
        [JsonProperty]
		public int orderId { get; set; }

        [JsonProperty]
        public int prodId { get; set; }

        [JsonProperty]
        public int quantity { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Cart FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Cart>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}