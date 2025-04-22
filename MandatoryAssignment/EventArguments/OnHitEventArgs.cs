using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.EventArguments
{
    public class OnHitEventArgs : EventArgs
    {
        public OnHitEventArgs(PositiveInt damageTaken) : base()
        {
            DamageTaken = damageTaken;
        }
        public PositiveInt DamageTaken { get; }
    }
}
