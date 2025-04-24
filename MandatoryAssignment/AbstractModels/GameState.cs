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
        protected GameState(IWorld world, ConfigLoader config, Logger logger, IGameLoop gameLoop)
        {
            World = world;
            Config = config;
            Logger = logger;
            GameLoop = gameLoop;
            if(CurrentState is not null)
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"Another instance of {nameof(GameState)} was created, overriding the global reference!");
            }
            CurrentState = this;
        }
        public IWorld World { get; }

        public Logger Logger {  get; }

        public ConfigLoader Config { get; }

        public IGameLoop GameLoop { get; }

        public virtual void LoadConfig()
        {
            if (Config is null)
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Error, 0, $"Null {nameof(ConfigLoader)} object was passed to {System.Reflection.MethodBase.GetCurrentMethod().Name}, skipping loading config file");
                return;
            }
            Config.LoadConfig(this);
            World.Initialize();
            Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, "Config file fully loaded");
        }

        public void StartGameLoop()
        {
            GameLoop.Start(this);
        }
    }
}
