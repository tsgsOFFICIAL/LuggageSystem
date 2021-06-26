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
        private List<CheckInBooth> CheckIns = new List<CheckInBooth>(); // Every check in booth
        private List<Terminal> Terminals = new List<Terminal>(); // Every terminal
        private List<List<Luggage>> Buffers = new List<List<Luggage>>(); // Every buffer
        private List<string> LuggageList = new List<string>(); // Luggage files
        private DBConnection DBConnection = new DBConnection("127.0.0.1", "AirportManagerBoss", "password", "FlightSim"); // Database Connection with arguments
        private bool Run; // Run boolean
        public event EventHandler CheckInBoothStateChanged; // Event for statechanged on the check in booth
        public event EventHandler TerminalStateChanged; // Event for statechanged on the check in booth
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
            DBConnection.Open(); // Open the connection to the database
            LuggageList = GetLuggageFiles(); // Call GetLuggageFiles() and return a List<string>
            GenerateCheckIns(); // Generate check ins
            GenerateTerminals(); // Generate terminals
            Run = true; // Set run == true, to make it run

            while (Run)
            {
                Thread.Sleep(50);
            }

            // Abort / Kill all threads
        }
        /// <summary>
        /// 
        /// </summary>
        private void ReadCheckInBoothState()
        {
            IOpenClosed.State State0 = CheckIns[0].State;
            IOpenClosed.State State1 = CheckIns[1].State;
            IOpenClosed.State State2 = CheckIns[2].State;
            IOpenClosed.State State3 = CheckIns[3].State;
            IOpenClosed.State State4 = CheckIns[4].State;
            IOpenClosed.State State5 = CheckIns[5].State;
            IOpenClosed.State State6 = CheckIns[6].State;
            IOpenClosed.State State7 = CheckIns[7].State;

            while (true)
            {
                if (State0 != CheckIns[0].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[0].State, 0));
                if (State1 != CheckIns[1].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[1].State, 1));
                if (State2 != CheckIns[2].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[2].State, 2));
                if (State3 != CheckIns[3].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[3].State, 3));
                if (State4 != CheckIns[4].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[4].State, 4));
                if (State5 != CheckIns[5].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[5].State, 5));
                if (State6 != CheckIns[6].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[6].State, 6));
                if (State7 != CheckIns[7].State)
                    CheckInBoothStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[7].State, 7));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void ReadTerminalState()
        {
            //TerminalStateChanged?.Invoke(this, new CheckInBoothEventArgs(CheckIns[i].State));
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
                // Starts a thread that runs in the background
                new Thread(ReadCheckInBoothState).Start();
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
                // Starts a thread that runs in the background
                new Thread(ReadTerminalState).Start();
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