using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Repositories
{
    public interface IWorldEntityRepository : IKeyedAdd<uint, IWorldEntity>, IKeyedDelete<uint, IWorldEntity>, IKeyedRead<uint, IWorldEntity>, IKeyedUpdate<uint, IWorldEntity>, IReadAll<IWorldEntity>
    {

    }
}
