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
        /// The unique luggage id
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Total Counter
        /// </summary>
        public int Counter { get; private set; }
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
        }
    }
}