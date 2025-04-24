using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class DefenceItem : IWorldItem
    {
        protected DefenceItem(string name)
        {
            Name = name;
        }
        public string Name { get; set; }


        public abstract DamageReduction GetDamageReduction();

    }
}
