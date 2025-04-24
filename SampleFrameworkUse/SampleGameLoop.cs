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
    /// Sample of what a gameloop can look like, very basic with just movement
    /// </summary>
    public class SampleGameLoop : IGameLoop
    {
        public void Start(IGameState state)
        {
            bool finished = false;
            while (!finished)
            {
                foreach (IWorldEntity entity in state.World.WorldEntities.ReadAll())
                {
                    if(entity.IsPlayer)
                    {
                        state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, @"Players turn now! Press L to move left, R to move right, U to move up, D to move down, or Q to quit");
                        ConsoleKeyInfo key = Console.ReadKey();
                        Coordinate newPos = new Coordinate(entity.Position.x - 1, entity.Position.y);
                        switch (key.KeyChar)
                        {
                            case 'L':
                                MoveEntity(entity, state, -1, 0);
                                break;
                            case 'U':
                                MoveEntity(entity, state, 0, 1);
                                break;
                            case 'D':
                                MoveEntity(entity, state, 0, -1);
                                break;
                            case 'R':
                                MoveEntity(entity, state, 1, 0);
                                break;
                            case 'Q':
                                finished = true;
                                break;
                        }
                    }
                }
            }
        }

        private void MoveEntity(IWorldEntity entity, IGameState state, int x, int y)
        {
            Coordinate newPos = new Coordinate(entity.Position.x + x, entity.Position.y + y);
            IMoveResult result = entity.Move(newPos, state.World);
            if(entity.IsPlayer)
            {
                state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, $"Player move result: {result.IsSuccess}, with with reason: {result.Message}");
            }
            
            
        }
    }
}
