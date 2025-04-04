using MandatoryAssignment.AbstractModels;
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
        IGridData[,] _grid;
        public WorldGrid(uint x, uint y)
        {
            _grid = new IGridData[x, y];
        }

        public uint MaxY { get { return (uint)_grid.GetLongLength(1); } }

        public uint MaxX { get { return (uint)_grid.GetLongLength(0); } }

        public IWorldObject? GetObjectAtCoordinate(Coordinate coords)
        {
            return GameState.CurrentState.World.WorldObjects.Read( _grid[coords.x, coords.y].WorldObjectID);
        }
    }
}
