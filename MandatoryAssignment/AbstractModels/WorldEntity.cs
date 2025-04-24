using MandatoryAssignment.EventArguments;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Models;
using MandatoryAssignment.Structs;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class WorldEntity : IWorldEntity
    {
        protected static Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public event Action<IWorldEntity, EventArgs> OnHit;

        public event Action<IWorldEntity, EventArgs> OnDeath;

        protected IReceiveHitStrategy _receiveHitStrategy;
        protected WorldEntity(string name, PositiveInt hitPoints, DamageReduction baseDamageReduction, IReceiveHitStrategy receiveHitStrategy, Coordinate position, IWorldItem inventory, bool isPlayer, PositiveInt? id = null )
        {
            Name = name;
            HitPoints = hitPoints;
            BaseDamageReduction = baseDamageReduction;
            Position = position; 
            Inventory = inventory;
            IsPlayer = isPlayer;
            _receiveHitStrategy = receiveHitStrategy;
            if(id is null)
            {
                ID = GenerateNextUniqueID();
            }
            else
            {
                ID = id.Value;
            }
            
              
        }

        public bool IsPlayer {  get; }

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
            if(IsPlayer)
            {
                hitDmg = (PositiveInt)Math.Round(hitDmg * GameState.CurrentState.World.SelectedDifficulty.PlayerDmgDealtMult(), 0);
            }
            
            return hitDmg;
        }
        /// <summary>
        /// Abstract method to return the damage the specified item can do with this entity.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>A PositiveInt representing the damage</returns>
        protected abstract PositiveInt HitWithItem(IWorldItem item);

        public virtual void Loot(ILootable obj)
        {
            obj.LootItems(this);
            
        }
        /// <summary>
        /// Method for the entity being hit by damage and using the ReceiveHitStrategy to compute the final damage taken. May be overwritten in subclasses
        /// </summary>
        /// <returns>True if the entity is still alive, false if dead</returns>
        public virtual bool ReceiveHit(PositiveInt incomingDmg)
        {
            incomingDmg = _receiveHitStrategy.ComputeDamage(incomingDmg, this);
            if (IsPlayer)
            {
                incomingDmg = (PositiveInt)Math.Round(incomingDmg * GameState.CurrentState.World.SelectedDifficulty.PlayerDmgTakenMult(), 0);
            }
            HitPoints -= incomingDmg;
            OnHit?.Invoke(this, new OnHitEventArgs(incomingDmg));
            if(HitPoints <= 0)
            {
                OnDeath?.Invoke(this, new OnHitEventArgs(incomingDmg));
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Generates a unique Positive integer ID which must not be 0 if the id parameter in the constructor is omitted or null. May be overwritten in subclasses
        /// </summary>
        /// <returns>A Unique PositiveInt ID</returns>
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
