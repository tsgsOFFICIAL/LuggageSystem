using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class FlightPlan
    {
        public enum Flight
        {
            CPH = 147,
            USA = 255,
            UK = 112,
            SWE = 911,
            DE = 992,
            PL = 045,
            EG = 747
        }
        public int GateNumber { get; private set; }
        public Flight FlightDestination { get; private set; }
    }
}
