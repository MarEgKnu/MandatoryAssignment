using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for the main game manager.
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// The world for the game
        /// </summary>
        IWorld World { get; }
        /// <summary>
        /// The type of logger to use
        /// </summary>
        Logger Logger { get; }
        /// <summary>
        /// The type of configLoader to use
        /// </summary>
        ConfigLoader Config { get; }

        /// <summary>
        /// The GameLoop strategy to use when the game starts.
        /// </summary>
        IGameLoop GameLoop { get; }
        /// <summary>
        /// Starts the game loop, and uses the "GameLoop" stategy for executing it.
        /// </summary>
        public void StartGameLoop();

        /// <summary>
        /// Applies changes to the state object based on the content of the config file, and the type of ConfigLoader provided.
        /// Might have side-effects in the state object and its properties, and may change "Initialized" to true either inside the call, or right after
        /// </summary>
        public void LoadConfig();
    }
}
