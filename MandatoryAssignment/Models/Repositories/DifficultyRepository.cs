using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Models.Repositories
{
    /// <summary>
    /// Basic conrete class for a DifficultyRepository, using objects implementing IDictionary to store items. 
    /// </summary>
    public class DifficultyRepository : IDifficultyRepository
    {
        public DifficultyRepository(IDictionary<string, IDifficulty> dict)
        {
            if(dict == null)
            {
                GameState.CurrentState.Logger.TraceEvent(TraceEventType.Critical, 0, $"Null parameter for {nameof(dict)} was passed to {MethodBase.GetCurrentMethod().Name}, throwing exception.");
                throw new ArgumentNullException(nameof(dict));
            }
            _dict = dict;
        }
        IDictionary<string, IDifficulty> _dict;
        public bool Add(string key, IDifficulty value)
        {
            return _dict.TryAdd(key, value);
        }

        public bool Delete(string key)
        {
            return _dict.Remove(key);
        }

        public IDifficulty? Read(string key)
        {
            if(_dict.TryGetValue(key, out var value))
            {
                return value;
            }
            return null;
            
        }

        public bool Update(string key, IDifficulty value)
        {
            if(_dict.ContainsKey(key))
            {
                _dict[key] = value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
