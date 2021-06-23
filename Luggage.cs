using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class Luggage
    {
        public FlightPlan.Flight Flight { get; private set; }
        public int LuggageNumber { get; private set; }
        public static int Id { get; private set; }

        public Luggage(FlightPlan.Flight Flight, int LuggageNumber)
        {
            this.Flight = Flight;
            this.LuggageNumber = LuggageNumber;
            Id++;
        }
    }
}
