using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class World : IWorld
    {
        protected World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            Initialized = false;
        }
        public int MaxX { get; }

        public int MaxY { get; }

        public bool Initialized { get; private set; }

        public void LoadConfig(ConfigLoader loader)
        {
            if(loader is null)
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Error, 0, $"Null {nameof(ConfigLoader)} object was passed to {System.Reflection.MethodBase.GetCurrentMethod().Name}, skipping loading config file");
                return;
            }
            loader.LoadConfig(this);
            Initialized = true;
        }
    }
}
