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
      List<string> unvisitedNodes = new List<string>(AllKnownNodeIds);
      Dictionary<string, Path> workingSet = InitialiseWorkingSet(Node1);

      while (unvisitedNodes.Count > 0)
      {
        unvisitedNodes.Sort((a, b) => workingSet[a].distance.CompareTo(workingSet[b].distance));
        string targetNode = unvisitedNodes[0];
        if(workingSet[targetNode].distance == float.PositiveInfinity)  // We've run out of connected nodes
        {
          break;
        }
        unvisitedNodes.Remove(targetNode);

        if (nodes.ContainsKey(targetNode))
        {
          foreach (string node in nodes[targetNode].Keys)
          {
            //check if shortest distance from the origin to this node 
            //added to
            //the distance to the next node
            //is shorter than
            //the known distance from the origin the the next node
            if (workingSet[targetNode].distance + nodes[targetNode][node] < workingSet[node].distance)
            {
              //update the route distance to the next node with this known shorter route distance
              workingSet[node].distance = workingSet[targetNode].distance + nodes[targetNode][node];

              //update the route path to be this nodes path plus the edge to the next node
              workingSet[node].path = new List<string>(workingSet[targetNode].path);
              workingSet[node].path.Add(node);
            }
          }
        }
      }
      return workingSet[Node2];
    }

    private Dictionary<string, Path> InitialiseWorkingSet(string originNode)
    {
      Dictionary<string, Path> workingSet = new Dictionary<string, Path>();
      foreach (string node in AllKnownNodeIds)
      {
        Path shortestPath = new Path();
        shortestPath.path.Add(originNode);
        shortestPath.distance = (node == originNode ? 0 : float.PositiveInfinity);
        workingSet.Add(node, shortestPath);
      }
      return workingSet;
    }
    /*
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
        pathVector.shortestPath.path.Add(originNode);
        pathVector.shortestPath.distance = (node == originNode ? 0 : float.PositiveInfinity);
        nodeDistances.Add(pathVector);
      }

      return nodeDistances;
    }*/
  }
}