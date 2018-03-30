using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CampusAPI.Controllers
{
    public class mapsController : ApiController
    {
        // GET: /maps/{map}/path/{node1}/{node2}
        [Route("maps/{map}/path/{node1}/{node2}")]
        public string Get(string map, string node1, string node2)
        {
            return "value";
        }

        // PUT: /maps/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
