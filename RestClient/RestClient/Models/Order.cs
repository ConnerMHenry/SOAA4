using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
    [JsonObject]
	public class Order
	{
        [JsonProperty]
		public int orderId { get; set; }

        [JsonProperty]
        public int custId { get; set; }

        [JsonProperty]
        public DateTime orderDate { get; set;}

        [JsonProperty]
        public string poNumber { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Order FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Order>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}