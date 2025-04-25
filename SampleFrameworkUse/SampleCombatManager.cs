using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class SampleCombatManager : ICombatManager
    {
        public IFightResult TryFight(IWorldEntity initiator, PositiveInt entityID, IWorld world)
        {
            IWorldEntity? target = world.WorldEntities.Read(entityID);
            if(target == null)
            {
                return new FightResult(false, "No entity with such ID exists", false);
            }
            else if(initiator.Position.IsInRange(target.Position, 1))
            {
                bool isAlive = target.ReceiveHit(initiator.Hit());
                if(!isAlive)
                {
                    return new FightResult(true, "Sucessfully delevered damage to entity and was killed", true);
                }
                return new FightResult(true, "Sucessfully delevered damage to entity", false);
            }
            else
            {
                return new FightResult(false, "Not in range to attack", false);
            }
        }

        public IFightResult TryFight(IWorldEntity initiator, int x, int y, IWorld world)
        {
            if(x < 0 || y < 0)
            {
                return new FightResult(false, "Coordinates out of bounds", false);
            }
            Coordinate position = new Coordinate(x, y);
            IWorldEntity? target = world.WorldEntities.Read(position);
            if (target == null)
            {
                return new FightResult(false, "No entity at those coords exist", false);
            }
            else if (initiator.Position.IsInRange(target.Position, 1))
            {
                bool isAlive = target.ReceiveHit(initiator.Hit());
                if (!isAlive)
                {
                    return new FightResult(true, "Sucessfully delevered damage to entity and was killed", true);
                }
                return new FightResult(true, "Sucessfully delevered damage to entity", false);
            }
            else
            {
                return new FightResult(false, "Not in range to attack", false);
            }
        }
    }
}
