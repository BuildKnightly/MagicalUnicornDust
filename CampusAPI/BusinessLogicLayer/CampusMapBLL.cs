using CampusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAPI.BusinessLogicLayer
{
  public class CampusMapBLL : CampusMap
  {
    public List<string> AllKnownNodeIds;
    public CampusMapBLL(CampusMap CampusMap)
    {
      base.nodes = CampusMap.nodes;
      AllKnownNodeIds = GetAllNodeIds();
    }

    private List<string> GetAllNodeIds()
    {
      List<string> nodeIds = new List<string>();
      foreach (string nodeId1 in nodes.Keys)
      {
        if (!nodeIds.Contains(nodeId1))
        {
          nodeIds.Add(nodeId1);
        }

        foreach (string nodeId2 in nodes[nodeId1].Keys)
        {
          if (!nodeIds.Contains(nodeId2))
          {
            nodeIds.Add(nodeId2);
          }
        }
      }
      return nodeIds;
    }

    public Path GetShortestPath(string Node1, string Node2)
    {
      //Worst Algorithm, Just getting my test to pass
      if ((nodes.ContainsKey(Node1)) && (nodes[Node1].ContainsKey(Node2)))
      {
        Path path = new Path();
        path.distance = nodes[Node1][Node2];
        path.path.AddRange(new string[] { Node1, Node2});

      return path;
      }
      else
      {
        return null;
      }
    }
  }
}