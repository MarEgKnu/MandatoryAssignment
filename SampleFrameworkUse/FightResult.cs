using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class FightResult : IFightResult
    {
        public FightResult(bool sucess, string resultMessage, bool isDead)
        {
            Sucess = sucess;
            ResultMessage = resultMessage;
            IsDead = isDead;

        }
        public bool Sucess { get; }

        public string ResultMessage { get; }

        public bool IsDead { get; }
    }
}
