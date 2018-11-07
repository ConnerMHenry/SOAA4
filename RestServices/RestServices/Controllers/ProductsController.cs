using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServices.Models;

namespace RestServices.Controllers
{
    public class ProductsController : ApiController
    {
        private const string BaseRoute = WebApiConfig.BaseEndpoint + "Product/";

        [Route(BaseRoute)]
		public IEnumerable<Product> GetAllProducts()
		{
            try
            {
                CrazyMelvinDAL dal = new CrazyMelvinDAL();
                return dal.GetAllProducts();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route(BaseRoute + "add")]
        public IHttpActionResult InsertProduct([FromBody] Product newProduct)
        {
            return Ok(newProduct);
        }

        [HttpPut]
        [Route(BaseRoute + "update")]
        public IHttpActionResult UpdateProduct([FromBody] Product product)
        {
            return Ok(product);
        }

        [HttpDelete]
        [Route(BaseRoute + "delete")]
        public IHttpActionResult UpdateDelete([FromBody] Product product)
        {
            return Ok(product);
        }


    }
}
