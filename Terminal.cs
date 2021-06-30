using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuggageSystem
{
    /// <summary>
    /// The terminal is the final state for the luggage, before going somewhere else.
    /// </summary>
    public class Terminal : IClose, IOpen, IOpenClosed
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
        /// <summary>
        /// 
        /// </summary>
        public Terminal()
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
            //while (Run)
            //{
            //    while (State.Equals(IOpenClosed.State.Open))
            //    {

            //    }
            //    Thread.Sleep(250);
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