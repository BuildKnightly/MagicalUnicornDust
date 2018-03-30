using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using CampusAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampusAPI.Tests
{
    [TestClass]
    public class mapsControllerTests
    {
        [TestMethod]
        public void TestCallingGet()
        {
            mapsController testObj = new mapsController();
            testObj.Get("map", "node1", "node2");
        }

        [TestMethod]
        public void TestCallingPut()
        {
            // Arrange
            var controller = new mapsController();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "/maps/map1");
            controller.ModelState.AddModelError("fakeError", "fakeError");

            // Action
            IHttpActionResult actionResult = controller.Put("", new Models.CampusMap() { });

            // Assert
            Assert.AreEqual(typeof(System.Web.Http.Results.BadRequestErrorMessageResult), actionResult.GetType());
        }
    }
}
