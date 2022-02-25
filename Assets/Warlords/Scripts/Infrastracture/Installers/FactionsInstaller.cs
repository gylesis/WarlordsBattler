using UnityEngine;
using Warlords.Faction;
using Warlords.Infrastracture.Factory;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class FactionsInstaller : MonoInstaller
    {
        [SerializeField] private FactionsContainer _factionsContainer;
        [SerializeField] private FactionView _factionViewPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<FactionsContainer>().FromInstance(_factionsContainer).AsSingle();
            Container.Bind<FactionsViewFactory>().AsSingle();
            Container.Bind<FactionView>().FromInstance(_factionViewPrefab).AsSingle();
            Container.Bind<AvailableFactions>().AsSingle();

        }
    }
}