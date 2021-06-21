using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LuggageSystem
{
    public class AirportManager
    {
        private CheckInBooth[] CheckIns = new CheckInBooth[8];
        private Terminal[] Terminals = new Terminal[7];
        private DBConnection DBConnection = new DBConnection("127.0.0.1", "AirportManagerBoss", "password", "FlightSim");

        public AirportManager()
        {
            DBConnection.Open();
        }
    }
}
