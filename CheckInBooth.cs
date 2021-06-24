using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class CheckInBooth : IClose, IOpen
    {
        // Properties
        public Thread Thread { get; private set; }
        public enum OpenClosedState
        {
            Open,
            Closed
        }
        public int PassengerNumber { get; private set; }
        public int LuggageNumber { get; private set; }
        public DateTime Timestamp { get; private set; }
        public OpenClosedState State { get; private set; }
        public CheckInBooth()
        {
            Thread = new Thread(RunThread); // Initialize a new thread and start it.
            Thread.Start();
        }
        // Methods
        private void RunThread()
        {

        }
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
