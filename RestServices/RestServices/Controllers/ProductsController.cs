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
        CrazyMelvinDAL dal = new CrazyMelvinDAL();
        private const string BaseRoute = WebApiConfig.BaseEndpoint + "Product/";

        [HttpGet]
        [Route(BaseRoute)]
		public IEnumerable<Product> GetAllProducts()
		{
            try
            {
                return dal.GetAllProducts();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route(BaseRoute)]
        public IHttpActionResult InsertProduct([FromBody] Product newProduct)
        {
            try
            {
                dal.InsertProduct(newProduct);
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route(BaseRoute)]
        public IHttpActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                dal.UpdateProduct(product);
            }
            catch (Exception exceptional)
            {
                return InternalServerError();
            }
            return Ok(product);
        }

        [HttpDelete]
        [Route(BaseRoute + "{prodId}")]
        public IHttpActionResult UpdateDelete(int prodId)
        {
            dal.DeleteProduct(prodId);
            return Ok();
        }


    }
}
