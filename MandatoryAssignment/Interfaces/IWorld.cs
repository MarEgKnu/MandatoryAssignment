using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{

    public interface IWorld
    {
        bool Initialized { get; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public void LoadConfig(ConfigLoader loader);
    }
}
