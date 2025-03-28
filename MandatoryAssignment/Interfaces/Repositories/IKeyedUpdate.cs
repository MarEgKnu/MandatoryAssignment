using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface representing a "Update" operation with a key.
    /// </summary>
    /// <typeparam name="K">The type of the key</typeparam>
    /// <typeparam name="V">The type of the value</typeparam>
    public interface IKeyedUpdate<K, V>
    {
        /// <summary>
        /// Updates the value at the given key with the "value" parameter. Will return false if the key cannot be found
        /// </summary>
        /// <param name="key">The key to find to update</param>
        /// <param name="value">The value to used to update the existing value with</param>
        /// <returns>True if updated sucessfully, false if key is not found</returns>
        bool Update(K key, V value);
    }
}
