using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse.Difficulties
{
    public class TrainedDifficulty : IDifficulty
    {
        private TrainedDifficulty() { }
        private static TrainedDifficulty instance = new();

        public static TrainedDifficulty Instance { get { return instance; } }

        public string Name { get; } = "Trained";

        public double PlayerDmgDealtMult()
        {
            return 0.5;
        }

        public double PlayerDmgTakenMult()
        {
            return 2;
        }
    }
}
