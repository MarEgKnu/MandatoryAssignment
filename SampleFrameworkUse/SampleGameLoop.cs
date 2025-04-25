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
        private bool finished = false;
        public void Start(IGameState state)
        {
            while (!finished)
            {
                foreach (PositiveInt ID in state.World.WorldEntities.GetIDKeys().ToArray())
                {
                    IWorldEntity entity = state.World.WorldEntities.Read(ID);
                    if(entity.IsPlayer)
                    {
                        state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, @"Players turn now! Press L to move left, R to move right, U to move up, D to move down, A to start an attack, or Q to quit");
                        state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, $"Current player coordinates: {entity.Position}");
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
                            case 'A':
                                PlayerInitAttack(entity, state);
                                break;
                        }
                    }
                    else
                    {
                        MonsterFightPlayer(entity, state);
                    }
                }
            }
        }

        private void PlayerInitAttack(IWorldEntity player, IGameState state)
        {
            
                state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, @"Choose an attack direction! Press L to attack left, R for right, U for up, D for down, or Q to quit");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'L':
                        PlayerAttack(player, state, -1, 0);
                        break;
                    case 'U':
                        PlayerAttack(player, state, 0, 1);
                        break;
                    case 'D':
                        PlayerAttack(player, state, 0, -1);
                        break;
                    case 'R':
                        PlayerAttack(player, state, 1, 0);
                        break;
                    case 'Q':
                        finished = true;
                        break;
                }
                  
                
        }
        private void PlayerAttack(IWorldEntity player, IGameState state, int x, int y)
        {
            int atkY = (int)player.Position.y + y;
            int atkX = (int)player.Position.x + x;
            IFightResult result = state.World.CombatManager.TryFight(player, atkX, atkY, state.World);
            state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, $"Player fight result: {result.Sucess}, reason: {result.ResultMessage}");
        }
        private void MonsterFightPlayer(IWorldEntity entity, IGameState state)
        {
            foreach(IWorldEntity target in state.World.WorldEntities.ReadAll())
            {
                if(target.IsPlayer)
                {
                    IFightResult result = state.World.CombatManager.TryFight(entity, target.ID, state.World);
                    if(result.Sucess)
                    {
                        state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, $"Monster fight result: {result.Sucess}, reason: {result.ResultMessage}");
                    }
                }
            }
        }
        private void MoveEntity(IWorldEntity entity, IGameState state, int x, int y)
        {
            int newY = (int)entity.Position.y + y;
            int newX = (int)entity.Position.x + x;
            IMoveResult result = state.World.MovementManager.TryMoveEntity(entity ,newX, newY , state.World);
            if(entity.IsPlayer)
            {
                state.Logger.TraceEvent(System.Diagnostics.TraceEventType.Information, 0, $"Player move result: {result.IsSuccess}, with with reason: {result.Message}");
            }
                     
        }
    }
}
