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
    public interface IKeyedDelete<K, V>
    {
        /// <summary>
        /// Deletes the given value with the specified key. Will return false if the key cannot be found
        /// </summary>
        /// <param name="key">The key to delete</param>
        /// <returns>True if deleted sucessfully, false if the key dosent exist</returns>
        bool Delete(K key);
    }
}
