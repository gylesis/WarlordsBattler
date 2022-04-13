using System.Collections.Generic;

namespace Warlords.Board
{
    public class UnitsMoverService
    {
        private readonly BoardDataService _boardDataService;

        private readonly Stack<IMovingCommand> _commands = new Stack<IMovingCommand>();
        private BattlefieldInputAllowService _inputAllowService;

        public UnitsMoverService(BoardDataService boardDataService, BattlefieldInputAllowService inputAllowService)
        {
            _inputAllowService = inputAllowService;
            _boardDataService = boardDataService;
        }
        
        public void Move(Unit unit, Battlefield targetBattlefield, IMovingCommand command = null)
        {
            var tryGetUnitBattlefield = _boardDataService.TryGetUnitBattlefield(unit, out Battlefield startBattlefield);

            if (tryGetUnitBattlefield)
            {
                startBattlefield.BattlefieldUnitInfo.Unit = null;
                targetBattlefield.BattlefieldUnitInfo.Unit = unit;
            }

            IMovingCommand movingCommand;

            if (command == null)
                movingCommand = unit.MovingCommand;
            else
                movingCommand = command;

            var moveCommandContext = new MoveCommandContext();

            moveCommandContext.UnitTransform = unit.transform;
            moveCommandContext.StartBattlefield = startBattlefield;
            moveCommandContext.TargetBattlefield = targetBattlefield;
            
            movingCommand.Move(moveCommandContext);
            
            _inputAllowService.Disallow();
            
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