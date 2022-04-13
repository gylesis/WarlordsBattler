using UnityEngine;

namespace Warlords.Board
{
    public struct MoveCommandContext
    {
        public Transform UnitTransform;
        public Battlefield StartBattlefield;
        public Battlefield TargetBattlefield;
    }
}