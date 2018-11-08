using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestServices.Models;

namespace RestServices.Controllers
{
    public class CustomerController : ApiController
    {
        private const string BaseRoute = WebApiConfig.BaseEndpoint + "Customer/";

        [Route(BaseRoute)]
		public IEnumerable<Customer> GetAllCustomers()
		{
            try
            {
                CrazyMelvinDAL dal = new CrazyMelvinDAL();
                return dal.GetAllCustomers();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route(BaseRoute + "add")]
		public IHttpActionResult InsertCustomer([FromBody] Customer newCustomer)
		{
            try
            {
                CrazyMelvinDAL dal = new CrazyMelvinDAL();
                dal.InsertCustomer(newCustomer);
            }
            catch (Exception exceptional)
            {
                return InternalServerError();
            }
			return Ok(newCustomer);
		}

        [HttpPut]
        [Route(BaseRoute + "update")]
        public IHttpActionResult UpdateCustomer([FromBody] Customer customer)
        {
            return Ok(customer);
        }

        [HttpDelete]
        [Route(BaseRoute + "deletes")]
        public IHttpActionResult DeleteCustomer([FromBody] Customer customer)
        {
            return Ok(customer);
        }

    }
}
