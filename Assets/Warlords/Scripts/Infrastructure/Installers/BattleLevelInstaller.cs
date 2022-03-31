using UnityEngine;
using Warlords.Board;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class BattleLevelInstaller : MonoInstaller
    {
        [SerializeField] private CameraService _cameraService;
        [SerializeField] private BattlefieldsContainer _battlefieldsContainer;
        [SerializeField] private LayerMask _battlefieldLayer;
        [SerializeField] private GameObject _cube;
        public override void InstallBindings()
        {
            Container.Bind<CameraService>().FromInstance(_cameraService).AsSingle();
            Container.BindInterfacesAndSelfTo<BoardInputService>().AsSingle().WithArguments(_battlefieldLayer).NonLazy();
            Container.Bind<BattlefieldsRegistry>().AsSingle().NonLazy();
            Container.Bind<BattlefieldsContainer>().FromInstance(_battlefieldsContainer).AsSingle();
            Container.Bind<BattlefieldsOutlineService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BattlefieldUnitMover>().AsSingle().WithArguments(_cube).NonLazy();
        }
    }
}