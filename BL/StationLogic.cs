using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StationLogic //true is empty
    {
        DBAirport db = new DBAirport();
        LocationsModel location = new LocationsModel();

        public bool EnterNextStation(bool[] statusStations,int currentStation, int stations)
        {
            statusStations[currentStation] = false;

            int nextStation = currentStation + 1;

            //if (nextStation > stations) return false;
            
            if (statusStations[nextStation])
            {
                statusStations[currentStation] = true;
                statusStations[nextStation] = false;
                return true;
            }
            return false;
        }                  
    }
}
