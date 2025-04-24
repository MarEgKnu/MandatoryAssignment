using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using SampleFrameworkUse.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class SampleLootChest : WorldObject
    {
        public SampleLootChest(string name, IWorldItem loot, Coordinate position, PositiveInt? id = null) : base(name, loot, position, id)
        {
        }
        public override bool CanWalk(IWorldEntity walker)
        {
            if(walker.Inventory is ContainerItem container)
            {
                foreach(var item in container.GetItems())
                {
                    if (item is FlyItem)
                    {
                        return true;
                    }
                }
            } 
            else if(walker.Inventory is FlyItem)
            {
                return true;
            }
            return false;
        }

        public override bool TryRemove(IWorldItem item)
        {
            throw new NotImplementedException();
        }
    }
}
