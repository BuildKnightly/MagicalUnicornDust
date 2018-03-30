using CampusAPI.BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusAPI.Tests
{
  [TestClass]
  public class CampusMapBLLTests
  {
    [TestMethod]
    public void TestConstructingCampusMapBLL()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.IsNotNull(testObj);
    }

    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteNotFound()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.Fail();
    }

    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFound()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.Fail();
    }

    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundSimple()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.Fail();
    }

    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundDeep()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.Fail();
    }

    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundDeepWithShortCircuit()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.Fail();
    }

    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundDeepWithShortCircuitTrap()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.Fail();
    }
  }
}
