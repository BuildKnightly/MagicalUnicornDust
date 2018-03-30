using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CampusAPI.Controllers;
using CampusAPI.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampusAPI.Tests
{
  [TestClass]
  public class mapsControllerGETTests
  {
    [TestMethod]
    public void TestCallingGETReturnNotFoundErrorMessageResult()
    {
      Dictionary<string, Dictionary<string, float>> nodes = new Dictionary<string, Dictionary<string, float>>();
      nodes.Add("node1", new Dictionary<string, float>());
      nodes["node1"].Add("node2", 10);

      // Arrange
      CampusCache campusCache = new CampusCache();
      campusCache.SetCampusMap("map", new Models.CampusMap() { nodes = nodes });
      mapsController testObj = new mapsController(new CampusCache());

      // Action
      IHttpActionResult actionResultMap = testObj.Get("mapxxx", "node1", "node2");
      IHttpActionResult actionResultNode1 = testObj.Get("map", "node1xxx", "node2");
      IHttpActionResult actionResultNode2 = testObj.Get("map", "node1", "node2xxx");

      // Assert
      Assert.AreEqual(typeof(System.Web.Http.Results.NotFoundResult), actionResultMap.GetType());
      Assert.AreEqual(typeof(System.Web.Http.Results.NotFoundResult), actionResultNode1.GetType());
      Assert.AreEqual(typeof(System.Web.Http.Results.NotFoundResult), actionResultNode2.GetType());
    }
  }
}
