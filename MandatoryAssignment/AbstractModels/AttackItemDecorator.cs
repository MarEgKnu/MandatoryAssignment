using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    /// <summary>
    /// Represents a decorator to a attackitem, eg. an enchantment on a existing weapon
    /// </summary>
    public abstract class AttackItemDecorator : AttackItem
    {
        protected AttackItemDecorator(string name, AttackItem wrapee) : base(name)
        {
            Wrapee = wrapee;
        }
        /// <summary>
        /// The decorated item
        /// </summary>
        public AttackItem Wrapee { get; protected set; }
        public override abstract PositiveInt Hit(IWorldEntity user);

        public override abstract PositiveInt Range(IWorldEntity user);
    }
}
