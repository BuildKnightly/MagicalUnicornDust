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
        public IHttpActionResult Get(string map, string node1, string node2)
        {
            return BadRequest();
            //return NotFound();
            //return Ok();
        }

        // PUT: /maps/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return BadRequest();
            //return Ok();
        }
    }
}
