﻿using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IGrid
    {
        IWorldObject GetObjectAtCoordinate(Coordinate coords); 
    }
}
