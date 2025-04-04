using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Structs
{
    public struct Coordinate
    {
        public uint x;
        public uint y;
        public Coordinate(uint x, uint y)
        {
            this.x = x; 
            this.y = y;
        }
        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.x + b.x, a.y + a.x);
        }
    }
}
