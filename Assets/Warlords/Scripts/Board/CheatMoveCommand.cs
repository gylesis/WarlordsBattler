using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Warlords.Board
{
    public class CheatMoveCommand : IMovingCommand
    {
        private TweenerCore<Vector3, Vector3, VectorOptions> _doLocalMove;

        public async UniTask Move(MoveCommandContext context)
        {
            Transform transform = context.Transform;

            _doLocalMove?.Complete();
            _doLocalMove = transform.DOLocalMove(context.TargetPos, 1).SetEase(Ease.Linear);
        }
    }
}