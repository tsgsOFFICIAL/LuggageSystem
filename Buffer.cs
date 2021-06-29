using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class Buffer
    {
        public List<Luggage> LuggageList { get; set; }
        public Buffer(List<Luggage> luggageList)
        {
            LuggageList = luggageList;
        }
    }
}
