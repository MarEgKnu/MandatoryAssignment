using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// An interface for factories creating IWorldObjects
    /// </summary>
    public interface IWorldObjectFactory
    {
        /// <summary>
        /// Creates and returns a new IWorldObject at the specific position depending on its implmenation
        /// </summary>
        /// <param name="position">The position the object should be placed at</param>
        /// <returns>The created IWorldObject object</returns>
        IWorldObject CreateObject(Coordinate position);
    }
}
