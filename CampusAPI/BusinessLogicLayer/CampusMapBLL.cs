using CampusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAPI.BusinessLogicLayer
{
  public class CampusMapBLL : CampusMap
  {
    public CampusMapBLL(CampusMap CampusMap)
    {
      base.nodes = CampusMap.nodes;
    }
  }
}