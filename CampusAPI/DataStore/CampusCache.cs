using CampusAPI.BusinessLogicLayer;
using CampusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAPI.DataStore
{
  //Stores Campus data in memory
  public class CampusCache : ICampusCache
  {
    Dictionary<string, CampusMapBLL> campuses = new Dictionary<string, CampusMapBLL>();
    public void SetCampusMap(string Campus, CampusMapBLL CampusMap)
    {
      if (campuses.ContainsKey(Campus))
      {
        campuses[Campus] = CampusMap;
      }
      else
      {
        campuses.Add(Campus, CampusMap);
      }
    }

    public CampusMapBLL GetCampusMap(string Campus)
    {
      if (campuses.ContainsKey(Campus))
      {
        return campuses[Campus];
      }
      else
      {
        return null;
      }
    }
  }
}