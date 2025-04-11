using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Structs
{
    public readonly struct Coordinate
    {
        public readonly PositiveInt x;
        public readonly PositiveInt y;
        public Coordinate(PositiveInt x, PositiveInt y)
        {
            this.x = x; 
            this.y = y;
        }
        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.x + b.x, a.y + a.x);
        }
        public override bool Equals(object? obj)
        {
            if(obj is not null && obj is Coordinate other)
            {
                if(other.x == this.x && other.y == this.y)
                {
                    return true;
                }
            }
            return false;
            
        }
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + x;
            hash = hash * 31 + y;
            return hash;
        }

        public static bool operator ==(Coordinate left, Coordinate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coordinate left, Coordinate right)
        {
            return !(left == right);
        }

        public Coordinate XYDiffrence(Coordinate other)
        {
            int otherX = other.x;
            int otherY = other.y;
            int thisX = this.x;
            int thisY = this.y;
            int xDiff = Math.Abs(otherX - thisX);
            int yDiff = Math.Abs(otherY - thisY);
            return new Coordinate(xDiff, yDiff);
                      
        }
        public bool IsInRange(Coordinate other, PositiveInt range)
        {
            Coordinate diffrence = XYDiffrence(other);
            return Math.Max(diffrence.x, diffrence.y) <= range;
        }
        
    }
}
