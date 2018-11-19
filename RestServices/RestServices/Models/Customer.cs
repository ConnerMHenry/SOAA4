using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
    [JsonObject]
    public class Customer
	{
        [JsonProperty]
		public int custId { get; set; }

        [JsonProperty]
        public string firstName { get; set; }

        [JsonProperty]
        public string lastName { get; set; }

        [JsonProperty]
        public string phoneNumber { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Customer()
        {
            custId = 0;
            firstName = "";
            lastName = "";
            phoneNumber = "";
        }

        public static Customer FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Customer>(json);
            }
            catch
            {
                return null;
            }
        }
	}
}