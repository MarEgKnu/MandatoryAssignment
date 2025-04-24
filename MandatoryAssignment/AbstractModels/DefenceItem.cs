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
    /// Represents an item with defenive attributes
    /// </summary>
    public abstract class DefenceItem : IWorldItem
    {
        protected DefenceItem(string name)
        {
            Name = name;
        }
        /// <summary>
        /// The name of the defence item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the amount of damage reduction this item provides
        /// </summary>
        /// <returns>A positive integer denoting the amount of damage reduction</returns>
        public abstract DamageReduction GetDamageReduction();

    }
}
