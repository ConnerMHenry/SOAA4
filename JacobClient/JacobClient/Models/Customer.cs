using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JacobClient.Models
{
	[JsonObject]
    public class Customer
    {
		[JsonProperty]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

		[JsonProperty]
		[Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

		[JsonProperty]
		[Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

		[JsonProperty]
		[Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        public bool IsControlEnabled { get; set; } = true;
    }
}