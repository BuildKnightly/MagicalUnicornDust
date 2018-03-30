using CampusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAPI.DataStore
{
    public class CampusCache : ICampusCache
    {
        Dictionary<string, CampusMap> campuses = new Dictionary<string, CampusMap>();
        public void SetCampusMap(string Campus, CampusMap CampusMap)
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

        public CampusMap GetCampusMap(string Campus)
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