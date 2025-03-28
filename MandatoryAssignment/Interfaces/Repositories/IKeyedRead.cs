using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface representing a "Read" operation with a key.
    /// </summary>
    /// <typeparam name="K">The type of the key</typeparam>
    /// <typeparam name="V">The type of the value</typeparam>
    public interface IKeyedRead<K, V>
    {
        /// <summary>
        /// Gets the given value accociated with the specified key. Will return null if the key cannot be found
        /// </summary>
        /// <param name="key">The key to find</param>
        /// <returns>The value accociated with the key, or null if the key is not found</returns>
        V? Read(K key);
    }
}
