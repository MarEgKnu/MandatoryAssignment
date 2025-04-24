using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.EventArguments
{
    /// <summary>
    /// Event arguments for On-Hit events where the damage dealt is passed
    /// </summary>
    public class OnHitEventArgs : EventArgs
    {
        public OnHitEventArgs(PositiveInt damageTaken) : base()
        {
            DamageTaken = damageTaken;
        }
        /// <summary>
        /// The damage taken
        /// </summary>
        public PositiveInt DamageTaken { get; }
    }
}
