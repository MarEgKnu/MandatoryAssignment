using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Utility
{
    public static class GlobalGameState
    {
        public static IGameState GameState { get; private set; }
    }
}
