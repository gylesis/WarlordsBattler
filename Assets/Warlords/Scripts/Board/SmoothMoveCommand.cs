using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Warlords.Board
{
    public class SmoothMoveCommand : IMovingCommand
    {
        private TweenerCore<Vector3, Vector3, VectorOptions> _doLocalMove;

        public void Move(Transform transform, Vector3 startPos, Vector3 targetPos)
        {
            Debug.Log("Smooth");

            _doLocalMove?.Complete();
            _doLocalMove = transform.DOLocalMove(targetPos, 1).SetEase(Ease.Linear);
        }
    }
}