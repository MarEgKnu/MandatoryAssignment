using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class BasicDefenceArmor : DefenceItem
    {
        protected BasicDefenceArmor(string name) : base(name)
        {
        }

        public override DamageReduction GetDamageReduction()
        {
            return new DamageReduction(5, 0.8);
        }
    }
}
