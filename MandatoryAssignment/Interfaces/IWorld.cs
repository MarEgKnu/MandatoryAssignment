using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Structs;
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
        /// An IDifficultyRepository containing all the selectable difficulties currently in the game.
        /// </summary>
        IDifficultyRepository SelectableDifficulties { get; }

        IMovementManager MovementManager { get; }

        /// <summary>
        /// The currently selected difficulty for the world
        /// </summary>
        IDifficulty SelectedDifficulty { get; set; }

        /// <summary>
        /// An IWorldObjectRepository containing all world objects currently in the game. The key used for lookup is the objects unique ID
        /// </summary>
        IWorldObjectRepository WorldObjects { get; }

        /// <summary>
        /// An IWorldEntityRepository containing all world entities currently in the game. The key used for lookup is the objects unique ID
        /// </summary>
        IWorldEntityRepository WorldEntities{ get; }

        /// <summary>
        /// Once called, all properties which are initialization-only should be closed for modifiation
        /// </summary>
        void Initialize();

        /// <summary>
        /// The max X Coordinate for the world. Must not be below 0, and should not be settable after initialization.
        /// </summary>
        public PositiveInt MaxX { get; set; }
        /// <summary>
        /// The max Y Coordinate for the world. Must not be below 0, and should not be settable after initialization.
        /// </summary>
        public PositiveInt MaxY { get; set; }
    }
}
