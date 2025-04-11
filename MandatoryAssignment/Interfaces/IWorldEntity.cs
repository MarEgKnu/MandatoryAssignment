using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface representing a World Entity, such as a creature/enemy
    /// </summary>
    public interface IWorldEntity
    {
        PositiveInt ID { get; }
        string Name { get; set; }

        Coordinate Position { get; set; }
        
        IWorldItem Inventory { get; set; }

        PositiveInt HitPoints { get; }

        PositiveInt Hit();

        PositiveInt HitWithItem(IWorldItem item);

        void ReceiveHit(int hitPoints);

        void Loot(ILootable obj);
    }
}
