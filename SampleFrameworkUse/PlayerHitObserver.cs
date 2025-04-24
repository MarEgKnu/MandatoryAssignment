using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.EventArguments;
using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class PlayerHitObserver : MandatoryAssignment.Interfaces.IObserver<IWorldEntity>
    {
        public void Update(IWorldEntity subject, EventArgs args)
        {
            OnHitEventArgs onHitEventArgs = (OnHitEventArgs)args;
            GameState.CurrentState.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, $"Player took {onHitEventArgs.DamageTaken} damage");
        }
    }
}
