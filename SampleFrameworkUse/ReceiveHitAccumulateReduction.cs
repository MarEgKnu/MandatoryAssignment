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
    /// Strategy for receving hit which takes BaseDmgReuduction into account, and sums all defence item stats to compute the final damage reduction.
    /// </summary>
    public class ReceiveHitAccumulateReduction : IReceiveHitStrategy
    {
        public PositiveInt ComputeDamage(PositiveInt incomingDmg, IWorldEntity receiver)
        {
            DamageReduction dmgReduction = receiver.BaseDamageReduction;
            if (receiver.Inventory is ContainerItem container)
            {
                foreach (var item in container.GetSubItems())
                {
                    if(item is DefenceItem defenceItem)
                    {
                        dmgReduction += defenceItem.GetDamageReduction();
                    }
                    
                }
            }
            else
            {
                if (receiver.Inventory is DefenceItem defenceItem)
                {
                    dmgReduction += defenceItem.GetDamageReduction();
                }
            }
            PositiveInt actualDmg = (PositiveInt)Math.Round(incomingDmg * dmgReduction.DmgReductionDecimal, 0);
            actualDmg = Math.Max(actualDmg - dmgReduction.DmgReductionFlat, 0);
            return actualDmg;
        }
    }
}
