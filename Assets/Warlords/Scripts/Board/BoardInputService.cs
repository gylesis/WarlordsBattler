using System.Linq;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BoardInputService : ITickable, IBoardInputService
    {
        private readonly Camera _camera;
        private readonly LayerMask _battlefieldsLayerMask;

        public Subject<BoardInputContext> BoardClicked { get; } = new Subject<BoardInputContext>();
        public Subject<BoardInputContext> BoardHover { get; } = new Subject<BoardInputContext>();

        private float _timer;
        private BattlefieldsContainer _battlefieldsContainer;

        private BoardInputService(CameraService cameraService, LayerMask battlefieldsLayerMask, BattlefieldsContainer battlefieldsContainer)
        {
            _battlefieldsContainer = battlefieldsContainer;
            _battlefieldsLayerMask = battlefieldsLayerMask;
            _camera = cameraService.Camera;
        }

        public void Tick()
        {
            ClickCheck();

            _timer += Time.deltaTime;

            if (_timer > 0.05f)
            {
                _timer = 0;
                HoverCheck();
            }
        }

        private void HoverCheck()
        {
            var boardInputContext = new BoardInputContext();
            
            var raycast = Raycast(out var hit);

            if (raycast)
            {
                var tryGetComponent = hit.collider.transform.parent.TryGetComponent(out Battlefield battlefield);

                /*if (tryGetComponent)
                {
                    Debug.Log($"Hit cell {battlefield.name}");
                }
                else
                {
                     Debug.Log($"Hit something that isn't cell {hit.collider.name}");
                }
                */

                boardInputContext.Battlefield = battlefield;

            }
            
            BoardHover.OnNext(boardInputContext);
        }

        private void ClickCheck()
        {
            var mouseButtonUp = Input.GetMouseButtonUp(0);
            
            var boardInputContext = new BoardInputContext();

            if (mouseButtonUp == false) return;
            
            var raycast = Raycast(out var hit);

            if (raycast == false) return;
            
            var tryGetComponent = hit.collider.transform.parent.TryGetComponent(out Battlefield battlefield);

            /*if (tryGetComponent)
            {
                Debug.Log($"Hit cell {battlefield.name}");
            }
            else
            {
                 Debug.Log($"Hit something that isn't cell {hit.collider.name}");
            }*/

            bool isEnemyCell = _battlefieldsContainer.MyBattlefields.Contains(battlefield) == false;

            boardInputContext.UnitInfo = battlefield.BattlefieldUnitInfo;
            boardInputContext.Battlefield = battlefield;
            boardInputContext.IsEnemyCell = isEnemyCell;
            
            BoardClicked.OnNext(boardInputContext);
        }
        
        private bool Raycast(out RaycastHit hit)
        {
            Vector3 mousePosition = Input.mousePosition;
                
            Ray screenToViewportPoint = _camera.ScreenPointToRay(mousePosition);
                
            var raycast = Physics.Raycast(screenToViewportPoint, out hit, 999, _battlefieldsLayerMask);
                
           // Debug.DrawRay(screenToViewportPoint.origin, _camera.transform.forward * 100);

            return raycast;
        }
        
    }

    public class BoardInputContext
    {
        public Battlefield Battlefield;
        public BattlefieldUnitInfo UnitInfo;
        public bool IsEnemyCell;
    }
}