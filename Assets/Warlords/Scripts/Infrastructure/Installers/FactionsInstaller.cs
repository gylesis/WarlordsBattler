using UnityEngine;
using Warlords.Factions;
using Warlords.Infrastructure.Factory;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class FactionsInstaller : MonoInstaller
    {
        [SerializeField] private FactionsContainer _factionsContainer;
        [SerializeField] private Transform _spawnParent;    
        
        public override void InstallBindings()
        {
            var factionViewFactoryContext = new FactionViewFactoryContext();
            factionViewFactoryContext.SpawnParent = _spawnParent;

            Container.BindInterfacesAndSelfTo<FactionsViewSpawner>().AsSingle().NonLazy();
            Container.Bind<FactionViewFactoryContext>().FromInstance(factionViewFactoryContext).AsSingle();
            Container.Bind<FactionsContainer>().FromInstance(_factionsContainer).AsSingle();
            Container.Bind<FactionViewFactory>().AsSingle();
            Container.Bind<AvailableFactions>().AsSingle();
            Container.BindInterfacesAndSelfTo<FactionsButtonsHandler>().AsSingle().NonLazy();
        }
    }
    
}