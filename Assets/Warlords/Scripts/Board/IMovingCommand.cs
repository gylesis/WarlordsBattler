using UnityEngine;

namespace Warlords.Board
{
    public interface IMovingCommand
    {
        void Move(Transform transform, Vector3 startPos, Vector3 targetPos);
    }
}