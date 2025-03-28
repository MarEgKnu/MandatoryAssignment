using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Models
{
    public class NoviceDifficulty : IDifficulty
    {
        private NoviceDifficulty() { }
        private static NoviceDifficulty instance = new();

        public static NoviceDifficulty Instance { get { return instance; } }
        public string Name { get; } = "Novice";

        public double PlayerDmgDealtMult()
        {
            return 1.5;
        }

        public double PlayerDmgTakenMult()
        {
            return 0.5;
        }
    }
}
