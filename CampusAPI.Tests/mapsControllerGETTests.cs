using System;
using System.Collections.Generic;
using System.Linq;
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

            // Arrange
            mapsController testObj = new mapsController(new CampusCache());
            
            // Action
            IHttpActionResult actionResult = testObj.Get("map", "node1", "node2");

            // Assert
            Assert.AreEqual(typeof(System.Web.Http.Results.NotFoundResult), actionResult.GetType());
        }
    }
}
