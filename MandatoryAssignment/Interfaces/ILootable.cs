using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a object which can be looted by an entity from the world.
    /// </summary>
    public interface ILootable
    {
        IWorldItem Loot {  get; }

        /// <summary>
        /// Loots the items in the object to the looter. May have side effects.
        /// </summary>
        /// <param name="looter">The IWorldEntity looting the object</param>
        void LootItems(IWorldEntity looter);




    }
}
