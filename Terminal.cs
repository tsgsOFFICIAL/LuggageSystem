using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class Terminal : IClose, IOpen
    {
        public enum OpenClosedState
        {
            Open,
            Closed
        }
        public int LuggageNumber { get; private set; }
        public DateTime Timestamp { get; private set; }
        public OpenClosedState State { get; private set; }
        public void Open()
        {
            State = OpenClosedState.Open;
        }
        public void Close()
        {
            State = OpenClosedState.Closed;
        }
    }
}
