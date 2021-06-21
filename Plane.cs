using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class Plane
    {
        public uint BaggageLimit { get; private set; }
        public Plane(uint BaggageLimit)
        {
            this.BaggageLimit = BaggageLimit;
        }
    }
}
