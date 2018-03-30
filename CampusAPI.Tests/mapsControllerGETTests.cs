using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
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
      
      // Arrange
      mapsController testObj = new mapsController(mapsControllerTestsUtilities.GetMapNode1Node2CampusCache());
      testObj.Request = new HttpRequestMessage();
      testObj.ControllerContext.Configuration = new HttpConfiguration();

      // Action
      IHttpActionResult actionResultMap = testObj.Get("mapxxx", "node1", "node2");
      IHttpActionResult actionResultNode1 = testObj.Get("map", "node1xxx", "node2");
      IHttpActionResult actionResultNode2 = testObj.Get("map", "node1", "node2xxx");
      HttpResponseMessage actionResultMapSanityCheck = testObj.Get("map", "node1", "node2").ExecuteAsync(System.Threading.CancellationToken.None).Result;

      // Assert
      Assert.AreEqual(typeof(System.Web.Http.Results.NotFoundResult), actionResultMap.GetType());
      Assert.AreEqual(typeof(System.Web.Http.Results.NotFoundResult), actionResultNode1.GetType());
      Assert.AreEqual(typeof(System.Web.Http.Results.NotFoundResult), actionResultNode2.GetType());
      Assert.AreEqual(System.Net.HttpStatusCode.OK, actionResultMapSanityCheck.StatusCode); //Checking that NotFoundResult isnt always returned
    }
  }
}
