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

        Product[] products = new Product[]
		{
			new Product{ prodId = 1, prodName = "Grommet", price = 0.02m, prodWeight = 0.005m, inStock = true},
			new Product{ prodId = 2, prodName = "Widgets", price = 2.35m, prodWeight = 0.532m, inStock = true},
			new Product{ prodId = 3, prodName = "Bushings", price = 8.75m, prodWeight = 5.650m, inStock = false}
		};

		public IEnumerable<Product> GetAllProducts()
		{
			return products;
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
