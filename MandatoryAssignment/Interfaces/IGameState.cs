using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IGameState
    {
        IWorld World { get; }

        Logger Logger { get; }

        ConfigLoader Config { get; }
    }
}
