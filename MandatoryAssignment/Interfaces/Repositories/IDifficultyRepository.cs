using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    /// <summary>
    /// Interface for a keyed repositoy for IDifficulty objects, using the difficulty name as a key and the object as value
    /// </summary>
    public interface IDifficultyRepository : IKeyedAdd<string, IDifficulty>, IKeyedDelete<string, IDifficulty>, IKeyedRead<string, IDifficulty>, IKeyedUpdate<string, IDifficulty>
    {

    }
}
