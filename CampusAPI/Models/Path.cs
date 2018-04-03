using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAPI.Models
{
  //A path from source to destination node
  public class Path
  {
    //The distance from the source to destination node
    public float distance = float.PositiveInfinity;

    //The nodes to transverse to get to the final node
    //If the path contains only the source node, there is no route to the final node
    public List<string> path = new List<string>();
  }
}