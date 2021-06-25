using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    /// <summary>
    /// This interface holds an enum containing Open & Closed state
    /// </summary>
    public interface IOpenClosed
    {
        /// <summary>
        /// Open Or Closed State
        /// </summary>
        public enum State
        {
            Open,
            Closed
        }
    }
}
