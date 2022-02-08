using System;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Warlords.Faction;
using Warlords.Player;
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
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuInstaller>().FromInstance(this).AsSingle();
            
            Container.Bind<FactionsContainer>().FromInstance(_factionsContainer).AsSingle();

            Container.Bind<FactionsViewFactory>().AsSingle();

            Container.Bind<FactionView>().FromInstance(_factionViewPrefab).AsSingle();

            Container.Bind<PlayerInfoSetter>().AsSingle().NonLazy();
            
            Container.Bind<FilteredFactions>().AsSingle();

            Container.Bind<ListOfUpgradesForHexagons>().FromInstance(_listOfUpgradesForHexagons).AsSingle();
            Container.Bind<IGeneratable>().To<FactionsView>().FromInstance(_factionsView);

            Container.Bind<PlayerInfoChangeRegister>().AsSingle().NonLazy();
            Container.Bind<PlayerInfoChangedDispatcher>().AsSingle().NonLazy();
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