using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface for a keyed repositoy for IWorldObject objects, using the unique ID as a key and the object as value
    /// </summary>
    public interface IWorldObjectRepository : IAdd<IWorldObject>, IKeyedDelete<PositiveInt, IWorldObject>, IKeyedRead<PositiveInt, IWorldObject>, IKeyedUpdate<PositiveInt, IWorldObject>, IReadAll<IWorldObject>,
                                              IKeyedDelete<Coordinate, IWorldObject>, IKeyedRead<Coordinate, IWorldObject>, IKeyedUpdate<Coordinate, IWorldObject>
    {
    }
}
