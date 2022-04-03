using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class Battlefield : MonoBehaviour
    {
        private BattlefieldView _battlefieldView;
        private BattlefieldUnitInfo _battlefieldUnitInfo;
        private BattlefieldData _battlefieldData;
     
        public BattlefieldUnitInfo BattlefieldUnitInfo => _battlefieldUnitInfo;
        public BattlefieldView BattlefieldView => _battlefieldView;
        public BattlefieldData BattlefieldData => _battlefieldData;

        [Inject]
        private void Init(BattlefieldView battlefieldView, BattlefieldUnitInfo battlefieldUnitInfo, BattlefieldData battlefieldData)
        {
            _battlefieldData = battlefieldData;
            _battlefieldUnitInfo = battlefieldUnitInfo;
            _battlefieldView = battlefieldView;
        }
    }
}