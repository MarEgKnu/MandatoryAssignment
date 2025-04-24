using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Structs
{
    /// <summary>
    /// A struct representing damage reduction, including flat and decimal reductions.
    /// </summary>
    public readonly struct DamageReduction
    {
        private readonly int _dmgReductionFlat = 0;

        /// <summary>
        /// The flat damage reduction
        /// </summary>
        public int DmgReductionFlat { get { return _dmgReductionFlat; } }


        private readonly double _dmgReductionDecimal = 1;

        /// <summary>
        /// The decimal damage reduction. eg 0.9 means 10% damage reduction
        /// </summary>
        public double DmgReductionDecimal { get { return _dmgReductionDecimal; } }

        /// <summary>
        /// Creates a new instance with the specified amount of flat and decimal damage reduction
        /// </summary>
        /// <param name="value">The value to use</param>
        public DamageReduction(int dmgReductionFlat, double dmgReductionDecimal)
        {
            if(dmgReductionFlat < 0)
            {
                _dmgReductionFlat = 0;
            }
            else
            {
                _dmgReductionFlat = dmgReductionFlat;
            }
            if(dmgReductionDecimal < 0)
            {
                _dmgReductionDecimal = 0;
            }
            else if(dmgReductionDecimal > 1)
            {
                _dmgReductionDecimal = 1;
            }
            else
            {
                _dmgReductionDecimal = dmgReductionDecimal;
            }
        }

        public static DamageReduction operator +(DamageReduction value1, DamageReduction value2)
        {
            return new DamageReduction(value1.DmgReductionFlat + value2.DmgReductionFlat, value1.DmgReductionDecimal + value2.DmgReductionDecimal);
        }
    }
}
