using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Utility
{
    public abstract class Logger
    {
        protected Logger(TraceSource ts)
        {
            TraceSource = ts;
        }
        protected TraceSource TraceSource { get; }

        public virtual void TraceEvent(TraceEventType type, int id, string message)
        {
            TraceSource.TraceEvent(type, id, message);
            TraceSource.Flush();
        }
    }
}
