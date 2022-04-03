using System.Collections.Generic;
using UnityEngine;

namespace Warlords.Board
{
    public class UnitsMoverService
    {
        private readonly BoardGridService _boardGridService;

        private readonly Stack<IMovingCommand> _commands = new Stack<IMovingCommand>();

        public UnitsMoverService(BoardGridService boardGridService)
        {
            _boardGridService = boardGridService;
        }
        
        public void Move(Unit unit, Battlefield targetBattlefield, IMovingCommand command = null)
        {
            var tryGetUnitBattlefield = _boardGridService.TryGetUnitBattlefield(unit, out Battlefield battlefield);

            if (tryGetUnitBattlefield)
            {
                battlefield.BattlefieldUnitInfo.Unit = null;
                targetBattlefield.BattlefieldUnitInfo.Unit = unit;
            }

            Vector3 startPos = battlefield.BattlefieldUnitInfo.Pivot.position;
            Vector3 targetPos = targetBattlefield.BattlefieldUnitInfo.Pivot.position;

            IMovingCommand movingCommand;

            if (command == null)
                movingCommand = unit.MovingCommand;
            else
                movingCommand = command;

            var moveCommandContext = new MoveCommandContext();

            moveCommandContext.Transform = unit.transform;
            moveCommandContext.StartPos = startPos;
            moveCommandContext.TargetPos = targetPos;
            
            movingCommand.Move(moveCommandContext);
            
           // ExecuteCommand(movingCommand);
        }

        private void ExecuteCommand(IMovingCommand command)
        {
            _commands.Push(command);    

            foreach (IMovingCommand movingCommand in _commands)
            {
               // await movingCommand.Move();
            }
        }

    }
}