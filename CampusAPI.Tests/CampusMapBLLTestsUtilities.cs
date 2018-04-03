using CampusAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CampusAPI.Tests
{
  internal class CampusMapBLLTestsUtilities
  {
    //Creates a simple Campus map
    internal static CampusMap GetACampusMap()
    {
      string json = @"{""a"":{""b"":20},"+
                     @"""b"":{""c"":20,""d"":20}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a Campus map with no router to the final node
    internal static CampusMap GetANoRouteCampusMap(string node1, string node2)
    {
      string uniquifier = $"{node1}_{node2}";

      string json = @"{"""+node1+@""":{"""+uniquifier+ @"_a"":20,""" + uniquifier + @"_c"":20}," +
                     @"""" + uniquifier + @"_b"":{""" + node2 + @""":20}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a Campus map with a depth of 2
    internal static CampusMap GetASimpleCampusMap1Hop(string node1, string node2)
    {
      string json = @"{""" + node1 + @""":{""" + node2 + @""":20}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a Campus map with a depth of 4
    internal static CampusMap GetASimpleCampusMap3Hop(string node1, string node2)
    {
      string uniquifier = $"{node1}_{node2}";

      string json = @"{""" + node1 + @""":{""" + uniquifier + @"_a"":5,""" + uniquifier + @"_b"":5}," +
                    @"""" + uniquifier + @"_a"":{""" + uniquifier + @"_d"":30,""" + uniquifier + @"_c"":30}," +
                    @"""" + uniquifier + @"_d"":{""" + node2 + @""":20}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a Campus map with two paths to the final node, the path with fewer hops is better
    internal static CampusMap GetACampusMapWithShortcut(string node1, string node2, int goodRouteNrHops, int badRouteNrHops)
    {
      //These values are passed in to check that no one acidentally breaks this test.
      //Tests need to work with a known(READ Hardcoded) set, and this set has a good route of 2 and a bad route of 3
      if ((goodRouteNrHops != 2) || (badRouteNrHops != 3))
      {
        throw new InvalidOperationException();
      }

      string uniquifier = $"{node1}_{node2}";

      string json = @"{""" + node1 + @""":{""" + uniquifier + @"_a"":5,""" + uniquifier + @"_b"":6}," +
                    @"""" + uniquifier + @"_a"":{""" + uniquifier + @"_c"":2}," +
                    @"""" + uniquifier + @"_b"":{""" + node2 + @""":5}," +
                    @"""" + uniquifier + @"_c"":{""" + node2 + @""":5}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a Campus map with two paths to the final node, the path with fewer hops is weighted worse
    internal static CampusMap GetACampusMapWithShortcutTrap(string node1, string node2, int goodRouteNrHops, int badRouteNrHops)
    {
      //These values are passed in to check that no one acidentally breaks this test.
      //Tests need to work with a known(READ Hardcoded) set, and this set has a good route of 5 and a bad route of 3
      if ((goodRouteNrHops != 3)||(badRouteNrHops != 2))
      {
        throw new InvalidOperationException();
      }

      string uniquifier = $"{node1}_{node2}";
      string json = @"{""" + node1 + @""":{""" + uniquifier + @"_a"":5,""" + uniquifier + @"_b"":6}," +
                    @"""" + uniquifier + @"_a"":{""" + uniquifier + @"_c"":2}," +
                    @"""" + uniquifier + @"_b"":{""" + node2 + @""":15}," +
                    @"""" + uniquifier + @"_c"":{""" + node2 + @""":5}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a Campus map with a circular reference to be checked before reaching the final node
    internal static CampusMap GetACampusMapWithCircularReference(string node1, string node2, int goodRouteNrHops)
    {
      //These values are passed in to check that no one acidentally breaks this test.
      //Tests need to work with a known(READ Hardcoded) set, and this set has a good route of 4
      if ((goodRouteNrHops != 4))
      {
        throw new InvalidOperationException();
      }

      string uniquifier = $"{node1}_{node2}";

      string json = @"{""" + node1 + @""":{""" + uniquifier + @"_a"":5}," +
                    @"""" + uniquifier + @"_a"":{""" + uniquifier + @"_b"":5}," +
                    @"""" + uniquifier + @"_b"":{""" + uniquifier + @"_c"":5}," +
                    @"""" + uniquifier + @"_b"":{""" + uniquifier + @"_d"":10}," +
                    @"""" + uniquifier + @"_c"":{""" + uniquifier + @"_a"":5}," +
                    @"""" + uniquifier + @"_d"":{""" + node2 + @""":10}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a Campus map with a circular reference and no way to the final node
    internal static CampusMap GetACampusMapWithNoRouteAndWithCircularReference(string node1, string node2)
    {
      string uniquifier = $"{node1}_{node2}";

      string json = @"{""" + node1 + @""":{""" + uniquifier + @"_a"":5}," +
                    @"""" + uniquifier + @"_a"":{""" + uniquifier + @"_b"":5}," +
                    @"""" + uniquifier + @"_b"":{""" + uniquifier + @"_d"":5}," +
                    @"""" + uniquifier + @"_d"":{""" + uniquifier + @"_a"":5}," +
                    @"""" + uniquifier + @"_c"":{""" + node2 + @""":10}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }
  }
}