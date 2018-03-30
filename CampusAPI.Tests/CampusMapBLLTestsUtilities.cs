using CampusAPI.Models;
using System;
using System.Collections.Generic;

namespace CampusAPI.Tests
{
  internal class CampusMapBLLTestsUtilities
  {
    internal static CampusMap GetACampusMap()
    {
      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add("a", new Dictionary<string, float>());
      testNodes["a"].Add("b", 20);
      testNodes.Add("b", new Dictionary<string, float>());
      testNodes["b"].Add("q", 20);
      testNodes["b"].Add("c", 20);

      return new CampusMap() { nodes = testNodes };
    }

    internal static CampusMap GetANoRouteCampusMap(string node1, string node2)
    {
      string uniquifier = $"{node1}_{node2}";

      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add(node1, new Dictionary<string, float>());
      testNodes.Add(node2, new Dictionary<string, float>());
      testNodes.Add($"{uniquifier}_a", new Dictionary<string, float>());
      testNodes.Add($"{uniquifier}_b", new Dictionary<string, float>());
      testNodes[node1].Add($"{uniquifier}_a", 20);
      testNodes[node1].Add($"{uniquifier}_c", 20);
      testNodes[$"{uniquifier}_b"].Add(node2, 20);

      return new CampusMap() { nodes = testNodes };
    }

    internal static CampusMap GetASimpleCampusMap1Hop(string node1, string node2)
    {
      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add(node1, new Dictionary<string, float>());
      testNodes[node1].Add(node2, 20);

      return new CampusMap() { nodes = testNodes };
    }

    internal static CampusMap GetASimpleCampusMap3Hop(string node1, string node2)
    {
      string uniquifier = $"{node1}_{node2}";
      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add(node1, new Dictionary<string, float>());
      testNodes.Add($"{uniquifier}_a", new Dictionary<string, float>());
      testNodes[node1].Add($"{uniquifier}_a", 5);
      testNodes[node1].Add($"{uniquifier}_b", 5);
      testNodes[$"{uniquifier}_a"].Add(node2, 30);
      testNodes[$"{uniquifier}_a"].Add($"{uniquifier}_c", 30);

      return new CampusMap() { nodes = testNodes };
    }

    internal static CampusMap GetACampusMapWithShortCircuit(string node1, string node2, int goodRouteNrHops, int badRouteNrHops)
    {
      //These values are passed in to check that no one acidentally breaks this test.
      //Tests need to work with a known(READ Hardcoded) set, and this set has a good route of 4 and a bad route of 6
      if ((goodRouteNrHops != 4) || (badRouteNrHops != 6))
      {
        throw new InvalidOperationException();
      }

      string uniquifier = $"{node1}_{node2}";

      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add(node1, new Dictionary<string, float>());
      testNodes.Add($"{uniquifier}_a", new Dictionary<string, float>());
      testNodes[node1].Add($"{uniquifier}_a", 5);
      testNodes[node1].Add($"{uniquifier}_b", 5);
      testNodes[$"{uniquifier}_a"].Add(node2, 30);
      testNodes[$"{uniquifier}_a"].Add($"{uniquifier}_c", 30);

      return new CampusMap() { nodes = testNodes };
    }

    internal static CampusMap GetACampusMapWithShortCircuitTrap(string node1, string node2, int goodRouteNrHops, int badRouteNrHops)
    {
      //These values are passed in to check that no one acidentally breaks this test.
      //Tests need to work with a known(READ Hardcoded) set, and this set has a good route of 5 and a bad route of 3
      if ((goodRouteNrHops != 5)||(badRouteNrHops != 3))
      {
        throw new InvalidOperationException();
      }

      string uniquifier = $"{node1}_{node2}";

      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add(node1, new Dictionary<string, float>());
      testNodes.Add($"{uniquifier}_a", new Dictionary<string, float>());
      testNodes[node1].Add($"{uniquifier}_a", 5);
      testNodes[node1].Add($"{uniquifier}_b", 5);
      testNodes[$"{uniquifier}_a"].Add(node2, 30);
      testNodes[$"{uniquifier}_a"].Add($"{uniquifier}_c", 30);

      return new CampusMap() { nodes = testNodes };
    }

    internal static CampusMap GetACampusMapWithNoRouteAndWithCircularReference(string node1, string node2, int goodRouteNrHops)
    {
      //These values are passed in to check that no one acidentally breaks this test.
      //Tests need to work with a known(READ Hardcoded) set, and this set has a good route of  3
      if ((goodRouteNrHops != 3))
      {
        throw new InvalidOperationException();
      }
    }
  }
}