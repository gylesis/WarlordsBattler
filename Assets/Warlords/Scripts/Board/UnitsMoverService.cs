using UnityEngine;

namespace Warlords.Board
{
    public class UnitsMoverService
    {
        private readonly BoardGridService _boardGridService;

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
            {
                movingCommand = unit.MovingCommand;
            }
            else
            {
                movingCommand = command;
            }
            
            movingCommand.Move(unit.transform,startPos,targetPos);
        }
    }
}