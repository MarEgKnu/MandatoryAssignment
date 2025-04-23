using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IWorldObject : ILootable, IRemovable, IWalkable
    {
        /// <summary>
        /// The Unique identifier of the object. Should be a positive integer (not 0).
        /// </summary>
        PositiveInt ID { get; }
        /// <summary>
        /// The name of the object
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The coordinate position of the object
        /// </summary>
        Coordinate Position { get; }

    }
}
