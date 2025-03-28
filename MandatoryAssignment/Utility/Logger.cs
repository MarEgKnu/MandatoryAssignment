using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Utility
{
    public class Logger
    {
        public Logger(TraceSource ts)
        {
            _traceSource = ts;
        }
        protected TraceSource _traceSource;

        public void AddListener(TraceListener traceListener)
        {
            _traceSource.Listeners.Add(traceListener);
        }

        public virtual void TraceEvent(TraceEventType type, int id, string message)
        {
            _traceSource.TraceEvent(type, id, message);
            _traceSource.Flush();
        }
    }
}
