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
    /// Represents an enchanted weapon, using a decorator to apply bonuses to the weapon
    /// </summary>
    public class EnchantedWeapon : AttackItemDecorator
    {
        public EnchantedWeapon(string name, AttackItem wrapee, int bonusDamage, int bonusRange) : base(name, wrapee)
        {
            BonusDamage = bonusDamage;
            BonusRange = bonusRange;
        }

        public int BonusRange { get; protected set; }

        public int BonusDamage { get; protected set; }

        public override PositiveInt Hit(IWorldEntity user)
        {
            return Wrapee.Hit(user) + BonusDamage;
        }

        public override PositiveInt Range(IWorldEntity user)
        {
            return Wrapee.Range(user) + BonusRange;
        }
    }
}
