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
        public bool Run { get; set; }
        public IOpenClosed.State State { get; private set; }
        #endregion
        public CheckInBooth()
        {
            Run = true;
            State = IOpenClosed.State.Closed;
            new Thread(RunThread).Start(); // Initialize a new thread and start it.
        }
        // Methods
        private void RunThread()
        {
            //while (true)
            //{
            //    while (Run)
            //    {
            //        Thread.Sleep(250);
            //    }
            //}
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