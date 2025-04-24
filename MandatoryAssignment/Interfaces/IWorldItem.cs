using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// A interface representing an item in a world.
    /// </summary>
    public interface IWorldItem
    {
        /// <summary>
        /// The name of the Item
        /// </summary>
        string Name { get; set; }

    }
}
