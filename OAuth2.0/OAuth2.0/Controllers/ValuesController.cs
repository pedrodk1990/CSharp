using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OAuth2._0.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetValues()
        {
            return Ok(new string[] { "value1", "value2" });
        }
      
    }
}
