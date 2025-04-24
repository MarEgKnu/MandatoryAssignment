using MandatoryAssignment.Interfaces;
using SampleFrameworkUse.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class AmuletOfFlying : FlyItem
    {
        public AmuletOfFlying(string name): base(name)
        {
            Name = name;
        }
    }
}
