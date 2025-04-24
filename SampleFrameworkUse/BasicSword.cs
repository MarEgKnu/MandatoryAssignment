using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    /// <summary>
    /// Basic sword item
    /// </summary>
    public class BasicSword : AttackItem
    {
        public BasicSword(string name) : base(name)
        {
        }

        public override PositiveInt Hit(IWorldEntity user)
        {
            return 10;
        }

        public override PositiveInt Range(IWorldEntity user)
        {
            return 1;
        }
    }
}
