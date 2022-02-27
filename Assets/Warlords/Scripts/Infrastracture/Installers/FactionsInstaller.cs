using UnityEngine;
using Warlords.Faction;
using Warlords.Infrastracture.Factory;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class FactionsInstaller : MonoInstaller
    {
        [SerializeField] private FactionsContainer _factionsContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<FactionsContainer>().FromInstance(_factionsContainer).AsSingle();
            Container.Bind<FactionsViewFactory>().AsSingle();
            Container.Bind<AvailableFactions>().AsSingle();
            Container.BindInterfacesAndSelfTo<FactionButtonsHandler>().AsSingle().NonLazy();
        }
    }
}