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
        CrazyMelvinDAL dal = new CrazyMelvinDAL();

        [HttpGet]
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
        [Route(BaseRoute)]
		public IHttpActionResult InsertCustomer([FromBody] Customer newCustomer)
		{
            try
            {
                dal.InsertCustomer(newCustomer);
            }
            catch (Exception exceptional)
            {
                return InternalServerError();
            }
			return Ok(newCustomer);
		}

        [HttpPut]
        [Route(BaseRoute)]
        public IHttpActionResult UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                dal.UpdateCustomer(customer);
            }
            catch (Exception exceptional)
            {
                return InternalServerError();
            }
            return Ok(customer);
        }

        [HttpDelete]
        [Route(BaseRoute + "{custId}")]
        public IHttpActionResult DeleteCustomer(int custId)
        {
            try
            {
                dal.DeleteCustomer(custId);
            }
            catch (Exception exceptional)
            {
                return InternalServerError();
            }
            return Ok();
        }

    }
}
