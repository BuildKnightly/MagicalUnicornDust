﻿using System;
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

    [TestMethod]
    public void TestPUTSetsTheCache()
    {
      // Arrange
      DataStore.CampusCache campusCache = new DataStore.CampusCache();
      mapsController controller = new mapsController(campusCache);
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "/maps/map1");
      string campusID = "testID";

      // Action
      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add("a", new Dictionary<string, float>());
      testNodes["a"].Add("b", 20);
      testNodes.Add("b", new Dictionary<string, float>());
      testNodes["b"].Add("q", 20);
      testNodes["b"].Add("c", 20);

      Models.CampusMap campusMap = mapsControllerTestsUtilities.GetACampusMap();


      IHttpActionResult actionResult = controller.Put(campusID, campusMap);

      // Assert
      Assert.AreEqual(campusMap.nodes, campusCache.GetCampusMap(campusID).nodes);
    }
  }
}
