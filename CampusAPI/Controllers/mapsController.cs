using CampusAPI.DataStore;
using CampusAPI.Models;
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
        ICampusCache campusCache;

        public mapsController(ICampusCache CampusCache)
        {
            this.campusCache = CampusCache;
        }

        // GET: /maps/{map}/path/{node1}/{node2}
        [Route("maps/{map}/path/{node1}/{node2}")]
        public IHttpActionResult Get(string map, string node1, string node2)
        {
            return BadRequest();
            return NotFound();
            return Ok();
        }

        // PUT: /maps/{map}
        [Route("maps/{map}")]
        public IHttpActionResult Put(string map, [FromBody]CampusMap campusMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The map data is invalid");
            }
            else
            {
                campusCache.SetCampusMap(map, campusMap);
                return Ok();
            }
        }
    }
}
