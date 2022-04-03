using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Utils;
using Object = UnityEngine.Object;

namespace Warlords.Board
{
    public class BattlefieldUnitMover : IDisposable, IAsyncLoad
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private readonly UnitsMoverService _unitsMoverService;

        private readonly IMovingCommand _smoothMoveCommand = new CheatMoveCommand();
        private readonly IMovingCommand _teleportMoveCommand = new TeleportMoveCommand();

        private Battlefield _chosenBattlefield;
        private Unit _unit;

        public BattlefieldUnitMover(IBoardInputService boardInputService, UnitsMoverService unitsMoverService)
        {
            _unitsMoverService = unitsMoverService;

            boardInputService.BoardClicked.Subscribe((PlaceUnit)).AddTo(_compositeDisposable);
            boardInputService.BoardClicked.Subscribe((OnBoardClicked)).AddTo(_compositeDisposable);
        }

        public async UniTask AsyncLoad()
        {
            _unit = await Resources.LoadAsync<Unit>(AssetsPath.UnitPrefab).ToUniTask() as Unit;
        }

        private void OnBoardClicked(BoardInputContext context)
        {
            if (context.InputButton != InputButton.Left) return;

            if (context.Battlefield == null) return;

            if (_chosenBattlefield == null)
            {
                if (context.Battlefield.BattlefieldUnitInfo.Unit != null)
                    _chosenBattlefield = context.Battlefield;
            }
            else
            {
                if (context.Battlefield.BattlefieldUnitInfo.Unit == null)
                {
                    _unitsMoverService.Move(_chosenBattlefield.BattlefieldUnitInfo.Unit, context.Battlefield);
                    _chosenBattlefield = null;
                }
            }
        }

        private void PlaceUnit(BoardInputContext context)
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

            var unit = Object.Instantiate(_unit); // pool

            Vector3 localScale = unit.transform.localScale;
            localScale.y *= 2;

            unit.transform.localScale = localScale;
            unit.transform.position = position;

            unitInfo.Unit = unit.GetComponent<Unit>();

            IMovingCommand movingCommand;
            Color color;

            if (context.Battlefield.BattlefieldData.Index % 2 == 0)
            {
                movingCommand = _smoothMoveCommand;
                color = Color.white;
            }
            else
            {
                movingCommand = _teleportMoveCommand;
                color = Color.blue;
            }

            unitInfo.Unit.MovingCommand = movingCommand;
            unitInfo.Unit.UnitView.SetColor(color);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }

}