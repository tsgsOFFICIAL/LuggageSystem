using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

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
        //private static List<List<Luggage>> Buffers = new List<List<Luggage>>(); // Every buffer
        //private static List<Buffer> Buffers = new List<Buffer>();
        private static List<Luggage> Buffer = new List<Luggage>();
        private static List<string> LuggageList = new List<string>(); // Luggage files
        private static DBConnection DBConnection = new DBConnection("127.0.0.1", "AirportManagerBoss", "password", "FlightSim"); // Database Connection with arguments
        private bool ProduceLuggage; // Produce luggage
        public event EventHandler<DateTime> TimeChanged;
        public event EventHandler<List<Luggage>> LuggageCreated;
        public event EventHandler<CheckInBooth> LuggageMoved;
        public bool RunCheckIns { get; set; } // Run boolean
        #endregion
        /// <summary>
        /// Returns a new instance of the AirportManager class
        /// </summary>
        public AirportManager()
        {
            new Thread(InitializeManager).Start(); // Initialize a new thread and start it, without saving its reference, since we never need it again.
            new Thread(LuggageProducer).Start();
            new Thread(Clock).Start();
            new Thread(CheckLuggageIn).Start();
        }
        /// <summary>
        /// Check the luggage in at the open check in booths
        /// </summary>
        private void CheckLuggageIn()
        {
            int currentBooth = 0;
            while (true)
            {
                try
                {
                    if (Buffer.Count > 0) // Check if there is anything in the buffer
                    {
                        //Monitor.Enter(Buffers[0]);
                        // If the booth is open
                        if (CheckIns[currentBooth].State.Equals(IOpenClosed.State.Open))
                        {
                            CheckIns[currentBooth].Buffer.Add(Buffer[Buffer.Count - 1]); // Move the luggage from Buffers[0] to the current Buffer
                            Buffer.RemoveAt(Buffer.Count - 1); // Then remove it from the original buffers[0]

                            LuggageMoved?.Invoke(this, CheckIns[currentBooth]); // Invoke the event
                            LuggageCreated?.Invoke(this, Buffer);
                        }
                    }
                }
                catch (Exception)
                {
                    //Monitor.Wait(Buffers[0]);
                }
                finally
                {
                    //Monitor.PulseAll(Buffers[0]);
                    //Monitor.Exit(Buffers[0]);
                    // Up one
                    if (currentBooth + 1 == 8)
                    {
                        currentBooth = 0;
                    }
                    else
                    {
                        currentBooth++;
                    }
                }
                Thread.Sleep(250);
                Debug.WriteLine(currentBooth);
            }
        }
        /// <summary>
        /// Check if any of the booths are open
        /// </summary>
        /// <returns>This method returns true if any of the booths are open, otherwise returns false.</returns>
        private bool CheckForOpenBooths()
        {
            bool areAnyOpen = false;

            foreach (CheckInBooth checkInBooth in CheckIns)
            {
                if (checkInBooth.State.Equals(IOpenClosed.State.Open))
                    areAnyOpen = true;
            }

            return areAnyOpen;
        }
        private void Clock()
        {
            DateTime now = DateTime.Now;
            while (true)
            {
                if (now.AddMinutes(1).Minute <= DateTime.Now.Minute)
                {
                    now = DateTime.Now;
                    TimeChanged?.Invoke(this, DateTime.Now);
                }
                Thread.Sleep(200);
            }
        }
        /// <summary>
        /// Produces Luggage
        /// </summary>
        private void LuggageProducer()
        {
            while (true)
            {
                while (ProduceLuggage)
                {
                    Thread.Sleep(500);
                    Buffer.Add(new Luggage(GenerateFlightLocation()));
                    LuggageCreated?.Invoke(this, Buffer);
                }
            }
        }
        /// <summary>
        /// Open the luggage producer
        /// </summary>
        public void OpenLuggageProducer()
        {
            ProduceLuggage = true;
        }
        /// <summary>
        /// Close the luggage producer
        /// </summary>
        public void CloseLuggageProducer()
        {
            ProduceLuggage = false;
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
        }
        /// <summary>
        /// Ghetto Event Handling lmfao
        /// </summary>
        /// <param name="state"></param>
        /// <param name="number"></param>
        public void ChangeCheckInState(IOpenClosed.State state, int number)
        {
            switch (state)
            {
                case IOpenClosed.State.Open:
                    CheckIns[number].Open();
                    break;
                case IOpenClosed.State.Closed:
                    CheckIns[number].Close();
                    break;
            }
        }
        /// <summary>
        /// Ghetto Event Handling lmfao
        /// </summary>
        /// <param name="state"></param>
        /// <param name="number"></param>
        public void ChangeTerminalState(IOpenClosed.State state, int number)
        {
            switch (state)
            {
                case IOpenClosed.State.Open:
                    Terminals[number].Open();
                    break;
                case IOpenClosed.State.Closed:
                    Terminals[number].Close();
                    break;
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
        private FlightPlan.Flight GenerateFlightLocation()
        {
            FlightPlan.Flight[] flights = (FlightPlan.Flight[])Enum.GetValues(typeof(FlightPlan.Flight));
            int randomIndex = new Random().Next(0, flights.Length);

            return flights[randomIndex];
            // This seemingly advanced one-liner is actually pretty simple, starting from the back, it generates a random number from 0, to max length of the enum Flight and uses it to find the appropriate name
            // From that enum, and then using that name to get the value (not the index) of said enum, to the cast it all back to a Flight.
            //return (FlightPlan.Flight)Enum.Parse(typeof(FlightPlan.Flight), Enum.GetName(typeof(FlightPlan.Flight), new Random().Next(0, Enum.GetNames(typeof(FlightPlan.Flight)).Length)));
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