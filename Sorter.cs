using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    /// <summary>
    /// Sorter class
    /// </summary>
    public class Sorter
    {
        public List<Luggage> BufferIn { get; set; } = new List<Luggage>();
        public List<Luggage> BufferOut { get; set; } = new List<Luggage>();
        public Sorter()
        {

        }
    }
}
