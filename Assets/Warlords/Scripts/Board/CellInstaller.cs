using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class CellInstaller : MonoInstaller
    {
        [SerializeField] private BattlefieldView _battlefieldView;
        [SerializeField] private BattlefieldUnitInfo _battlefieldUnitInfo;
        
        private BattlefieldsSaveLoadService _battlefieldsSaveLoadService;
        private BoardGridData _boardGridData;

        [Inject]
        private void Init(BattlefieldsSaveLoadService battlefieldsSaveLoadService, BoardGridData boardGridData)
        {
            _boardGridData = boardGridData;
            _battlefieldsSaveLoadService = battlefieldsSaveLoadService;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<BattlefieldView>().FromInstance(_battlefieldView).AsSingle();
            Container.Bind<BattlefieldUnitInfo>().FromInstance(_battlefieldUnitInfo).AsSingle();

            var index = _boardGridData.GetIndex(GetComponent<Battlefield>());
            
            BattlefieldData battlefieldData = new BattlefieldData();

            battlefieldData.Index = index;

            Container.Bind<BattlefieldData>().FromInstance(battlefieldData);
        }
    }
}