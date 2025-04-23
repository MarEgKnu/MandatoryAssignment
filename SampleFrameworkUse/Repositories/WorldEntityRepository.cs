using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse.Repositories
{
    public class WorldEntityRepository : IWorldEntityRepository
    {
        IDictionary<PositiveInt, IWorldEntity> _idIndex;
        IDictionary<Coordinate, IWorldEntity> _coordinateIndex;

        public bool Add(IWorldEntity value)
        {
            if(_idIndex.ContainsKey(value.ID))
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"Entity {{{value}}} being added has a already existing ID in the repository, skipping");
                return false;
            } 
            if(_coordinateIndex.ContainsKey(value.Position))
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"Entity {{{value}}} being added has the same coordinate as another entity in the repository, skipping");
                return false;
            }
            _idIndex.Add(value.ID, value);
            _coordinateIndex.Add(value.Position, value);
            return true;
        }

        public bool Delete(PositiveInt key)
        {
            if (_idIndex.TryGetValue(key, out IWorldEntity entity))
            {
                _idIndex.Remove(key);
                _coordinateIndex.Remove(entity.Position);
                return true;
            }
            else
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"An entity with ID {{{key}}} has been attempted to delete, but it dosent exist, skipping");
                return false;
            }
        }

        public bool Delete(Coordinate key)
        {
            if (_coordinateIndex.TryGetValue(key, out IWorldEntity entity))
            {
                _coordinateIndex.Remove(key);
                _idIndex.Remove(entity.ID);
                return true;
            }
            else
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"An entity with Coordinate {{{key}}} has been attempted to delete, but it dosent exist, skipping");
                return false;
            }
        }

        public IWorldEntity? Read(PositiveInt key)
        {
            if(_idIndex.ContainsKey(key))
            {
                return _idIndex[key];
            }
            else
            {
                return null;
            }
        }

        public IWorldEntity? Read(Coordinate key)
        {
            if (_coordinateIndex.ContainsKey(key))
            {
                return _coordinateIndex[key];
            }
            else
            {
                return null;
            }
        }

        public ICollection<IWorldEntity> ReadAll()
        {
            return _idIndex.Values;
        }

        public bool Update(PositiveInt key, IWorldEntity value)
        {
            if(_idIndex.TryGetValue(key, out IWorldEntity result))
            {
                _idIndex[key] = value;
                if (value.Position != result.Position)
                {
                    _coordinateIndex.Remove(result.Position);
                    _coordinateIndex.Add(value.Position, value);
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Coordinate key, IWorldEntity value)
        {
            if (_coordinateIndex.TryGetValue(key, out IWorldEntity result))
            {
                _idIndex[result.ID] = value;
                if (value.Position != result.Position)
                {
                    _coordinateIndex.Remove(result.Position);
                    _coordinateIndex.Add(value.Position, value);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
