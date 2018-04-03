using CampusAPI.BusinessLogicLayer;
using CampusAPI.DataStore;
using CampusAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusAPI.Tests
{

  //Utilities class to assist UnitTests
  class mapsControllerTestsUtilities
  {
    //Creates a simple 3 edge Campus Map
    internal static CampusMap GetACampusMap()
    {
      string json = @"{""a"":{""b"":20}," +
                     @"""b"":{""c"":20,""d"":20}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);
      return new CampusMap() { nodes = testNodes };
    }

    //Creates a simple 1 edge Campus Map
    internal static CampusCache GetMapNode1Node2CampusCache()
    {
      string json = @"{""node1"":{""node2"":20}}";

      var testNodes = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(json);

      CampusCache campusCache = new CampusCache();
      campusCache.SetCampusMap("map", new CampusMapBLL(new CampusMap() { nodes = testNodes }));
      return campusCache;
    }
  }
}
