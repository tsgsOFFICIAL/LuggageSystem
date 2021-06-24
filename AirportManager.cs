using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Luggage[] Buffers = new Luggage[7];
        private List<string> LuggageList = new List<string>();
        private DBConnection DBConnection = new DBConnection("127.0.0.1", "AirportManagerBoss", "password", "FlightSim");
        /// <summary>
        /// Airport Manager Class
        /// </summary>
        public AirportManager()
        {
            new Thread(InitializeManager).Start(); // Initialize a new thread and start it, without saving its reference, since we never need it again.
        }
        /// <summary>
        /// Initialize Airport Manager
        /// </summary>
        private void InitializeManager()
        {
            DBConnection.Open();
            LuggageList = GetLuggageFiles();
            
            // While true loop to keep the thread alive forever
            while (true)
            {

            }
        }
        /// <summary>
        /// Get luggagefiles / images
        /// </summary>
        /// <returns>This method returns a list of strings containing the luggages file name & extension</returns>
        private List<string> GetLuggageFiles()
        {
            List<string> luggageList = new List<string>();
            
            foreach (string file in Directory.GetFiles("assets/luggage/"))
            {
                luggageList.Add(file.Substring(15));
            }

            return luggageList;
        }
    }
}
