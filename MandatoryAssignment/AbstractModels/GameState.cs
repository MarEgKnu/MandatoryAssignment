using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class GameState : IGameState
    {
        public static IGameState CurrentState { get; private set; }
        protected GameState(IWorld world, ConfigLoader config, Logger logger)
        {
            World = world;
            Config = config;
            Logger = logger;
            CurrentState = this;
        }
        public IWorld World { get; }

        public Logger Logger {  get; }

        public ConfigLoader Config { get; }

        public virtual void LoadConfig()
        {
            Config.LoadConfig(World);
        }
    }
}
