using System;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Warlords.Board
{
    public class BattlefieldUnitMover : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        //private Battlefield _clickedBattlefield;
        
        public BattlefieldUnitMover(IBoardInputService boardInputService)
        {
            boardInputService.BoardClicked.Subscribe((OnBoardClicked)).AddTo(_compositeDisposable);
        }

        private void OnBoardClicked(BoardInputContext context)
        {
            if(context.Battlefield == null) return;
         
            if(context.IsEnemyCell) return;
            
            BattlefieldUnitInfo unitInfo = context.UnitInfo;
            Transform transform = unitInfo.Pivot;

            if (unitInfo.Unit)
            {
                Object.DestroyImmediate(unitInfo.Unit);
                unitInfo.Unit = null;
                return;
            }
            
            Vector3 position = transform.position;

            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Vector3 localScale = gameObject.transform.localScale;
            localScale.y *= 2;

            gameObject.transform.localScale = localScale;

            position.y += localScale.y / 2;
            
            gameObject.transform.position = position;

            unitInfo.Unit = gameObject;
            
           // _clickedBattlefield = context.Battlefield;
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}