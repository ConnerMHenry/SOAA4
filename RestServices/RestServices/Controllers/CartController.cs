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
        private const string BaseRoute = WebApiConfig.BaseEndpoint + "Cart/";

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

        [HttpPost]
        [Route(BaseRoute + "add")]
        public IHttpActionResult InsertCart([FromBody] Cart newCart)
        {
            return Ok(newCart);
        }

        [HttpPut]
        [Route(BaseRoute + "update")]
        public IHttpActionResult UpdateCart([FromBody] Cart Cart)
        {
            return Ok(Cart);
        }

        [HttpDelete]
        [Route(BaseRoute + "delete")]
        public IHttpActionResult UpdateDelete([FromBody] Cart Cart)
        {
            return Ok(Cart);
        }
    }
}
