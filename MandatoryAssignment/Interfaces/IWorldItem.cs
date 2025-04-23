using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// A interface representing an item in a world.
    /// </summary>
    public interface IWorldItem
    {
        /// <summary>
        /// Use the item, potentially having side-effects on the user based on behavour implemented in derived classes
        /// </summary>
        /// <param name="user">The IWorldEntity using the item</param>
        void Use(IWorldEntity user);
        /// <summary>
        /// The name of the Item
        /// </summary>
        string Name { get; set; }

    }
}
