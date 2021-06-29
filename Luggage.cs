using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    /// <summary>
    /// TimesStamp class
    /// </summary>
    public class TimeStamp
    {
        /// <summary>
        /// Time
        /// </summary>
        public DateTime Time { get; private set; }
        /// <summary>
        /// Location
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// Creates an instance of the TimeStamp class
        /// </summary>
        public TimeStamp(DateTime Time, string Location)
        {
            this.Time = Time;
            this.Location = Location;
        }
    }
    /// <summary>
    /// Luggage class
    /// </summary>
    public class Luggage
    {
        /// <summary>
        /// Which flight will the Luggage take
        /// </summary>
        public FlightPlan.Flight Flight { get; private set; }
        /// <summary>
        /// The unique luggage id
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Total Counter
        /// </summary>
        public int Counter { get; private set; }
        /// <summary>
        /// Timestamps and locations
        /// </summary>
        public List<TimeStamp> TimeStamps { get; private set; } = new List<TimeStamp>();
        /// <summary>
        /// Static
        /// </summary>
        private static int _Counter;
        /// <summary>
        /// Creates an instance of Luggage
        /// </summary>
        /// <param name="Flight">Which flight will the luggage go on</param>
        /// <param name="LuggageNumber">What is the luggage number</param>
        public Luggage(FlightPlan.Flight Flight)
        {
            this.Flight = Flight;
            _Counter++;
            Counter = _Counter;
            Id = _Counter - 1;
            TimeStamps.Add(new TimeStamp(DateTime.Now, "Entrance"));
        }
        /// <summary>
        /// Add a timestamp to the luggage
        /// </summary>
        /// <param name="Time">The time</param>
        /// <param name="Location">Where is the luggage now</param>
        public void AddTimeStamp(DateTime Time, string Location)
        {
            TimeStamps.Add(new TimeStamp(Time, Location));
        }
    }
}