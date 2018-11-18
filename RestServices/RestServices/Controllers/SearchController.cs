using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServices.Models;

namespace RestServices.Controllers
{
    public class SearchController : ApiController
    {
		string[] CustomerFields = new string[] { "custId", "firstName", "lastName", "phoneNumber" };
		[HttpGet]
		[Route("api/v1/Search/Customer/{customerQuery}")]
		public IHttpActionResult CustomerQuery(string customerQuery)
		{
			Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach(string adingding in customerQuery.Split(';'))
			{
				string a = adingding.Split('=')[0];
				string b = adingding.Split('=')[1];
				if (CustomerFields.Contains(a))
				{
					caluses.Add(a, b);
				}
			}
			IEnumerable<Customer> rsults = new CrazyMelvinDAL().GetCustomersByQuery(caluses);

			return Ok<IEnumerable<Customer>>(rsults);
		}

		[HttpGet]
		[Route("api/v1/Search/Product/{productQuery}")]
		public IHttpActionResult ProductQuery(string productQuery)
		{
			Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach (string adingding in productQuery.Split(';'))
			{
				string a = adingding.Split('=')[0];
				string b = adingding.Split('=')[1];
				if (CustomerFields.Contains(a))
				{
					caluses.Add(a, b);
				}
			}
			IEnumerable<Product> rsults = new CrazyMelvinDAL().GetProductsByQuery(caluses);

			return Ok<IEnumerable<Product>>(rsults);
		}

		[HttpGet]
		[Route("api/v1/Search/Order/{orderQuery}")]
		public IHttpActionResult OrderQuery(string orderQuery)
		{
			Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach (string adingding in orderQuery.Split(';'))
			{
				string a = adingding.Split('=')[0];
				string b = adingding.Split('=')[1];
				if (CustomerFields.Contains(a))
				{
					caluses.Add(a, b);
				}
			}
			IEnumerable<Order> rsults = new CrazyMelvinDAL().GetOrdersByQuery(caluses);

			return Ok<IEnumerable<Order>>(rsults);
		}

		[HttpGet]
		[Route("api/v1/Search/Cart/{cartQuery}")]
		public IHttpActionResult CartQuery(string cartQuery)
		{
			Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach (string adingding in cartQuery.Split(';'))
			{
				string a = adingding.Split('=')[0];
				string b = adingding.Split('=')[1];
				if (CustomerFields.Contains(a))
				{
					caluses.Add(a, b);
				}
			}
			IEnumerable<Cart> rsults = new CrazyMelvinDAL().GetCartsByQuery(caluses);

			return Ok<IEnumerable<Cart>>(rsults);
		}

		[HttpGet]
		[Route("api/v1/Search/PO/{poQuery}")]
		public IHttpActionResult POQuery(string poQuery)
		{
			Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach (string adingding in poQuery.Split(';'))
			{
				string a = adingding.Split('=')[0];
				string b = adingding.Split('=')[1];
				if (CustomerFields.Contains(a))
				{
					caluses.Add(a, b);
				}
			}
			IEnumerable<Cart> rsults = new CrazyMelvinDAL().GetCartsByQuery(caluses);

			return Ok<IEnumerable<Cart>>(rsults);
		}

	}
}
