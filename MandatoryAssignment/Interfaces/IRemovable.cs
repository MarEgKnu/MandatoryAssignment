using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a object which can be removed from the world.
    /// </summary>
    public interface IRemovable
    {
        /// <summary>
        /// Tries to remove the given object with the given IWorldItem, may fail or suceed. May have side effects.
        /// </summary>
        /// <param name="item">The IWorldItem used to try to remove the object with</param>
        /// <returns>True if sucessfully removed, false if not</returns>
        bool TryRemove(IWorldItem item);
        bool Removable { get {  return true; } }
    }
}
