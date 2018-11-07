using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServices.Models;

namespace RestServices.Controllers
{
    public class CustomerController : ApiController
    {
        private const string BaseRoute = WebApiConfig.BaseEndpoint + "Customer/";

        Customer[] customers = new Customer[]
		{
			new Customer{ custId = 1, firstName = "Joe", lastName = "Smith", phoneNumber = "555-555-1212"},
			new Customer{ custId = 2, firstName = "Nancy", lastName = "Jones", phoneNumber = "555-235-4578"},
			new Customer{ custId = 3, firstName = "Henry", lastName = "Hoover", phoneNumber = "555-326-8456"}
		};

		public IEnumerable<Customer> GetAllCustomers()
		{
			return customers;
		}

        [HttpPost]
        [Route(BaseRoute + "add")]
		public IHttpActionResult InsertCustomer([FromBody] Customer newCustomer)
		{
			return Ok(newCustomer);
		}

        [HttpPut]
        [Route(BaseRoute + "update")]
        public IHttpActionResult UpdateCustomer([FromBody] Customer customer)
        {
            return Ok(customer);
        }

        [HttpDelete]
        [Route(BaseRoute + "deletes")]
        public IHttpActionResult DeleteCustomer([FromBody] Customer customer)
        {
            return Ok(customer);
        }

    }
}
