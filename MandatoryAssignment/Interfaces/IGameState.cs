using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IGameState
    {
        IWorld World { get; }

        Logger Logger { get; }

        ConfigLoader Config { get; }
        /// <summary>
        /// Applies changes to the state object based on the content of the config file, and the type of ConfigLoader provided.
        /// Will have side-effects in the state object and its properties, and may change "Initialized" to true either inside the call, or right after
        /// </summary>
        public void LoadConfig();
    }
}
