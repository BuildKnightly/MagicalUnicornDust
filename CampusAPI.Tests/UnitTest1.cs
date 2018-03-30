using System;
using CampusAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampusAPI.Tests
{
    [TestClass]
    public class mapsControllerTestClass
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
        }
    }
}
