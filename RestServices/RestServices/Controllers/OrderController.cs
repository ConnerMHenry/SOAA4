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

        [Route(BaseRoute)]
		public IEnumerable<Order> GetAllOrders()
		{
            try
            {
                CrazyMelvinDAL dal = new CrazyMelvinDAL();
                return dal.GetAllOrders();
            }
            catch (Exception e)
            {
                return null;
            }
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
