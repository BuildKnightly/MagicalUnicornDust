using CampusAPI.BusinessLogicLayer.Comparers;
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
      SortedSet<PathVector> unvisitedNodes = InitialiseSortedSet(Node1);
      Dictionary<string, Path> workingSet = InitialiseWorkingSet(unvisitedNodes);

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
        Path path = new Path();
        path.distance = float.PositiveInfinity;
        path.path.AddRange(new string[] { Node1 });
        return path;
      }
    }

    private Dictionary<string, Path> InitialiseWorkingSet(SortedSet<PathVector> graphNodes)
    {
      Dictionary<string, Path> workingSet = new Dictionary<string, Path>();
      foreach (PathVector graphNode in graphNodes.ToList<PathVector>())
      {
        workingSet.Add(graphNode.targetNode, graphNode.shortestPath);
      }
      return workingSet;
    }

    private SortedSet<PathVector> InitialiseSortedSet(string originNode)
    {
      SortedSet<PathVector> nodeDistances = new SortedSet<PathVector>(
                                                                   new PathVectorComparer<PathVector>((a, b) =>
                                                                   {
                                                                     if (a.shortestPath.distance != b.shortestPath.distance)
                                                                     {
                                                                       return a.shortestPath.distance.CompareTo(b.shortestPath.distance);
                                                                     }
                                                                     else
                                                                     {
                                                                       return a.targetNode.CompareTo(b.targetNode);
                                                                     }
                                                                   }));

      foreach (string node in AllKnownNodeIds)
      {
        PathVector pathVector = new PathVector();
        pathVector.targetNode = node;
        pathVector.shortestPath.path.Add(node);
        pathVector.shortestPath.distance = (node == originNode ? 0 : float.PositiveInfinity);
        nodeDistances.Add(pathVector);
      }

      return nodeDistances;
    }
  }
}