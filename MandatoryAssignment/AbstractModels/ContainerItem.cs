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
        protected ContainerItem(string name, PositiveInt capacity, IList<IWorldItem> items)
        {
            Name = name;
            Capacity = capacity;
            _items = items;
        }

        protected IList<IWorldItem> _items;
        public PositiveInt Capacity { get; protected set; }
        public string Name { get; set; }

        public abstract bool IsItemAllowed(IWorldItem item);

        public abstract void Add(IWorldItem item);

        public abstract void Remove(IWorldItem item);

        public abstract IList<IWorldItem> GetItems();

        public void Use(IWorldEntity user)
        {
            throw new NotImplementedException();
        }

        public void UseOn(IWorldEntity user, IWorldEntity target)
        {
            throw new NotImplementedException();
        }

        public void UseOn(IWorldEntity user, IWorldObject target)
        {
            throw new NotImplementedException();
        }
    }
}
