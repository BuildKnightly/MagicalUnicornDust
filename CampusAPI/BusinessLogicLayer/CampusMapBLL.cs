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

    //Gets all nodes identified in the path Campus Map
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

    //Processes the GetShortestPath algorithm
    public Path GetShortestPath(string Node1, string Node2)
    {
      UnvisitedListManager unvisitedNodes = new UnvisitedListManager();
      unvisitedNodes.Add(Node1, 0);
      Dictionary<string, Path> workingSet = InitialiseWorkingSet(Node1);
      string currNode;

      while ((currNode = unvisitedNodes.Next()) != null)
      {
        if (nodes.ContainsKey(currNode))
        {
          foreach (string nextNode in nodes[currNode].Keys)
          {
            //check if shortest distance from the origin to this node 
            //added to
            //the distance to the next node
            //is shorter than
            //the known distance from the origin the the next node
            if (workingSet[currNode].distance + nodes[currNode][nextNode] < workingSet[nextNode].distance)
            {
              //update the route distance to the next node with this known shorter route distance
              float newDistance = workingSet[currNode].distance + nodes[currNode][nextNode];
              workingSet[nextNode].distance = newDistance;

              //update the route path to be this nodes path plus the edge to the next node
              workingSet[nextNode].path = new List<string>(workingSet[currNode].path);
              workingSet[nextNode].path.Add(nextNode);
              unvisitedNodes.Add(nextNode, newDistance);
            }
          }
        }
      }
      return workingSet[Node2];
    }

    //Initalises the main data structure needed to process the algorithm
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
  }
}