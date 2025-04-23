using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for differing strategies on handling and modifying damage taken
    /// </summary>
    public interface IReceiveHitStrategy
    {
        /// <summary>
        /// Processes the incoming damage taken according to the stategy, and returns the result.
        /// </summary>
        /// <param name="incomingDmg">The incoming damage</param>
        /// <param name="receiver">The entity receiving the damage</param>
        /// <returns></returns>
        PositiveInt ComputeDamage(PositiveInt incomingDmg, IWorldEntity receiver);
    }
}
