using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// A interface representing the ingame grid. The grid coordinates should not be allowed to be negative
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// Returns the IWorldObject at the current coordinate in the game world. Returns null if none found.
        /// 
        /// </summary>
        /// <param name="coords">The coordinate specifiying where to check</param>
        /// <returns>The IWorldObject if one exists, or null if none</returns>
        IWorldObject? GetObjectAtCoordinate(Coordinate coords); 

        /// <summary>
        /// The max X coordiate of the grid
        /// </summary>
        uint MaxY { get; }
        /// <summary>
        /// The max Y coordiate of the grid
        /// </summary>
        uint MaxX { get; }
    }
}
