using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IWorldObject
    {
        string Name { get; }
        bool Lootable { get; }
        bool Removable { get; }
    }
}
