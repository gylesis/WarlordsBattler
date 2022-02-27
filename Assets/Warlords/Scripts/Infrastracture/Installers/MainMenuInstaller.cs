using UnityEngine;
using Warlords.Infrastracture.Factory;
using Warlords.Player;
using Warlords.Player.Attributes;
using Warlords.UI.Menu;
using Warlords.UI.PopUp;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private ListOfUpgradesForHexagons _listOfUpgradesForHexagons;
       
        [SerializeField] private MenuTagsContainer _menuTagsContainer;
        [SerializeField] private MenuSwitcher _menuSwitcher;    
        
        [SerializeField] private PopUpsService _popUpsService;

        [SerializeField] private LeftAttributesUpgradesAmountView _leftAttributesUpgradesAmountView;
        
        [SerializeField] private AppearanceContainer[] _appearanceContainers;

        public override void InstallBindings()
        {
            Container.Bind<ListOfUpgradesForHexagons>().FromInstance(_listOfUpgradesForHexagons).AsSingle();

            Container.Bind<UIFactory>().AsSingle();

            Container.Bind<FirstActionsChecker>().AsSingle().NonLazy();

            Container.Bind<MenuSwitcher>().FromInstance(_menuSwitcher).AsSingle();
            Container.Bind<MenuButtonsHandler>().AsSingle().NonLazy();
            Container.Bind<MenuTagsContainer>().FromInstance(_menuTagsContainer).AsSingle();

            Container.Bind<LeftAttributesUpgradesAmountView>().FromInstance(_leftAttributesUpgradesAmountView).AsSingle();
            Container.Bind<PlayerAttributesProvider>().AsSingle().NonLazy();
            Container.Bind<AttributesUpgradeButtonsHandler>().AsSingle().NonLazy();

            Container.Bind<PopUpsService>().FromInstance(_popUpsService).AsSingle();

            Container.Bind<AppearanceContainer[]>().FromInstance(_appearanceContainers).AsSingle();
            Container.Bind<AppearanceController>().AsSingle().NonLazy();
           
        }

    }
}