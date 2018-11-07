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

        [Route(BaseRoute)]
		public IEnumerable<Cart> GetAllOrders()
		{
            try
            {
                CrazyMelvinDAL dal = new CrazyMelvinDAL();
                return dal.GetAllCarts();
            }
            catch (Exception e)
            {
                return null;
            }
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
