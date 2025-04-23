using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Structs;
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
        protected World(IGrid grid, IWorldObjectRepository worldObjectRepo, IWorldEntityRepository worldEntities, IDifficultyRepository difficulties)
        {
            Initialized = false;
            MaxX = grid.MaxX;
            MaxY = grid.MaxY;
            _grid = grid;
            WorldObjects = worldObjectRepo;
            WorldEntities = worldEntities;
            SelectableDifficulties = difficulties;
        }
        protected PositiveInt _maxX;
        protected PositiveInt _maxY;
        protected IGrid _grid;

        public void Initialize()
        {
            Initialized = true;
        }
        protected IDifficultyRepository _selectableDifficulties;
        protected IWorldEntityRepository _worldEntities;
        protected IWorldObjectRepository _worldObjects;
        public IWorldEntityRepository WorldEntities 
        { 
            get 
            { 
                return _worldEntities; 
            } 
            set
            {
                if (Initialized)
                {
                    GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"class {this.GetType().Name} tired to call {MethodBase.GetCurrentMethod().Name} even after it was initialized");
                    return;
                }
                _worldEntities = value;
            }
        }

        public IDifficultyRepository SelectableDifficulties
        {
            get
            {
                return _selectableDifficulties;
            }
            set
            {
                if (Initialized)
                {
                    GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"class {this.GetType().Name} tired to call {MethodBase.GetCurrentMethod().Name} even after it was initialized");
                    return;
                }
                _selectableDifficulties = value;
            }
        }

        public IDifficulty SelectedDifficulty { get; set; }

        public IWorldObjectRepository WorldObjects { get; }
        public PositiveInt MaxX 
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

        public PositiveInt MaxY
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

        public IGrid WorldGrid 
        {
            get 
            { 
                return _grid; 
            } 
            set
            {
                if (Initialized)
                {
                    GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"class {this.GetType().Name} tired to call {MethodBase.GetCurrentMethod().Name} even after it was initialized");
                    return;
                }
                _grid = value;
            } 
        }
    }
}
