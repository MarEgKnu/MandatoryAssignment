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
        DamageReduction BaseDamageReduction { get; }
        PositiveInt ID { get; }
        string Name { get; set; }

        Coordinate Position { get; set; }
        
        IWorldItem Inventory { get; set; }

        PositiveInt HitPoints { get; }


        PositiveInt Hit();

        void ReceiveHit(PositiveInt hitPoints);


        void Loot(ILootable obj);
    }
}
