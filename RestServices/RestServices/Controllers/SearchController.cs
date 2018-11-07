using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestTestButInCSharp.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("api/v1/Customer/{customerQuery}/Product/{productQuery}/Order/{orderQuery}/Cart/{cartQuery}")]
        public IHttpActionResult GetQuery(string customerQuery, string productQuery, string orderQuery, string cartQuery)
        {
            return null;
        }

    }
}
