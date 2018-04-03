using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using CampusAPI.Controllers;
using CampusAPI.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampusAPI.Tests
{
  [TestClass]
  public class mapsControllerPUTTests
  {
    //Tests that PUT will return BadRequest if an error occurs when loading Model State
    [TestMethod]
    public void TestCallingPUTReturnsBadRequestErrorMessageResult()
    {
      // Arrange
      var controller = new mapsController(new CampusCache());
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "/maps/map1");
      controller.ModelState.AddModelError("fakeError", "fakeError");

      // Action
      IHttpActionResult actionResult = controller.Put("", new Models.CampusMap() { });

      // Assert
      Assert.AreEqual(typeof(System.Web.Http.Results.BadRequestErrorMessageResult), actionResult.GetType());
    }

    //Tests that PUT adds the sent in nodes to the campus cache
    [TestMethod]
    public void TestPUTSetsTheCache()
    {
      // Arrange
      DataStore.CampusCache campusCache = new DataStore.CampusCache();
      mapsController controller = new mapsController(campusCache);
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "/maps/map1");
      string campusID = "testID";

      // Action
      Models.CampusMap campusMap = mapsControllerTestsUtilities.GetACampusMap();

      IHttpActionResult actionResult = controller.Put(campusID, campusMap);

      // Assert
      Assert.AreEqual(campusMap.nodes, campusCache.GetCampusMap(campusID).nodes);
    }
  }
}
