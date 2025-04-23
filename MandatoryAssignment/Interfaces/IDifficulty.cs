using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface representing a single difficulty setting.
    /// </summary>
    public interface IDifficulty
    {
        /// <summary>
        /// The display name of the difficulty
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The multiplier to the damage the player deals while the difficulty is in effect.
        /// Should only return positive decimal values, ie. 1 = the same damage, 2 = double damage
        /// </summary>
        /// <returns>A double representing the multiplier</returns>
        double PlayerDmgDealtMult();
        /// <summary>
        /// The multiplier to the damage the player receives while the difficulty is in effect.
        /// Should only return positive decimal values, ie. 1 = the same damage, 2 = double damage, 0.5 = half damage
        /// </summary>
        /// <returns>A double representing the multiplier</returns>
        double PlayerDmgTakenMult();
    }
}
