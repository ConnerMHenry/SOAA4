using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServices.Models;

namespace RestServices.Controllers
{
    public class CartController : ApiController
    {
        CrazyMelvinDAL dal = new CrazyMelvinDAL();
        private const string BaseRoute = WebApiConfig.BaseEndpoint + "Cart/";

        [HttpGet]
        [Route(BaseRoute)]
		public IEnumerable<Cart> GetAllOrders()
		{
            try
            {
                return dal.GetAllCarts();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route(BaseRoute)]
        public IHttpActionResult InsertCart([FromBody] Cart newCart)
        {
            try
            {
                dal.InsertCart(newCart);
                return Ok(newCart);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route(BaseRoute)]
        public IHttpActionResult UpdateCart([FromBody] Cart Cart)
        {
            try
            {
                dal.UpdateCart(Cart);
            }
            catch (Exception exceptional)
            {
                return InternalServerError();
            }
            return Ok(Cart);
        }

        [HttpDelete]
        [Route(BaseRoute + "{orderId}/{prodId}")]
        public IHttpActionResult UpdateDelete(int orderId, int prodId)
        {
            dal.DeleteCart(orderId, prodId);
            return Ok();
        }
    }
}
