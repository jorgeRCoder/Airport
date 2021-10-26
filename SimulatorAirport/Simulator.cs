using BL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimulatorAirport
{
    public class Simulator
    {
        Random ran = new Random();
        StationLogic move = new StationLogic();
        public int[] landingStations = new int[] { 1, 2, 3 , 4, 5 };
        public int[] takeOffStations = new int[] { 6,7, 8, 4 };//{ 6, 7, 8, 4 };

        public Simulator()
        {
            FlightModel flightNum = new FlightModel();
            PlaneModel planeM = new PlaneModel();
            
            flightNum.FlightNumber = ran.Next(1, 1000);
            planeM.Model = ran.Next(1, 1000);
        }

        public bool continueLanding(bool[] statusStations,int currentStation)
        {
            return move.EnterNextStation(statusStations,currentStation, landingStations.Length);           
        }

        public bool Takeoff(bool[] statusStations, int currentStation)
        {
            return move.EnterNextStation(statusStations, currentStation, takeOffStations.Length);
        }
    }
}
