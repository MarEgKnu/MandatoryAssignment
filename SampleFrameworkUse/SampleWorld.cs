using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse
{
    public class SampleWorld : World
    {
        public SampleWorld(IWorldObjectRepository worldObjectRepo, IWorldEntityRepository worldEntities, IDifficultyRepository difficulties, PositiveInt maxY, PositiveInt maxX, IDifficulty selectedDiff, IMovementManager movementManager) : base(worldObjectRepo, worldEntities, difficulties, maxY, maxX, selectedDiff, movementManager)
        {
        }
    }
}
