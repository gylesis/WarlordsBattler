using UnityEngine;
using Warlords.Battle.Field;
using Warlords.Board;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class BattleLevelInstaller : MonoInstaller
    {
        [SerializeField] private CameraService _cameraService;
        [SerializeField] private BattlefieldsContainer _battlefieldsContainer;
        [SerializeField] private LayerMask _battlefieldLayer;
        [SerializeField] private BoardGridData _boardGridData;
        [SerializeField] private ActionButtonsContainer _actionButtonsContainer;    
        
        public override void InstallBindings()
        {
            BindMovingCommands();

            Container.Bind<BoardUpdateService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BoardDataService>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<BattlefieldUnitMover>().AsSingle();
            Container.BindInterfacesAndSelfTo<BoardCellsTree>().AsSingle();

            Container.BindInterfacesAndSelfTo<BoardUnitsInitializer>().AsSingle().NonLazy();
            Container.Bind<ActionButtonsView>().AsSingle().NonLazy();
            Container.Bind<ActionDispatchService>().AsSingle().NonLazy();
            Container.Bind<ActionDispatcherLinker>().AsSingle().NonLazy();

            Container.Bind<BattlefieldInputAllowService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BattlefieldUnitPlacer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BoardInputDispatcher>().AsSingle().NonLazy();

            Container.Bind<ActionButtonsContainer>().FromInstance(_actionButtonsContainer).AsSingle();
            Container.BindInterfacesAndSelfTo<ActionButtonsHandler>().AsSingle().NonLazy();

            Container.Bind<IBoardCellsDataLoader>().To<TextFileBoardCellsDataLoader>().AsSingle().NonLazy();
            Container.Bind<BoardGridData>().FromInstance(_boardGridData).AsSingle().NonLazy();
            Container.Bind<MoveCommandsContainer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UnitsMoverService>().AsSingle();
            Container.Bind<BattlefieldsSaveLoadService>().AsSingle().NonLazy();
            Container.Bind<CameraService>().FromInstance(_cameraService).AsSingle();
            Container.BindInterfacesAndSelfTo<BoardPointerInputService>().AsSingle().WithArguments(_battlefieldLayer).NonLazy();
            Container.Bind<BattlefieldsContainer>().FromInstance(_battlefieldsContainer).AsSingle();

            Container.BindInterfacesAndSelfTo<BattlefieldsOutlineService>().AsSingle().NonLazy();

            
            Container.Bind<SceneAsyncLoadingsLinker>().AsSingle().NonLazy();

            Container.Bind<UnitsFactory>().AsSingle().WithArguments(Resources.Load<Unit>(AssetsPath.UnitPrefab));
        }

        private void BindMovingCommands()
        {
            Container.Bind<IMovingCommand>().To<CheatMoveCommand>().AsTransient();
            Container.Bind<IMovingCommand>().To<TeleportMoveCommand>().AsTransient();
            Container.Bind<IMovingCommand>().To<MoveByCellsCommand>().AsTransient();
        }
        
    }
}