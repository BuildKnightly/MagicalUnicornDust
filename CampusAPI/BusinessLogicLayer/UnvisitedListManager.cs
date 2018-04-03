using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusAPI.BusinessLogicLayer
{
  //UnvisitedList will only process a node once and will ignore any further attemps to add it
  internal class UnvisitedListManager
  {
    private List<string> knownNodes = new List<string>();
    private Dictionary<string, float> nodesToProcess = new Dictionary<string, float>();

    //Add an Node for processing,
    //will also update an unprocessed node if the distance changes
    internal void Add(string nodeId, float distance)
    {
      if (!knownNodes.Contains(nodeId))
      {
        //new unvisited node
        knownNodes.Add(nodeId);
        nodesToProcess.Add(nodeId, distance);
      }
      else if (nodesToProcess.ContainsKey(nodeId))
      {
        //node awaiting processing, and it's distance to origin has been updated
        nodesToProcess[nodeId] = distance;
      }
    }

    //Find the next closest node to process
    internal string Next()
    {
      float currDistance = float.PositiveInfinity;
      string nextNode = null;
      foreach (string nodeId in nodesToProcess.Keys)
      {
        if (currDistance > nodesToProcess[nodeId])
        {
          currDistance = nodesToProcess[nodeId];
          nextNode = nodeId;
        }
      }
      if (nextNode != null)
      {
        nodesToProcess.Remove(nextNode);
      }
      return nextNode;
    }
  }
}
