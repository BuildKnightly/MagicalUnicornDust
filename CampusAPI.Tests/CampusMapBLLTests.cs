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
      Assert.AreEqual(path.path.Count, 1);
      Assert.AreEqual(path.path[0], Node1);
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
      string Node1 = "N1";
      string Node2 = "N2";
      int goodRouteNrHops = 4;
      int badRouteNrHops = 6;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetACampusMapWithShortCircuit(Node1, Node2, goodRouteNrHops, badRouteNrHops));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(path.distance, float.PositiveInfinity);
      Assert.AreEqual(path.path.Count, goodRouteNrHops + 1); // 1 Hop  has 2 nodes
      Assert.AreEqual(path.path[0], Node1);
      Assert.AreEqual(path.path[goodRouteNrHops], Node2);
    }

    //There is shortcut in this graph, but the weighting is higher, algorithm shouldn't use it
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundDeepWithShortCircuitTrap()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";
      int badRouteNrHops = 3;
      int goodRouteNrHops = 5;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetACampusMapWithShortCircuitTrap(Node1, Node2, goodRouteNrHops, badRouteNrHops));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(path.distance, float.PositiveInfinity);
      Assert.AreEqual(path.path.Count, goodRouteNrHops + 1); // 1 Hop  has 2 nodes
      Assert.AreEqual(path.path[0], Node1);
      Assert.AreEqual(path.path[goodRouteNrHops], Node2);
    }

    //There are two paths between the nodes, algorithm should use the shorter
    [TestMethod, Timeout(1000)]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundWithCircularReference()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";
      int goodRouteNrHops = 4;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetACampusMapWithCircularReference(Node1, Node2, goodRouteNrHops));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(path.distance, float.PositiveInfinity);
      Assert.AreEqual(path.path.Count, goodRouteNrHops + 1);
      Assert.AreEqual(path.path[0], Node1);
      Assert.AreEqual(path.path[goodRouteNrHops], Node2);
    }

    //There are two paths between the nodes, algorithm should use the shorter
    [TestMethod, Timeout(1000)]
    public void TestCampusMapBLL_GetShortestPath_RouteNotFoundWithCircularReference()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetACampusMapWithNoRouteAndWithCircularReference(Node1, Node2));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreEqual(path.distance, float.PositiveInfinity);
      Assert.AreEqual(path.path.Count, 1);
      Assert.AreEqual(path.path[0], Node1);
    }
  }
}
