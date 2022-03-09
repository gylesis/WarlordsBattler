using UnityEngine;
using Warlords.Infrastructure.Factory;
using Warlords.Player.Attributes;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class AttributesInstaller : MonoInstaller
    {
        [SerializeField] private PlayerAttributesStaticData _playerAttributesStaticData;    
        [SerializeField] private LeftAttributesUpgradesAmountView _leftAttributesUpgradesAmountView;
        [SerializeField] private Transform _attributesSpawnParent;  
        
        public override void InstallBindings()
        {
            var playerAttributesViewFactoryContext = new PlayerAttributesViewFactoryContext();
            playerAttributesViewFactoryContext.SpawnParent = _attributesSpawnParent;

            Container.Bind<PlayerAttributesViewFactoryContext>().FromInstance(playerAttributesViewFactoryContext).AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerAttributesViewSpawner>().AsSingle().NonLazy();
            Container.Bind<PlayerAttributeViewFactory>().AsSingle();
            Container.Bind<LeftAttributesUpgradesAmountView>().FromInstance(_leftAttributesUpgradesAmountView).AsSingle();
            Container.Bind<PlayerAttributesProvider>().AsSingle().NonLazy();
            Container.Bind<AttributesUpgradeButtonsHandler>().AsSingle().NonLazy();
            Container.Bind<PlayerAttributesViewService>().AsSingle().NonLazy();

            Container.Bind<PlayerAttributesStaticData>().FromInstance(_playerAttributesStaticData).AsSingle();
        }
    }
}