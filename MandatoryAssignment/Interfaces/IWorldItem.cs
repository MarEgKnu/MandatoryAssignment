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
        /// Use the item without any taget, potentially having side-effects on the user based on behavour implemented in derived classes
        /// </summary>
        /// <param name="user">The IWorldEntity using the item</param>
        void Use(IWorldEntity user);
        /// <summary>
        /// Use the item on a IWorldEntity target, potentially having side-effects on the user and the target based on behavour implemented in derived classes
        /// </summary>
        /// <param name="user">The IWorldEntity using the item</param>
        void UseOn(IWorldEntity user,IWorldEntity target);
        /// <summary>
        /// Use the item on a IWorldObject target, potentially having side-effects on the user and the target based on behavour implemented in derived classes
        /// </summary>
        /// <param name="user">The IWorldObject using the item</param>
        void UseOn(IWorldEntity user, IWorldObject target);
        /// <summary>
        /// The name of the Item
        /// </summary>
        string Name { get; set; }

    }
}
