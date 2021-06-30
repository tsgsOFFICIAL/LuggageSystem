using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    /// <summary>
    /// This class i used to send event arguments around the application<br/>
    /// This event's arguments is used for every terminal and its properties.
    /// </summary>
    public class TerminalEventArgs : EventArgs
    {
        public Terminal Terminal { get; private set; }
        public List<Luggage> LuggageList { get; set; }
        public TerminalEventArgs(Terminal terminal, List<Luggage> luggageList)
        {
            Terminal = terminal;
            LuggageList = luggageList;
        }
    }
}