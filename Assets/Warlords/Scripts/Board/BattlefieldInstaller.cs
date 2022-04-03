using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BattlefieldInstaller : MonoInstaller
    {
        [SerializeField] private BattlefieldView _battlefieldView;
        [SerializeField] private BattlefieldUnitInfo _battlefieldUnitInfo;
        
        private BattlefieldsSaveLoadService _battlefieldsSaveLoadService;

        [Inject]
        private void Init(BattlefieldsSaveLoadService battlefieldsSaveLoadService)
        {
            _battlefieldsSaveLoadService = battlefieldsSaveLoadService;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<BattlefieldView>().FromInstance(_battlefieldView).AsSingle();
            Container.Bind<BattlefieldUnitInfo>().FromInstance(_battlefieldUnitInfo).AsSingle();

            BattlefieldData battlefieldData = _battlefieldsSaveLoadService.GetData();
            
            Container.Bind<BattlefieldData>().FromInstance(battlefieldData);
        }
    }
}