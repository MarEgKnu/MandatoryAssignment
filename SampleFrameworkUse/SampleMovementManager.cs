using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Models;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    /// <summary>
    /// A example of what a movement manager could look like when implemented
    /// </summary>
    public class SampleMovementManager : IMovementManager
    {
        public IMoveResult TryMoveEntity(IWorldEntity entity, int newX, int newY, IWorld world)
        {
            if (newY > world.MaxY || newX > world.MaxX || newY < 0 || newX < 0)
            {
                return new MoveResult(false, "Position out of bounds");
            }
            Coordinate newPos = new Coordinate(newX, newY);
            if (world.WorldEntities.Read(newPos) != null)
            {
                return new MoveResult(false, "Another entity is blocking the position");
            }
            IWorldObject? collidingObj = world.WorldObjects.Read(newPos);
            if (collidingObj != null)
            {
                if (!collidingObj.CanWalk(entity))
                {
                    return new MoveResult(false, "A non-walkable object is blocking the position");
                }
            }
            if (world.WorldEntities.Read(newPos) is null)
            {
                world.WorldEntities.Delete(entity.Position);
                entity.Position = newPos;
                world.WorldEntities.Add(entity);
                return new MoveResult(true, "Sucessfully walked to the destination");
            }
            else
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Error, 0, $"Entity {{{this}}} was not found in the entity repository when trying to move!");
                return new MoveResult(false, "Entity cannot be located in the entity repository");
            }
        }
    }
}
