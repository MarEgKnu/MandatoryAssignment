using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class World : IWorld
    {
        protected World(int maxX, int maxY)
        {
            Initialized = false;
            MaxX = maxX;
            MaxY = maxY;            
        }
        protected int _maxX;
        protected int _maxY;
        public int MaxX 
        {
            get 
            { 
                return _maxX;
            }
            set
            {
                if(Initialized)
                {
                    GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"class {this.GetType().Name} tired to call {MethodBase.GetCurrentMethod().Name} even after it was initialized");
                    return;
                }
                _maxX = value;
            }
        }

        public int MaxY
        {
            get
            {
                return _maxY;
            }
            set
            {
                if (Initialized)
                {
                    GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"class {this.GetType().Name} tired to call {MethodBase.GetCurrentMethod().Name} even after it was initialized");
                    return;
                }
                _maxY = value;
            }
        }

        public bool Initialized { get; protected set; }

        public virtual void LoadConfig(ConfigLoader loader)
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
