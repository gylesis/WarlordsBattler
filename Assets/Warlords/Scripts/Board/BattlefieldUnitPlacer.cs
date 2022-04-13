using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Utils;

namespace Warlords.Board
{
    public class BattlefieldUnitPlacer : IBoardClickedListener, IAsyncLoad
    { 
        private Unit _unit;
        private MoveCommandsContainer _moveCommandsContainer;

        public BattlefieldUnitPlacer(MoveCommandsContainer moveCommandsContainer)
        {
            _moveCommandsContainer = moveCommandsContainer;
        }
        
        public async UniTask AsyncLoad()
        {
            _unit = await Resources.LoadAsync<Unit>(AssetsPath.UnitPrefab).ToUniTask() as Unit;
        }
        
        public void BoardClicked(BoardInputContext context)
        {
            if (context.InputButton != InputButton.Right) return;

            if (context.Battlefield == null) return;

            if (context.IsEnemyCell) return;

            BattlefieldUnitInfo unitInfo = context.UnitInfo;
            Transform transform = unitInfo.Pivot;

            if (unitInfo.Unit)
            {
                Object.Destroy(unitInfo.Unit.gameObject);
                unitInfo.Unit = null;
                return;
            }

            Vector3 position = transform.position;

            var unit = Object.Instantiate(_unit); // create pool

            Vector3 localScale = unit.transform.localScale;
            localScale.y *= 2;

            unit.transform.localScale = localScale;
            unit.transform.position = position;

            unitInfo.Unit = unit.GetComponent<Unit>();

            IMovingCommand movingCommand;
            Color color;

            if (context.Battlefield.BattlefieldData.Index % 2 == 0)
            {
                movingCommand = _moveCommandsContainer.Get<CheatMoveCommand>();
                color = Color.white;
            }
            else
            {
                movingCommand = _moveCommandsContainer.Get<TeleportMoveCommand>();
                color = Color.blue;
            }

            unitInfo.Unit.MovingCommand = movingCommand;
            unitInfo.Unit.UnitView.SetColor(color);
        }
    }
}