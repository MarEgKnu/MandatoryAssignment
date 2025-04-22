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
        protected WorldEntity(string name, PositiveInt hitPoints, DamageReduction baseDamageReduction)
        {
            Name = name;
            HitPoints = hitPoints;
            BaseDamageReduction = baseDamageReduction;
            ID = GenerateNextUniqueID();
              
        }
        public string Name {  get; set; }

        public DamageReduction BaseDamageReduction { get; }

        public PositiveInt HitPoints {  get; set; }

        public PositiveInt ID { get; }

        public Coordinate Position { get; set; }
        public IWorldItem Inventory { get; set; }
        /// <summary>
        /// Template method for returning the amount of hit damage this entity can do based on its items. May be overwritten in subclasses
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
        /// Template method for the entity being hit by damage and using its defenceItems or other things to modify the incoming damage. May be overwritten in subclasses
        /// </summary>
        public virtual void ReceiveHit(PositiveInt hitPoints)
        {
            DamageReduction dmgReduction = BaseDamageReduction;
            if (Inventory is ContainerItem container)
            {
                foreach (var item in container.GetSubItems())
                {
                    dmgReduction += ItemDamageReduction(item);
                }
            }
            else
            {
                dmgReduction += ItemDamageReduction(Inventory);
            }
            hitPoints = (PositiveInt)Math.Round( hitPoints * dmgReduction.DmgReductionDecimal, 0);
            hitPoints = Math.Max(hitPoints - dmgReduction.DmgReductionFlat, 0);
            HitPoints -= hitPoints;
            if(HitPoints <= 0)
            {
                // notify observers about death
            }
        }
        /// <summary>
        /// Abstract method for returning the damage reduction effect of an item on this entity.
        /// </summary>
        protected abstract DamageReduction ItemDamageReduction(IWorldItem item);

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
