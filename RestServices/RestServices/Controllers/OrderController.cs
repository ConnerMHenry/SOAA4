using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServices.Models;

namespace RestServices.Controllers
{
	public class OrderController : ApiController
	{
        private const string BaseRoute = WebApiConfig.BaseEndpoint + "Order/";

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

        [HttpPost]
        [Route(BaseRoute + "add")]
        public IHttpActionResult InsertOrder([FromBody] Order newOrder)
		{		
			return Ok(newOrder);
		}

        [HttpPut]
        [Route(BaseRoute + "update")]
        public IHttpActionResult UpdateOrder([FromBody] Order order)
        {
            return Ok(order);
        }

        [HttpDelete]
        [Route(BaseRoute + "add")]
        public IHttpActionResult DeleteOrder([FromBody] Order order)
        {
            return Ok(order);
        }
    }
}
