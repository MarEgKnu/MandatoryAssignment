using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public class DefenceItem : IWorldItem
    {
        protected DefenceItem(string name, DamageReduction damageReduction)
        {
            Name = name;
            DamageReduction = damageReduction;
        }
        public string Name { get; set; }

        public DamageReduction DamageReduction { get; }

        public void Use(IWorldEntity user)
        {
            throw new NotImplementedException();
        }

        public void UseOn(IWorldEntity user, IWorldEntity target)
        {
            throw new NotImplementedException();
        }

        public void UseOn(IWorldEntity user, IWorldObject target)
        {
            throw new NotImplementedException();
        }
    }
}
