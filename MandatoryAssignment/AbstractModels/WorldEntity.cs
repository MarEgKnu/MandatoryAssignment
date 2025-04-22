using MandatoryAssignment.Interfaces;
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

        protected IReceiveHitStrategy _receiveHitStrategy;
        protected WorldEntity(string name, PositiveInt hitPoints, DamageReduction baseDamageReduction, IReceiveHitStrategy receiveHitStrategy)
        {
            Name = name;
            HitPoints = hitPoints;
            BaseDamageReduction = baseDamageReduction;
            _receiveHitStrategy = receiveHitStrategy;
            ID = GenerateNextUniqueID();
              
        }
        public string Name {  get; set; }

        public DamageReduction BaseDamageReduction { get; }

        public PositiveInt HitPoints {  get; set; }

        public PositiveInt ID { get; }

        public Coordinate Position { get; set; }
        public IWorldItem Inventory { get; set; }
        /// <summary>
        /// Template method for returning the amount of hit damage this entity can do based on its items and other factors. May be overwritten in subclasses
        /// </summary>
        /// <returns>A PositiveInt representing the damage</returns>
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
            else
            {
                hitDmg += HitWithItem(Inventory);
            }
            return hitDmg;
        }
        /// <summary>
        /// Abstract method to return the damage the specified item can do with this entity.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>A PositiveInt representing the damage</returns>
        protected abstract PositiveInt HitWithItem(IWorldItem item);

        public void Loot(ILootable obj)
        {
            obj.LootItems(this);
            
        }
        /// <summary>
        /// Method for the entity being hit by damage and using the ReceiveHitStrategy to compute the final damage taken. May be overwritten in subclasses
        /// </summary>
        public virtual void ReceiveHit(PositiveInt incomingDmg)
        {
            incomingDmg = _receiveHitStrategy.ComputeDamage(incomingDmg, this);
            HitPoints -= incomingDmg;
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
