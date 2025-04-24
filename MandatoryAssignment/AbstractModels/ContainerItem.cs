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
    /// An abstract class representing an item which can hold many more items
    /// </summary>
    public abstract class ContainerItem : IWorldItem
    {
        protected ContainerItem(string name, IList<IWorldItem> items, ICollection<PositiveInt> freeSlots)
        {
            freeSlots.Clear();
            FreeSlots = freeSlots;
            Name = name;
            _items = items;
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i] == null)
                {
                    FreeSlots.Add(i);
                }
            }
        }

        protected IList<IWorldItem> _items;

        public PositiveInt? FirstFreeSlot { get
            {
                return FreeSlots.FirstOrDefault();
            } }

        public ICollection<PositiveInt> FreeSlots { get; protected set; }
        public PositiveInt Capacity { get
            {
                return _items.Count;
            } }
        public string Name { get; set; }
        

        /// <summary>
        /// Gets all sub-items which aren't composite, in all sub composite items
        /// </summary>
        /// <returns>A IList of all sub items which arent composite</returns>
        public IList<IWorldItem> GetSubItems()
        {
            IList<IWorldItem> subItems = new List<IWorldItem>();
            foreach (var item in GetItems())
            {
                if(item is ContainerItem container)
                {
                    subItems = (IList<IWorldItem>)subItems.Concat(container.GetSubItems());
                }
                else
                {
                    subItems.Add(item);
                }
            }
            return subItems;
        }
        /// <summary>
        /// Checks if the specified item is allowed in this container
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns>True if allowed, false if not</returns>
        public abstract bool IsItemAllowed(IWorldItem item);
        /// <summary>
        /// Attempts to add the specified item to the container
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <returns>True if the item can be added, false if not</returns>
        public abstract bool Add(IWorldItem item);
        /// <summary>
        /// Removes the specified item from the container. Should also check all composite containers for the item to remove
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if the item was sucessfully removed, false if not</returns>
        public abstract bool Remove(IWorldItem item);

        /// <summary>
        /// Takes items from the target inventory, removing them from it and adding those items to this inventory
        /// </summary>
        /// <param name="item"></param>
        /// <param name="inventoryOwner">The entity doing the taking. Null if no applicable entity</param>
        /// <returns>True if atleast one item was taken, false if not</returns>
        public abstract bool Take(IWorldItem item, IWorldEntity inventoryOwner);


        /// <summary>
        /// Removes the item at the specified slotID from the container.
        /// </summary>
        /// <param name="slotId">The slotID to remove the item at</param>
        /// <returns>True if the item was sucessfully removed, false if not</returns>
        public abstract bool RemoveBySlot(PositiveInt slotId);


        /// <summary>
        /// Gets the item at the specified slot ID, or null if no item exists or is out of range
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A IWorldItem at the given slot, or null if none exist or out of range</returns>
        public abstract IWorldItem? GetItemBySlot(PositiveInt slotId);
        /// <summary>
        /// Returns all items, composite or not.
        /// </summary>
        /// <returns>A IList of items contained</returns>
        public IList<IWorldItem> GetItems()
        {
            return _items;
        }

    }
}
