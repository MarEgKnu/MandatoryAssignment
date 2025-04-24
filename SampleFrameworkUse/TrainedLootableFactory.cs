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
    /// Creates loot objects for trained difficulty
    /// </summary>
    public class TrainedLootableFactory : IWorldObjectFactory
    {
        public IWorldObject CreateObject(Coordinate position)
        {
            IWorldItem container = new SampleContainer("Loot Container", new List<IWorldItem>() { new BasicSword("Basic Sword")  }, new HashSet<PositiveInt>());
            return new SampleLootChest("Trained Loot Chest", container, position);
        }
    }
}
