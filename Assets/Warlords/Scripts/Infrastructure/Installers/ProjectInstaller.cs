using UnityEngine;
using Warlords.Infrastructure.States;
using Warlords.Player;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private PlayerInfoStaticData _playerInfoStaticData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();

            Container.Bind<PlayerInfoStaticData>().FromInstance(_playerInfoStaticData).AsSingle();
            Container.Bind<ISaveLoadDataService>().To<PlayerPrefsSaveLoadDataService>().AsSingle().NonLazy();
            Container.Bind<IPlayerInfoInitializer>().To<PlayerInfoInitializer>().AsSingle().NonLazy();

            Container.Bind<ApplicationURLOpener>().AsSingle().NonLazy();
            
            Container.Bind<CurtainService>().FromMethod(context =>
                {
                    var curtainService =
                        Container.InstantiatePrefabResourceForComponent<CurtainService>(AssetsPath.CurtainService);
                    return curtainService;
                })
                .AsSingle()
                .NonLazy();

            Container.Bind<AsyncLoadingsRegister>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AsyncLoadingsDispatcher>().AsSingle().NonLazy();

            Container.Bind<SceneLoader>().FromMethod(context =>
                    {
                        var sceneLoader =
                            Container.InstantiatePrefabResourceForComponent<SceneLoader>(AssetsPath.SceneLoader);

                        return sceneLoader;
                    }
                )
                .AsSingle();

           // BindStateMachine();
        }


        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsTransient().NonLazy();
            
            Container.Bind<StateMachine>().AsSingle().NonLazy();
        }

        public async void Initialize()
        {
            var saveLoadDataService = Container.Resolve<ISaveLoadDataService>();
            await saveLoadDataService.Load();

            var sceneLoader = Container.Resolve<SceneLoader>();

            await sceneLoader.LoadScene("MainMenu");
        }
    }
}