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
        #region Attributes
        private List<CheckInBooth> CheckIns = new List<CheckInBooth>();
        private List<Terminal> Terminals = new List<Terminal>();
        private List<List<Luggage>> Buffers = new List<List<Luggage>>();
        private List<string> LuggageList = new List<string>();
        private DBConnection DBConnection = new DBConnection("127.0.0.1", "AirportManagerBoss", "password", "FlightSim");
        private bool Run;
        #endregion
        /// <summary>
        /// Returns a new instance of the AirportManager class
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
            GenerateCheckIns();
            GenerateTerminals();
            Run = true;

            // While true loop to keep the thread alive forever
            while (Run)
            {
                Thread.Sleep(50);
            }
        }
        /// <summary>
        /// Generate x amount of Check Ins
        /// </summary>
        /// <param name="amount">Amount to generate<br/>it defaults to 8.</param>
        private void GenerateCheckIns(int amount = 8)
        {
            for (int i = 0; i < amount; i++)
            {
                CheckIns.Add(new CheckInBooth());
            }
        }
        /// <summary>
        /// Generate x amount of Terminals
        /// </summary>
        /// <param name="amount">Amount to generate<br/>it defaults to 8.</param>
        private void GenerateTerminals(int amount = 7)
        {
            for (int i = 0; i < amount; i++)
            {
                Terminals.Add(new Terminal());
            }
        }
        /// <summary>
        /// Get luggagefiles / images
        /// </summary>
        /// <returns>This method returns a List&lt;string&gt;<br/>
        /// containing the file names and extensions.</returns>
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