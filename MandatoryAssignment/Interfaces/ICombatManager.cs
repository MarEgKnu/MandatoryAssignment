using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a combat manager for the game
    /// </summary>
    public interface ICombatManager
    {
        /// <summary>
        /// Tries to initiate combat with an entity with the given ID
        /// </summary>
        /// <param name="initiator">The entity initiating combat</param>
        /// <param name="entityID">The entity with this ID being attacked</param>
        /// <param name="world">Injected world dependency</param>
        IFightResult TryFight(IWorldEntity initiator, PositiveInt entityID, IWorld world);
        /// <summary>
        /// Tries to initiate combat with an entity at the given coordinate
        /// </summary>
        /// <param name="initiator">The entity initiating combat</param>
        /// <param name="x">The x position which we are trying to initiate combat against</param>
        /// <param name="y">The y position which we are trying to initiate combat against</param>
        /// <param name="world">Injected world dependency</param>
        /// <returns></returns>
        IFightResult TryFight(IWorldEntity initiator, int x, int y, IWorld world);
    }
}
