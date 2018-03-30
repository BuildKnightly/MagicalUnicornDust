using CampusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusAPI.DataStore
{
    public interface ICampusCache
    {
        CampusMap GetCampusMap(string Campus);
        void SetCampusMap(string Campus, CampusMap CampusMap);
    }
}
