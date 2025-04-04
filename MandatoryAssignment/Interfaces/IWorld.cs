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
        /// Once called, all properties which are initialization-only should be closed for modifiation
        /// </summary>
        void Initialize();

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
