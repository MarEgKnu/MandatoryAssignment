using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class SampleGameState : GameState
    {
        public SampleGameState(IWorld world, ConfigLoader config, Logger logger, IGameLoop gameLoop) : base(world, config, logger, gameLoop)
        {
        }
    }
}
