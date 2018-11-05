using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestTestButInCSharp.Models;

namespace RestTestButInCSharp.Controllers
{
    public class CartController : ApiController
    {
		Cart[] carts = new Cart[]
		{
			new Cart{ orderId = 1, prodId = 1, quantity = 500 },
			new Cart{ orderId = 1, prodId = 2, quantity = 1000 },
			new Cart{ orderId = 2, prodId = 3, quantity =  10},
			new Cart{ orderId = 3, prodId = 1, quantity =  75},
			new Cart{ orderId = 3, prodId = 2, quantity =  15},
			new Cart{ orderId = 3, prodId = 3, quantity =  5}
		};

		public IEnumerable<Cart> GetAllOrders()
		{
			return carts;
		}

		public IHttpActionResult GetOrder(int id)
		{
			var order = carts.FirstOrDefault((o) => o.orderId == id);
			if (order == null)
			{
				return NotFound();
			}
			return Ok(order);
		}
	}
}
