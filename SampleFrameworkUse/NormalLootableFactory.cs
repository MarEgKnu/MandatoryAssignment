using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    /// <summary>
    /// Creates loot objects for normal difficulty
    /// </summary>
    public class NormalLootableFactory : IWorldObjectFactory
    {
        public IWorldObject CreateObject(Coordinate position)
        {
            IWorldItem container = new SampleContainer("Loot Container", new List<IWorldItem>() { new BasicDefenceArmor("Basic Armor"), new BasicDefenceArmor("Basic Sword") }, new HashSet<PositiveInt>());
            return new SampleLootChest("Normal Loot Chest", container, position); 
        }
    }
}
