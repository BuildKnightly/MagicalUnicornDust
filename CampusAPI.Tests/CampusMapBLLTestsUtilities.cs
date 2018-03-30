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
      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add(node1, new Dictionary<string, float>());
      testNodes.Add(node2, new Dictionary<string, float>());
      testNodes.Add($"{node1}_{node2}_a", new Dictionary<string, float>());
      testNodes.Add($"{node1}_{node2}_b", new Dictionary<string, float>());
      testNodes[node1].Add($"{node1}_{node2}_a", 20);
      testNodes[node1].Add($"{node1}_{node2}_c", 20);
      testNodes[$"{node1}_{node2}_b"].Add(node2, 20);

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
      Dictionary<string, Dictionary<string, float>> testNodes = new Dictionary<string, Dictionary<string, float>>();
      testNodes.Add(node1, new Dictionary<string, float>());
      testNodes.Add($"{node1}_{node2}_a", new Dictionary<string, float>());
      testNodes[node1].Add($"{node1}_{node2}_a", 5);
      testNodes[node1].Add($"{node1}_{node2}_b", 5);
      testNodes[$"{node1}_{node2}_a"].Add(node2, 30);
      testNodes[$"{node1}_{node2}_a"].Add($"{node1}_{node2}_c", 30);

      return new CampusMap() { nodes = testNodes };
    }
  }
}