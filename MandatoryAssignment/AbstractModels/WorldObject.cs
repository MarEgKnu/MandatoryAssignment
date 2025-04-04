using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public class WorldObject : IWorldObject
    {
        public string Name => throw new NotImplementedException();

        public bool Lootable => throw new NotImplementedException();

        public bool Removable => throw new NotImplementedException();

        public bool Walkable => throw new NotImplementedException();
    }
}
