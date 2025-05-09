﻿using MandatoryAssignment.Interfaces.Repositories;
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
        /// <summary>
        /// Event which fires when the entity is hit by damage. Returns the subject being hit, and the damage taken in EventArgs
        /// </summary>
        public event Action<IWorldEntity, EventArgs> OnHit;
        /// <summary>
        /// Event which fires when the entity dies. Returns the subject being hit, and the damage taken in EventArgs
        /// </summary>
        public event Action<IWorldEntity, EventArgs> OnDeath;
        /// <summary>
        /// Bool representing if the current entity is player-controlled
        /// </summary>
        bool IsPlayer { get; }
        /// <summary>
        /// The base damage reduction for the entity without any other factors.
        /// </summary>
        DamageReduction BaseDamageReduction { get; }

        /// <summary>
        /// The unique identifier of the entity. No two entities should have the same ID
        /// </summary>
        PositiveInt ID { get; }

        /// <summary>
        /// The name of the entity
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The current position of the entity on the map. The position coordinates may not be below 0
        /// </summary>
        Coordinate Position { get; set; }
        /// <summary>
        /// The inventory of the entity. May be either many items (composite, thou ContainerItem class or similar), or a single item
        /// </summary>
        IWorldItem Inventory { get; set; }
        /// <summary>
        /// The hitpoints of the entity. If it is equal to or less than 0, the creature should die.
        /// </summary>
        PositiveInt HitPoints { get; }

        /// <summary>
        /// Method for returning the amount of hit damage this entity can do based on its items and other factors. The returned damage must be 0 or a positive int
        /// </summary>
        /// <returns>A PositiveInt representing the damage</returns>
        PositiveInt Hit();
        /// <summary>
        /// Method for the entity being hit by damage. The incoming damage must be 0 or a positive integer
        /// </summary>
        /// <returns>True if the entity is still alive, false if dead</returns>
        bool ReceiveHit(PositiveInt incomingDmg);

        /// <summary>
        /// Makes the entity loot the specified object, possibly adding loot to it's inventory.
        /// </summary>
        /// <param name="obj">The object to loot</param>
        void Loot(ILootable obj);

    }
}
