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
    /// <summary>
    /// Airport Manager Class
    /// </summary>
    public class AirportManager
    {
        // Attributes
        private List<CheckInBooth> CheckIns = new List<CheckInBooth>();
        private List<Terminal> Terminals = new List<Terminal>();
        private List<List<Luggage>> Buffers = new List<List<Luggage>>();
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
            
            // Generate CheckInBooths
            for (int i = 0; i < 8; i++)
            {
                CheckIns.Add(new CheckInBooth());
            }
            
            // Generate Terminals
            for (int i = 0; i < 7; i++)
            {
                Terminals.Add(new Terminal());
            }

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
