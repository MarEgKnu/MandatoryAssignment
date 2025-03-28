using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Models
{
    /// <summary>
    /// A concrete difficulty class representing "normal" difficulty
    /// </summary>
    public class NormalDifficulty
    {
        private NormalDifficulty() { }
        private static NormalDifficulty instance = new();

        public static NormalDifficulty Instance { get { return instance; } }

        public string Name { get; } = "Normal";

        public double PlayerDmgDealtMult()
        {
            return 1;
        }

        public double PlayerDmgTakenMult()
        {
            return 1;
        }
    }
}
