using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a manager which handles movement of entities
    /// </summary>
    public interface IMovementManager
    {
        /// <summary>
        /// Tries to moves the entity to the specified coordinates. May fail due to varius factors such as collision. The result is detailed in the returned IMoveResult
        /// </summary>
        /// <param name="newX">The new x position to move to</param>
        /// <param name="newY">The new y position to move to</param>
        /// <param name="world">The injected world object</param>
        /// <param name="entity">The entity trying to move</param>
        IMoveResult TryMoveEntity(IWorldEntity entity, int newX, int newY, IWorld world);
    }
}
