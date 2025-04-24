//using MandatoryAssignment.AbstractModels;
//using MandatoryAssignment.Interfaces;
//using MandatoryAssignment.Structs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MandatoryAssignment.Models
//{
//    public class WorldGrid : IGrid
//    {
//        IGridData[,] _grid;
//        public WorldGrid(uint x, uint y)
//        {
//            _grid = new IGridData[x, y];
//        }

//        public PositiveInt MaxY { get { return _grid.GetLength(1); } }

//        public PositiveInt MaxX { get { return _grid.GetLength(0); } }

//        public IWorldObject? GetObjectAtCoordinate(Coordinate coords)
//        {
//            return GameState.CurrentState.World.WorldObjects.Read( _grid[coords.x, coords.y].WorldObjectID);
//        }
//    }
//}
