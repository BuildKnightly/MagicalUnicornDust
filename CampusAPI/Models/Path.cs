﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAPI.Models
{
  public class Path
  {
    public float distance = float.PositiveInfinity;
    public List<string> path = new List<string>();
  }
}