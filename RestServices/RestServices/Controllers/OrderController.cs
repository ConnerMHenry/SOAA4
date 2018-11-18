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
        CrazyMelvinDAL dal = new CrazyMelvinDAL();

        [HttpGet]
        [Route(BaseRoute)]
		public IEnumerable<Order> GetAllOrders()
		{
            try
            {
                return dal.GetAllOrders();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route(BaseRoute)]
        public IHttpActionResult InsertOrder([FromBody] Order newOrder)
		{
            try
            {
                dal.InsertOrder(newOrder);
                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route(BaseRoute)]
        public IHttpActionResult UpdateOrder([FromBody] Order order)
        {
            try
            {
                dal.UpdateOrder(order);
            }
            catch (Exception exceptional)
            {
                return InternalServerError();
            }
            return Ok(order);
        }

        [HttpDelete]
        [Route(BaseRoute + "orderId")]
        public IHttpActionResult DeleteOrder(int orderId)
        {
            dal.DeleteOrder(orderId);
            return Ok();
        }
    }
}
