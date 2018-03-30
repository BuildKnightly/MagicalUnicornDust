using CampusAPI.BusinessLogicLayer;
using CampusAPI.Models;
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

    //There is no route between the nodes
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteNotFound()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetANoRouteCampusMap(Node1, Node2));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreEqual(path.distance, float.PositiveInfinity);
    }

    // The nodes are 1 step away from each other
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFound1Hop()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";
      int nrHops = 1;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetASimpleCampusMap1Hop(Node1, Node2));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(path.distance, float.PositiveInfinity);
      Assert.AreEqual(path.path.Count, nrHops + 1); // 1 Hop  has 2 nodes
      Assert.AreEqual(path.path[0], Node1); 
      Assert.AreEqual(path.path[nrHops], Node2); 
    }

    // The nodes are more than 2 steps away from each other
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFound3Hop()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";
      int nrHops = 3;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetASimpleCampusMap3Hop(Node1, Node2));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(path.distance, float.PositiveInfinity);
      Assert.AreEqual(path.path.Count, nrHops + 1); // 1 Hop  has 2 nodes
      Assert.AreEqual(path.path[0], Node1);
      Assert.AreEqual(path.path[nrHops], Node2);
    }

    //There are two paths between the nodes, algorithm should use the shorter
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundDeepWithShortCircuit()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.Fail();
    }

    //There is shortcut in this graph, but the weighting is higher, algorithm shouldn't use it
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
