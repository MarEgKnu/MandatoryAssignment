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
    public class SampleMonster : WorldEntity
    {
        public SampleMonster(string name, PositiveInt hitPoints, DamageReduction baseDamageReduction, IReceiveHitStrategy receiveHitStrategy, Coordinate position, IWorldItem inventory, bool IsPlayer, PositiveInt? id = null) : base(name, hitPoints, baseDamageReduction, receiveHitStrategy, position, inventory, IsPlayer, id)
        {
        }

        protected override PositiveInt HitWithItem(IWorldItem item)
        {
            if(item is AttackItem atkItem)
            {
                return atkItem.Hit(this);
            }
            return 0;
        }
    }
}
