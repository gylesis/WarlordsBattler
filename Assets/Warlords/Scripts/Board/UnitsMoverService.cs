using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using Warlords.Battle.Field;

namespace Warlords.Board
{
    public class UnitsMoverService : IActionDispatcher, IBoardUpdateNotifier
    {
        private readonly BoardDataService _boardDataService;
        private readonly Stack<IMovingCommand> _commands = new Stack<IMovingCommand>();
        
        public ActionDispatchService DispatchService { get; set; }
        public Subject<BoardUpdateContext> BoardUpdate { get; } = new Subject<BoardUpdateContext>();

        public UnitsMoverService(BoardDataService boardDataService)
        {
            _boardDataService = boardDataService;
        }
        
        public async void Move(Unit unit, Battlefield targetBattlefield, IMovingCommand command = null)
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
            
            await movingCommand.Move(moveCommandContext);
            await UniTask.Delay(100);
            
            var actContext = new ActContext();
            actContext.ActionType = ActionType.Move;
            DispatchService.Dispatch(actContext);
            
            var boardUpdateContext = new BoardUpdateContext();
            BoardUpdate.OnNext(boardUpdateContext);
            
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