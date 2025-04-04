using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public class WorldObject : IWorldObject
    {
        public WorldObject(string name, bool lootable, bool removable, bool walkable)
        {
            Name = name;
            Lootable = lootable;
            Removable = removable;
            Walkable = walkable;
            ID = GenerateNextUniqueID();

        }
        protected static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        public uint ID { get; }
        public string Name { get; }

        public bool Lootable { get; }

        public bool Removable { get; }

        public bool Walkable { get; }

        protected virtual uint GenerateNextUniqueID()
        {
            while(true)
            {
                uint id = (uint)_rng.Next(1, int.MaxValue);
                if(GameState.CurrentState.World.WorldObjects.Read(id) is null)
                {
                    return id;
                }
            }
            
        }
    }
}
