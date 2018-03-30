using CampusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusAPI.Tests
{
  class mapsControllerTestsUtilities
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
  }
}
