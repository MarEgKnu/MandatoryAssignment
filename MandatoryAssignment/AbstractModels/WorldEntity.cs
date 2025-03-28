using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class WorldEntity : IWorldEntity
    {
        public string Name => throw new NotImplementedException();

        public int HitPoints => throw new NotImplementedException();

        public int Hit()
        {
            throw new NotImplementedException();
        }

        public void Loot(IWorldObject obj)
        {
            throw new NotImplementedException();
        }

        public void ReceiveHit(int hitPoints)
        {
            throw new NotImplementedException();
        }
    }
}
