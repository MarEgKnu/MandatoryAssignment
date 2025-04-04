using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Models
{
    public class WorldGrid : IGrid
    {
        IWorldObject[,] _grid;
        public WorldGrid(uint x, uint y)
        {
            _grid = new IWorldObject[x, y];
        }
        public IWorldObject GetObjectAtCoordinate(Coordinate coords)
        {
            return _grid[coords.x, coords.y];
        }
    }
}
