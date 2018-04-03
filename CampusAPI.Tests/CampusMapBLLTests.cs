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
    //Tests that any incorrectly specified parameter results in a NotFound message
    [TestMethod]
    public void TestConstructingCampusMapBLL()
    {
      // Arrange

      // Action
      CampusMapBLL testObj = new CampusMapBLL(mapsControllerTestsUtilities.GetACampusMap());

      // Assert
      Assert.IsNotNull(testObj);
    }

    //Tests that when there is no route between the nodes, a distance of infinite units is returned
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteNotFound()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";

      object o = CampusMapBLLTestsUtilities.GetACampusMap();

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetANoRouteCampusMap(Node1, Node2));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreEqual(float.PositiveInfinity, path.distance);
      Assert.AreEqual(1, path.path.Count);
      Assert.AreEqual(Node1, path.path[0]);
    }

    //Tests that a route is found when the nodes are 1 step away from each other
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
      Assert.AreNotEqual(float.PositiveInfinity, path.distance);
      Assert.AreEqual(nrHops + 1, path.path.Count); // 1 Hop  has 2 nodes
      Assert.AreEqual(Node1, path.path[0]);
      Assert.AreEqual(Node2, path.path[nrHops]);
    }

    //Tests that a route is found when the nodes are 3 steps away from each other
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
      Assert.AreNotEqual(float.PositiveInfinity, path.distance);
      Assert.AreEqual(nrHops + 1, path.path.Count); // 3 Hops have 4 nodes
      Assert.AreEqual(Node1, path.path[0]);
      Assert.AreEqual(Node2, path.path[nrHops]);
    }

    //Tests that the algorithm uses the shorter when there are two paths between the nodes.
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundDeepWithShortCircuit()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";
      int goodRouteNrHops = 2;
      int badRouteNrHops = 3;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetACampusMapWithShortcut(Node1, Node2, goodRouteNrHops, badRouteNrHops));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(float.PositiveInfinity, path.distance);
      Assert.AreEqual(goodRouteNrHops + 1, path.path.Count);// 4 Hops have 5 nodes
      Assert.AreEqual(Node1, path.path[0]);
      Assert.AreEqual(Node2, path.path[goodRouteNrHops]);
    }

    //Tests that the algorithm uses the shortest weighted path, not the one with the least hops
    [TestMethod]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundDeepWithShortCircuitTrap()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";
      int badRouteNrHops = 2;
      int goodRouteNrHops = 3;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetACampusMapWithShortcutTrap(Node1, Node2, goodRouteNrHops, badRouteNrHops));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(float.PositiveInfinity, path.distance);
      Assert.AreEqual(goodRouteNrHops + 1, path.path.Count); // 5 Hops have 6 nodes
      Assert.AreEqual(Node1, path.path[0]);
      Assert.AreEqual(Node2, path.path[goodRouteNrHops]);
    }

    //Tests that the algorithm finds a path, and doesn't get stuck if there is a circular reference
    [TestMethod, Timeout(1000)]
    public void TestCampusMapBLL_GetShortestPath_RouteFoundWithCircularReference()
    {
      // Arrange
      string Node1 = "N1";
      string Node2 = "N2";
      int nrHops = 4;

      // Action
      CampusMapBLL testObj = new CampusMapBLL(CampusMapBLLTestsUtilities.GetACampusMapWithCircularReference(Node1, Node2, nrHops));
      Path path = testObj.GetShortestPath(Node1, Node2);

      // Assert
      Assert.IsNotNull(path);
      Assert.AreNotEqual(float.PositiveInfinity, path.distance);
      Assert.AreEqual(nrHops + 1, path.path.Count);
      Assert.AreEqual(Node1, path.path[0]);
      Assert.AreEqual(Node2, path.path[nrHops]);
    }

    //Tests that the algorithm doesn't get stuck if there is a circular reference and no path is found
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
      Assert.AreEqual(float.PositiveInfinity, path.distance);
      Assert.AreEqual(1, path.path.Count);
      Assert.AreEqual(Node1, path.path[0]);
    }
  }
}
