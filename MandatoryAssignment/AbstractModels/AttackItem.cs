using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class AttackItem : IWorldItem
    {
        protected AttackItem(string name)
        {
            Name = name;
        }
        /// <summary>
        /// The name of the attack item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets the hit damage of the weapon
        /// </summary>
        /// <param name="user">The entity using the weapon</param>
        /// <returns>A positive integer denoting the amount of damage</returns>
        public abstract PositiveInt Hit(IWorldEntity user);
        /// <summary>
        /// Gets the range of the weapon
        /// </summary>
        /// <param name="user">The entity using the weapon</param>
        /// <returns>A positive integer denoting range of the weapon in tiles</returns>
        public abstract PositiveInt Range(IWorldEntity user);


        //public virtual void UseOn(IWorldEntity user, IWorldEntity target)
        //{
        //    Coordinate diff = user.Position.XYDiffrence(target.Position);
        //    if(Math.Max(diff.x, diff.y) <= Range(user))
        //    {
        //        target.ReceiveHit(Hit(user));
        //    }          
        //}
    }
}
