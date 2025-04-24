using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class SampleContainer : ContainerItem
    {
        public SampleContainer(string name, IList<IWorldItem> items, ICollection<PositiveInt> freeSlots) : base(name, items, freeSlots)
        {
        }

        public override bool Add(IWorldItem item)
        {
            PositiveInt? freeSlot = FirstFreeSlot;
            if(freeSlot is not null)
            {
                _items[freeSlot.Value] = item;
                FreeSlots.Remove(freeSlot.Value);
                return true;

            }
            else
            {
                return false;
            }
        }

        public override IWorldItem? GetItemBySlot(PositiveInt slotId)
        {
            if(slotId > Capacity - 1)
            {
                return null;
            }
            else
            {
                return _items[slotId];
            }
            
        }

        public override bool IsItemAllowed(IWorldItem item)
        {
            // all items are allowed
            return true;
        }

        public override bool Remove(IWorldItem item)
        {
            for(int i = 0;  i < _items.Count; i++)
            {
                if (_items[i] == item)
                {
                    _items[i] = null;
                    FreeSlots.Add(i);
                    return true;
                }
                else if (_items[i] is ContainerItem container)
                {
                    if(container.Remove(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override bool RemoveBySlot(PositiveInt slotId)
        {
            if (slotId > Capacity - 1 || _items[slotId] is null)
            {
                return false;
            }
            else
            {
                _items[slotId] = null;
                FreeSlots.Add(slotId);
                return true;
            }

                
            
        }

        public override bool Take(IWorldItem item, IWorldEntity inventoryOwner)
        {
            bool takenAtleastOne = false;
            if(item == null || FirstFreeSlot is null) {  return false; }
            if(item is ContainerItem container)
            {
                PositiveInt[] freeSlotsArr = new PositiveInt[FreeSlots.Count];
                FreeSlots.CopyTo(freeSlotsArr, 0);
                foreach(PositiveInt freeSlot in freeSlotsArr)
                {
                    for(int i = 0; i < container.Capacity; i++)
                    {
                        if (container.GetItems()[i] is not null)
                        {
                            _items[freeSlot] = container.GetItems()[i];
                            FreeSlots.Remove(freeSlot);
                            container.GetItems()[i] = null;
                            container.FreeSlots.Add(i);
                            takenAtleastOne = true;

                        }
                    }
                }
                return takenAtleastOne;
            }
            else
            {
                _items[FirstFreeSlot.Value] = item;
                FreeSlots.Remove(FirstFreeSlot.Value);
                if(inventoryOwner is not null)
                {
                    inventoryOwner.Inventory = null;
                }
                return true;
            }
        }
    }
}
