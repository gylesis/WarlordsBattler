using UnityEngine;

namespace Warlords.Board
{
    public class Battlefield : MonoBehaviour
    {
        [SerializeField] private BattlefieldView _battlefieldView;
        [SerializeField] private BattlefieldUnitInfo _battlefieldUnitInfo;

        public BattlefieldUnitInfo BattlefieldUnitInfo => _battlefieldUnitInfo;
        public BattlefieldView BattlefieldView => _battlefieldView;

        public void Init(BattlefieldData data)
        {
            
        }
    }

    public class UnitsMover
    {
        public void Move(Movable movable, Battlefield battlefield) { }
    }

    public abstract class Movable : MonoBehaviour
    {
        public abstract void Move();
    }

    public class SmoothMovable : Movable
    {
        public override void Move() { }
    }
}