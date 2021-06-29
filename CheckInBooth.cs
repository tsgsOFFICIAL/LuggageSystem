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
        public List<Luggage> Buffer { get; set; } = new List<Luggage>();
        public IOpenClosed.State State { get; private set; }
        /// <summary>
        /// The unique id
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Total Counter
        /// </summary>
        public int Counter { get; private set; }
        /// <summary>
        /// Static
        /// </summary>
        private static int _Counter;
        #endregion
        public CheckInBooth()
        {
            Run = true;
            State = IOpenClosed.State.Closed;
            new Thread(RunThread).Start(); // Initialize a new thread and start it.

            _Counter++;
            Counter = _Counter;
            Id = _Counter - 1;
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