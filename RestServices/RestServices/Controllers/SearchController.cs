using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServices.Models;

namespace RestServices.Controllers
{
    public class SearchController : ApiController
    {
        CrazyMelvinDAL dal = new CrazyMelvinDAL();

		string[] CustomerFields = new string[] { "custId", "firstName", "lastName", "phoneNumber" };
		[HttpGet]
		[Route("api/v1/Search/Customer/{customerQuery}")]
		public IHttpActionResult CustomerQuery(string customerQuery)
		{
			Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach(string adingding in customerQuery.Split(';'))
			{
                if (adingding.Length > 0)
                {
                    string a = adingding.Split('=')[0];
                    string b = adingding.Split('=')[1];
                    if (CustomerFields.Contains(a))
                    {
                        caluses.Add(a, b);
                    }
                }
			}
			IEnumerable<Customer> rsults = new CrazyMelvinDAL().GetCustomersByQuery(caluses);

			return Ok<IEnumerable<Customer>>(rsults);
		}

        string[] ProductFields = new string[] { "prodId", "prodName", "price", "prodWeight", "inStock" };
        [HttpGet]
		[Route("api/v1/Search/Product/{productQuery}")]
		public IHttpActionResult ProductQuery(string productQuery)
		{
            Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach (string adingding in productQuery.Split(';'))
			{
                if (adingding.Length > 0)
                {
                    string a = adingding.Split('=')[0];
                    string b = adingding.Split('=')[1];
                    if (ProductFields.Contains(a))
                    {
                        caluses.Add(a, b);
                    }
                }
			}
			IEnumerable<Product> rsults = new CrazyMelvinDAL().GetProductsByQuery(caluses);

			return Ok<IEnumerable<Product>>(rsults);
		}

        string[] OrderFields = new string[] { "orderId", "custId", "orderDate", "poNumber" };
        [HttpGet]
		[Route("api/v1/Search/Order/{orderQuery}")]
		public IHttpActionResult OrderQuery(string orderQuery)
		{
            Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach (string adingding in orderQuery.Split(';'))
			{
                if (adingding.Length > 0)
                {
                    string a = adingding.Split('=')[0];
                    string b = adingding.Split('=')[1];
                    if (OrderFields.Contains(a))
                    {
                        caluses.Add(a, b);
                    }
                }
			}
			IEnumerable<Order> rsults = new CrazyMelvinDAL().GetOrdersByQuery(caluses);

			return Ok<IEnumerable<Order>>(rsults);
		}


        string[] CartFields = new string[] { "orderId", "prodId", "quantity"};
        [HttpGet]
		[Route("api/v1/Search/Cart/{cartQuery}")]
		public IHttpActionResult CartQuery(string cartQuery)
		{
			Dictionary<string, string> caluses = new Dictionary<string, string>();
			foreach (string adingding in cartQuery.Split(';'))
			{
                if (adingding.Length > 0)
                {
                    string a = adingding.Split('=')[0];
                    string b = adingding.Split('=')[1];
                    if (CartFields.Contains(a))
                    {
                        caluses.Add(a, b);
                    }
                }
			}
			IEnumerable<Cart> rsults = new CrazyMelvinDAL().GetCartsByQuery(caluses);

			return Ok<IEnumerable<Cart>>(rsults);
		}

		[HttpGet]
		[Route("api/v1/Search/PurchaseOrder/{poQuery}")]
		public IHttpActionResult POQuery(string poQuery)
		{
            PurchaseOrder po = new PurchaseOrder();

            Dictionary<string, string> caluses = new Dictionary<string, string>();
            foreach (string adingding in poQuery.Split(';'))
            {
                if (adingding.Length > 0)
                {
                    string a = adingding.Split('=')[0];
                    string b = adingding.Split('=')[1];
                    if (CustomerFields.Contains(a))
                    {
                        caluses.Add(a, b);
                    }
                }
            }
            List<Customer> c = (List<Customer>)dal.GetCustomersByQuery(caluses);
            poQuery += "custId=" + c[0].custId.ToString();
            po.customer = c[0];

            caluses = new Dictionary<string, string>();
            foreach (string adingding in poQuery.Split(';'))
            {
                if (adingding.Length > 0)
                {
                    string a = adingding.Split('=')[0];
                    string b = adingding.Split('=')[1];
                    if (OrderFields.Contains(a))
                    {
                        caluses.Add(a, b);
                    }
                }
            }
            List <Order> o = (List<Order>)dal.GetOrdersByQuery(caluses);
            po.order = o[0];
            List<Product> p = (List<Product>)dal.GetAllProducts();
            po.products = new Dictionary<int, Product>();
            foreach (Product pro in p)
            {
                po.products.Add(pro.prodId, pro);
            }

            caluses = new Dictionary<string, string>();
            foreach (string adingding in poQuery.Split(';'))
            {
                if (adingding.Length > 0)
                {
                    string a = adingding.Split('=')[0];
                    string b = adingding.Split('=')[1];
                    if (CartFields.Contains(a))
                    {
                        caluses.Add(a, b);
                    }
                }
            }
            List<Cart> carts = (List<Cart>)dal.GetCartsByQuery(caluses);
            po.carts = carts;
            po.CalculateTotals();

			return Ok<PurchaseOrder>(po);
		}

	}
}
