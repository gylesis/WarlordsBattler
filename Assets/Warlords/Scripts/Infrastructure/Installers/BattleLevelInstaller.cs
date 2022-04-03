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
        [SerializeField] private BoardGridData _boardGridData;
        public override void InstallBindings()
        {
            BindMovingCommands();

            Container.Bind<BoardGridData>().FromInstance(_boardGridData).AsSingle().NonLazy();
            Container.Bind<MoveCommandsContainer>().AsSingle().NonLazy();
            Container.Bind<UnitsMoverService>().AsSingle().NonLazy();
            Container.Bind<BattlefieldsSaveLoadService>().AsSingle().NonLazy();
            Container.Bind<CameraService>().FromInstance(_cameraService).AsSingle();
            Container.BindInterfacesAndSelfTo<BoardPointerInputService>().AsSingle().WithArguments(_battlefieldLayer).NonLazy();
            Container.Bind<BattlefieldsRegistry>().AsSingle().NonLazy();
            Container.Bind<BattlefieldsContainer>().FromInstance(_battlefieldsContainer).AsSingle();
            
            Container.BindInterfacesAndSelfTo<BattlefieldsOutlineService>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<BattlefieldUnitMover>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BoardGridService>().AsSingle().NonLazy();
            
            Container.Bind<AsyncLoadingsLinker>().AsSingle().NonLazy();
        }

        private void BindMovingCommands()
        {
            Container.Bind<IMovingCommand>().To<CheatMoveCommand>().AsTransient();
            Container.Bind<IMovingCommand>().To<TeleportMoveCommand>().AsTransient();
            Container.Bind<IMovingCommand>().To<MoveByCellsCommand>().AsTransient();
        }
        
    }
}