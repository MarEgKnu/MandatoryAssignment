using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IGridData
    {
        ushort TileID { get; }

        PositiveInt WorldObjectID { get; }

        PositiveInt WorldEntityID { get; }
    }
}
