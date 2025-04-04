using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface representing a "Read All" operation
    /// </summary>
    /// <typeparam name="T">The type to return a ICollection of</typeparam>
    public interface IReadAll<T>
    {
        /// <summary>
        /// Gets all values of type T in the collection.
        /// </summary>
        /// <returns>An ICollection of all the elements</returns>
        ICollection<T> ReadAll();
    }
}
