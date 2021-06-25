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
    public class TerminalEventArgs : EventArgs, IOpenClosed
    {
        public IOpenClosed.State State { get; private set; }
        public TerminalEventArgs(/**/)
        {

        }
    }
}
