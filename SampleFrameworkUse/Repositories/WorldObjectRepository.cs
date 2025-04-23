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
    public class WorldObjectRepository : IWorldObjectRepository
    {
        IDictionary<PositiveInt, IWorldObject> _idIndex;
        IDictionary<Coordinate, IWorldObject> _coordinateIndex;
        public bool Add(IWorldObject value)
        {
            if (_idIndex.ContainsKey(value.ID))
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"Object {{{value}}} being added has a already existing ID in the repository, skipping");
                return false;
            }
            if (_coordinateIndex.ContainsKey(value.Position))
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"Object {{{value}}} being added has the same coordinate as another entity in the repository, skipping");
                return false;
            }
            _idIndex.Add(value.ID, value);
            _coordinateIndex.Add(value.Position, value);
            return true;
        }

        public bool Delete(PositiveInt key)
        {
            if (_idIndex.TryGetValue(key, out IWorldObject @object))
            {
                _idIndex.Remove(key);
                _coordinateIndex.Remove(@object.Position);
                return true;
            }
            else
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"An object with ID {{{key}}} has been attempted to delete, but it dosent exist, skipping");
                return false;
            }
        }

        public bool Delete(Coordinate key)
        {
            if (_coordinateIndex.TryGetValue(key, out IWorldObject @object))
            {
                _coordinateIndex.Remove(key);
                _idIndex.Remove(@object.ID);
                return true;
            }
            else
            {
                GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Warning, 0, $"An object with Coordinate {{{key}}} has been attempted to delete, but it dosent exist, skipping");
                return false;
            }
        }

        public IWorldObject? Read(PositiveInt key)
        {
            if (_idIndex.ContainsKey(key))
            {
                return _idIndex[key];
            }
            else
            {
                return null;
            }
        }

        public IWorldObject? Read(Coordinate key)
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

        public ICollection<IWorldObject> ReadAll()
        {
            return _idIndex.Values;
        }

        public bool Update(PositiveInt key, IWorldObject value)
        {
            if (_idIndex.TryGetValue(key, out IWorldObject @object))
            {
                _idIndex[key] = value;
                if (value.Position != @object.Position)
                {
                    _coordinateIndex.Remove(@object.Position);
                    _coordinateIndex.Add(value.Position, value);
                }
                else
                {                       
                     _coordinateIndex[@object.Position] = value;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Coordinate key, IWorldObject value)
        {
            if (_coordinateIndex.TryGetValue(key, out IWorldObject @object))
            {
                _idIndex[@object.ID] = value;
                if (value.Position != @object.Position)
                {
                    _coordinateIndex.Remove(@object.Position);
                    _coordinateIndex.Add(value.Position, value);
                }
                else
                {
                    _coordinateIndex[@object.Position] = value;
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
