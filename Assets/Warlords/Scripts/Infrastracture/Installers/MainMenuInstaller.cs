using System;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Warlords.Faction;
using Warlords.Player;
using Warlords.UI;
using Warlords.UI.PopUp;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class MainMenuInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private FactionsContainer _factionsContainer;
        [SerializeField] private FactionsView _factionsView;
        [SerializeField] private FactionView _factionViewPrefab;
        [SerializeField] private ListOfUpgradesForHexagons _listOfUpgradesForHexagons;
        [SerializeField] private CurtainService _curtainService;
        [SerializeField] private MenuTagsContainer _menuTagsContainer;
        [SerializeField] private PopUpsService _popUpsService; 
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuInstaller>().FromInstance(this).AsSingle();
            
            Container.Bind<CurtainService>().FromInstance(_curtainService).AsSingle();

            Container.Bind<FactionsContainer>().FromInstance(_factionsContainer).AsSingle();

            Container.Bind<FactionsViewFactory>().AsSingle();

            Container.Bind<FactionView>().FromInstance(_factionViewPrefab).AsSingle();

            Container.Bind<PlayerInfoSetter>().AsSingle().NonLazy();

            Container.Bind<AvailableFactions>().AsSingle();

            Container.Bind<ListOfUpgradesForHexagons>().FromInstance(_listOfUpgradesForHexagons).AsSingle();
            Container.Bind<IGeneratable>().To<FactionsView>().FromInstance(_factionsView);

            Container.Bind<PlayerInfoChangeRegister>().AsSingle().NonLazy();
            Container.Bind<PlayerInfoChangedDispatcher>().AsSingle().NonLazy();
            Container.Bind<PlayerNameSetter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerNameFilter>().AsSingle().NonLazy();

            Container.Bind<UIFactory>().AsSingle();

            Container.Bind<FirstActionsChecker>().AsSingle().NonLazy();

            Container.Bind<MenuTagsContainer>().FromInstance(_menuTagsContainer).AsSingle();

            Container.Bind<FirstActionsData>().AsSingle().NonLazy();

            Container.Bind<PopUpsService>().FromInstance(_popUpsService).AsSingle();
        }

        public async void Initialize()
        {
            await Load();
        }
        
        private async Task Load()
        {
            var generatables = Container.ResolveAll<IGeneratable>();

            foreach (IGeneratable generatable in generatables)
            {
                await generatable.Generate();
            }

        }
        
    }
}