using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestTestButInCSharp.Models;

namespace RestTestButInCSharp.Controllers
{
    public class ProductsController : ApiController
    {
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

		public IHttpActionResult GetProduct(int id)
		{
			var product = products.FirstOrDefault((p) => p.prodId == id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

    }
}
