using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestTestButInCSharp.Models;

namespace RestTestButInCSharp.Controllers
{
    public class CustomerController : ApiController
    {
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

		public IHttpActionResult GetCustomer(int id)
		{
			var customer = customers.FirstOrDefault((c) => c.custId == id);
			if (customer == null)
			{
				return NotFound();
			}
			return Ok(customer);
		}
	}
}
