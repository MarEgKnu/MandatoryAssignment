using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Structs
{
    /// <summary>
    /// Represents a integer in the range of 0 to int.Max
    /// </summary>
    public readonly struct PositiveInt
    {
        public readonly int _value;

        public int Value { get { return _value; } }

        public PositiveInt(int value)
        {
            if(value < 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            _value = value;
        }

        public static implicit operator PositiveInt(int value)
        {
            return new PositiveInt(value);
        }
        public static PositiveInt operator +(PositiveInt value1,int value2)
        {
            return new PositiveInt(value1.Value + value2);
        }
        public static PositiveInt operator +(PositiveInt value1, PositiveInt value2)
        {
            return new PositiveInt(value1.Value + value2.Value);
        }
        public static PositiveInt operator -(PositiveInt value1, PositiveInt value2)
        {
            return new PositiveInt(value1.Value - value2.Value);
        }
        public static PositiveInt operator -(PositiveInt value1, int value2)
        {
            return new PositiveInt(value1.Value - value2);
        }
        public static bool operator ==(PositiveInt left, PositiveInt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PositiveInt left, PositiveInt right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return Value.Equals(obj);
        }
        public override int GetHashCode()
        {
            return Value;
        }

    }
}
