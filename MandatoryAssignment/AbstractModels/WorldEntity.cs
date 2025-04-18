﻿using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class WorldEntity : IWorldEntity
    {
        protected static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        protected WorldEntity(string name, PositiveInt hitPoints)
        {
            Name = name;
            HitPoints = hitPoints;
            ID = GenerateNextUniqueID();
              
        }
        public string Name {  get; set; }

        public PositiveInt HitPoints {  get; set; }

        public PositiveInt ID { get; }

        public Coordinate Position { get; set; }
        public IWorldItem Inventory { get; set; }

        public virtual PositiveInt Hit()
        {
            PositiveInt hitDmg = 0;
            if(Inventory is ContainerItem container)
            {
                foreach(var item in container.GetSubItems())
                {
                    hitDmg += HitWithItem(item);
                }
            }
            return hitDmg;
        }
        public abstract PositiveInt HitWithItem(IWorldItem item);

        public void Loot(ILootable obj)
        {
            obj.LootItems(this);
            
        }

        public virtual void ReceiveHit(int hitPoints)
        {
            HitPoints -= hitPoints;
            if(HitPoints <= 0)
            {
                // notify observers about death
            }
        }

        protected virtual PositiveInt GenerateNextUniqueID()
        {
            while (true)
            {
                int id = _rng.Next(1, int.MaxValue);
                if (GameState.CurrentState.World.WorldEntities.Read(id) is null)
                {
                    return id;
                }
            }

        }
    }
}
