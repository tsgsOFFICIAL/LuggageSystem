using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class Reservation
    {
        public DateTime ReservationTime { get; private set; }
        public Reservation()
        {
            ReservationTime = DateTime.Now;
        }
    }
}
