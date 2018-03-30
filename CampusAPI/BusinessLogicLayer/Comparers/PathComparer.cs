using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAPI.BusinessLogicLayer.Comparers
{
  public class PathComparer<T> : IComparer<T>
  {
    private readonly Comparison<T> comparison;
    public PathComparer(Comparison<T> comparison)
    {
      this.comparison = comparison;
    }
 
    public int Compare(T x, T y)
    {
      return comparison(x, y);
    }
  }
}