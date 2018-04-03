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
    //Tests that any incorrectly specified parameter results in a NotFound message
    [TestMethod]
    public void TestCallingGETReturnNotFoundErrorMessageResult()
    {
      // Arrange
      mapsController testObj = new mapsController(mapsControllerTestsUtilities.GetMapNode1Node2CampusCache());
      testObj.Request = new HttpRequestMessage();
      testObj.ControllerContext.Configuration = new HttpConfiguration();

      // Action
      HttpResponseMessage actionResultMap = testObj.Get("mapxxx", "node1", "node2").ExecuteAsync(System.Threading.CancellationToken.None).Result;
      HttpResponseMessage actionResultNode1 = testObj.Get("map", "node1xxx", "node2").ExecuteAsync(System.Threading.CancellationToken.None).Result;
      HttpResponseMessage actionResultNode2 = testObj.Get("map", "node1", "node2xxx").ExecuteAsync(System.Threading.CancellationToken.None).Result;
      HttpResponseMessage actionResultMapSanityCheck = testObj.Get("map", "node1", "node2").ExecuteAsync(System.Threading.CancellationToken.None).Result;

      // Assert
      Assert.AreEqual(System.Net.HttpStatusCode.NotFound, actionResultMap.StatusCode);
      Assert.AreEqual(System.Net.HttpStatusCode.NotFound, actionResultNode1.StatusCode);
      Assert.AreEqual(System.Net.HttpStatusCode.NotFound, actionResultNode2.StatusCode);
      Assert.AreEqual(System.Net.HttpStatusCode.OK, actionResultMapSanityCheck.StatusCode); //Checking that NotFoundResult isnt always returned
    }
  }
}
