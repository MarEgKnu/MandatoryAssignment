using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface representing a "Add" operation with a key.
    /// </summary>
    /// <typeparam name="K">The type of the key</typeparam>
    /// <typeparam name="V">The type of the value</typeparam>
    public interface IKeyedAdd<K,V>
    {
        /// <summary>
        /// Adds the given value with the specified key. Will return false if the key already exists
        /// </summary>
        /// <param name="key">The key to add with</param>
        /// <param name="value">The value to add with</param>
        /// <returns>True if added sucessfully, false if the key already exists</returns>
        bool Add(K key, V value);
    }
}
