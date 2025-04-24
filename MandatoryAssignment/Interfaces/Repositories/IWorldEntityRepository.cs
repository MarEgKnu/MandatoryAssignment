using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface for a keyed repositoy for IWorldEntity objects, using the unique ID and Coordinate as indexed keys and the object as value
    /// </summary>
    public interface IWorldEntityRepository : IAdd<IWorldEntity>, IKeyedDelete<PositiveInt, IWorldEntity>, IKeyedRead<PositiveInt, IWorldEntity>, IKeyedUpdate<PositiveInt, IWorldEntity>, IReadAll<IWorldEntity>,
                                              IKeyedDelete<Coordinate, IWorldEntity>, IKeyedRead<Coordinate, IWorldEntity>, IKeyedUpdate<Coordinate, IWorldEntity>
    {
        /// <summary>
        /// Returns an Icollection of all entity IDs which serve as unique keys
        /// </summary>
        /// <returns>An Icollection of all entity IDs</returns>
        ICollection<PositiveInt> GetIDKeys();
    }
}
