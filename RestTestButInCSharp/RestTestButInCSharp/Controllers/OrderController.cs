using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestTestButInCSharp.Models;

namespace RestTestButInCSharp.Controllers
{
	public class OrderController : ApiController
	{
		Order[] orders = new Order[]
		{
			new Order{ orderId = 1, custId = 1, orderDate = DateTime.Parse("2018-09-15"), poNumber = "GRAP-09-2018-001"},
			new Order{ orderId = 2, custId = 1, orderDate = DateTime.Parse("2018-09-30"), poNumber = "GRAP-09-2018-056"},
			new Order{ orderId = 3, custId = 3, orderDate = DateTime.Parse("2018-10-05"), poNumber = ""}
		};

		public IEnumerable<Order> GetAllOrders()
		{
			return orders;
		}

		public IHttpActionResult GetOrder(int id)
		{
			var order = orders.FirstOrDefault((o) => o.orderId == id);
			if (order == null)
			{
				return NotFound();
			}
			return Ok(order);
		}
	}
}
