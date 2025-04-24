using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class AttackItemDecorator : AttackItem
    {
        protected AttackItemDecorator(string name, AttackItem wrapee) : base(name)
        {
            Wrapee = wrapee;
        }
        public AttackItem Wrapee { get; protected set; }
        public override abstract PositiveInt Hit(IWorldEntity user);

        public override abstract PositiveInt Range(IWorldEntity user);
    }
}
