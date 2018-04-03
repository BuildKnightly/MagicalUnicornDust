
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CampusAPI.Models
{
  public class CampusMap
  {
    //A set of Nodes (string) and thier neighbours (string), and the Distance (float) to get to the neighbour
    public Dictionary<string, Dictionary<string, float>> nodes;
  }
}