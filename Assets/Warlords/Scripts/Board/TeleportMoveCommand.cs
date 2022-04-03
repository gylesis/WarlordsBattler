using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Warlords.Board
{
    public class TeleportMoveCommand : IMovingCommand
    {
        public async void Move(Transform transform, Vector3 startPos, Vector3 targetPos)
        {
            Debug.Log("Teleport");
            await transform.DOShakePosition(1, (Vector3.right + Vector3.forward) * 0.3f,10,10).AsyncWaitForCompletion().AsUniTask();

            transform.position = targetPos;
        }
    }
}