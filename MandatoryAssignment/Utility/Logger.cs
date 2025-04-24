using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Utility
{
    /// <summary>
    /// A class representing a logger for the game state
    /// </summary>
    public class Logger
    {
        public Logger(TraceSource ts)
        {
            _traceSource = ts;
        }
        protected TraceSource _traceSource;
        /// <summary>
        /// Adds the given listener to the logger
        /// </summary>
        /// <param name="traceListener">The listener to add</param>
        public void AddListener(TraceListener traceListener)
        {
            _traceSource.Listeners.Add(traceListener);
        }
        /// <summary>
        /// Removes the given listener by reference type
        /// </summary>
        /// <param name="traceListener">The listener to remove</param>
        public void RemoveListener(TraceListener traceListener)
        {
            _traceSource.Listeners.Remove(traceListener);
        }
        /// <summary>
        /// Removes the fist occourence of a listener with the specified name
        /// </summary>
        /// <param name="name">The name to remove a listener by</param>
        public void RemoveListener(string name)
        {
            _traceSource.Listeners.Remove(name);
        }
        /// <summary>
        /// Sets the Source Switch for the logger
        /// </summary>
        /// <param name="sw">The source switch to set</param>
        public void SetSourceSwitch(SourceSwitch sw)
        {
            _traceSource.Switch = sw;
        }
        /// <summary>
        /// Traces a event and notifies all added tracelisteners if the TraceSource and source switch is configured to include them.
        /// </summary>
        /// <param name="type">The type of event</param>
        /// <param name="id">The ID of the program or entity causing the event</param>
        /// <param name="message">The message of the event</param>
        public virtual void TraceEvent(TraceEventType type, int id, string message)
        {
            _traceSource.TraceEvent(type, id, message);
            _traceSource.Flush();
        }
    }
}
