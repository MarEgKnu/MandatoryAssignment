using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a object in which an entity can attempt to walk to it.
    /// </summary>
    public interface IWalkable
    {
        /// <summary>
        /// Tests if the specified entity is allowed to walk on this object
        /// </summary>
        /// <param name="walker">The entity trying to walk on this object</param>
        /// <returns>True if can walk, false if not</returns>
        bool CanWalk(IWorldEntity walker);

        /// <summary>
        /// Attempts to walk on this object as the "walker" entity. If not allowed, will fail.
        /// </summary>
        /// <param name="walker">The entity trying to walk on this object</param>
        void TryWalk(IWorldEntity walker);
    }
}
