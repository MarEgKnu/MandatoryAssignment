using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IWorldEntity
    {
        string Name { get; }

        int HitPoints { get; }

        int Hit();

        void ReceiveHit(int hitPoints);

        void Loot(IWorldObject obj);
    }
}
