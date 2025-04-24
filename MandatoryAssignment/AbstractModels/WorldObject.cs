using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class WorldObject : IWorldObject
    {
        public WorldObject(string name, IWorldItem loot, Coordinate position, PositiveInt? id = null)
        {
            Name = name;
            Loot = loot;
            Position = position;
            if(id is null)
            {
                ID = GenerateNextUniqueID();
            }
            else
            {
                ID = id.Value;
            }
            

        }
        protected static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        public PositiveInt ID { get; }
        public string Name { get; }

        public IWorldItem Loot { get; protected set; }

        public Coordinate Position {  get; }

        protected virtual PositiveInt GenerateNextUniqueID()
        {
            while(true)
            {
                int id = _rng.Next(1, int.MaxValue);
                if(GameState.CurrentState.World.WorldObjects.Read(id) is null)
                {
                    return id;
                }
            }
            
        }

        public virtual void LootItems(IWorldEntity looter)
        {
            if(Loot is null) { return; }
            if (looter.Inventory != null && looter.Inventory is ContainerItem looterInv)
            {

                looterInv.Take(Loot, looter);

            }
            else
            {
                looter.Inventory = Loot;
                Loot = null;
            }
        }

        public abstract bool TryRemove(IWorldItem item);

        public abstract bool CanWalk(IWorldEntity walker);

    }
}
