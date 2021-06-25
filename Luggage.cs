using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
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
        /// The unique number
        /// </summary>
        public int LuggageNumber { get; private set; }
        /// <summary>
        /// The unique luggage id
        /// </summary>
        public static int Id { get; private set; }
        /// <summary>
        /// Creates an instance of Luggage
        /// </summary>
        /// <param name="Flight">Which flight will the luggage go on</param>
        /// <param name="LuggageNumber">What is the luggage number</param>
        public Luggage(FlightPlan.Flight Flight, int LuggageNumber)
        {
            this.Flight = Flight;
            this.LuggageNumber = LuggageNumber;
            Id++;
        }
    }
}
