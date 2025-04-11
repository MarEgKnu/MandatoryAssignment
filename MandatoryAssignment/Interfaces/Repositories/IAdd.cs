using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface representing a "Add" operation without a key.
    /// </summary>
    /// <typeparam name="V">The type of the value</typeparam>
    public interface IAdd<V>
    {
        /// <summary>
        /// Adds the given value. Will return false if it cannot be addded
        /// </summary>
        /// <param name="value">The value to add with</param>
        /// <returns>True if added sucessfully, false if it failed to be added</returns>
        bool Add(V value);
    }
}
