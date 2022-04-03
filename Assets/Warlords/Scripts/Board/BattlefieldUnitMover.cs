using System;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Warlords.Board
{
    public class BattlefieldUnitMover : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private GameObject _cube;
        private readonly UnitsMoverService _unitsMoverService;

        private Battlefield _chosenBattlefield;
        
        private readonly IMovingCommand _smoothMoveCommand = new SmoothMoveCommand();
        private IMovingCommand _teleportMoveCommand = new TeleportMoveCommand();

        public BattlefieldUnitMover(IBoardInputService boardInputService, GameObject cube,
            UnitsMoverService unitsMoverService)
        {
            _unitsMoverService = unitsMoverService;
            _cube = cube;

            boardInputService.BoardClicked.Subscribe((PlaceUnit)).AddTo(_compositeDisposable);
            boardInputService.BoardClicked.Subscribe((OnBoardClicked)).AddTo(_compositeDisposable);
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

            var gameObject = Object.Instantiate(_cube);

            Vector3 localScale = gameObject.transform.localScale;
            localScale.y *= 2;

            gameObject.transform.localScale = localScale;

            gameObject.transform.position = position;

            unitInfo.Unit = gameObject.GetComponent<Unit>();

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