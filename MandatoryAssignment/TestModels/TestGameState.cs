using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.TestModels
{
    public class TestGameState : GameState
    {
        public TestGameState(IWorld world, ConfigLoader config, Logger logger) : base(world, config, logger)
        {
        }
    }
}
