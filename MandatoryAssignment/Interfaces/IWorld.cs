using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a "World" object.
    /// </summary>
    public interface IWorld
    {
        /// <summary>
        /// When this variable is true, all members which should not be modified after initialization should not be able to be modified.
        /// </summary>
        bool Initialized { get; }

        /// <summary>
        /// An IWorldObjectRepository containing all world objects currently in the game. The key used for lookup is the objects unique ID
        /// </summary>
        IWorldObjectRepository WorldObjects { get; }

        /// <summary>
        /// Once called, all properties which are initialization-only should be closed for modifiation
        /// </summary>
        void Initialize();

        /// <summary>
        /// The 2-dimensional grid for the world. Should not be settable after initialization.
        /// </summary>
        IGrid WorldGrid { get; }

        /// <summary>
        /// The max X Coordinate for the world. Must not be below 0, and should not be settable after initialization.
        /// </summary>
        public uint MaxX { get; set; }
        /// <summary>
        /// The max Y Coordinate for the world. Must not be below 0, and should not be settable after initialization.
        /// </summary>
        public uint MaxY { get; set; }
    }
}
