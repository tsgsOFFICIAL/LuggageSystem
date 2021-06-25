using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class CheckInBooth : IClose, IOpen, IOpenClosed
    {
        #region Properties
        public Thread Thread { get; private set; }
        public IOpenClosed.State State { get; private set; }
        #endregion
        public CheckInBooth()
        {
            State = IOpenClosed.State.Closed;
            Thread = new Thread(RunThread); // Initialize a new thread and start it.
            Thread.Start();
        }
        // Methods
        private void RunThread()
        {
            // While true loop to keep the thread alive forever
            while (true)
            {
                Thread.Sleep(250);
            }
        }
        public void Open()
        {
            State = IOpenClosed.State.Open;
        }
        public void Close()
        {
            State = IOpenClosed.State.Closed;
        }
    }
}
