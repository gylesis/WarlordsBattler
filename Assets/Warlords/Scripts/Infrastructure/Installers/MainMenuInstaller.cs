using UnityEngine;
using Warlords.Infrastructure.Factory;
using Warlords.UI.Appearance;
using Warlords.UI.Menu;
using Warlords.UI.PopUp;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private ListOfUpgradesForHexagons _listOfUpgradesForHexagons;
       
        [SerializeField] private MenuTagsContainer _menuTagsContainer;
        [SerializeField] private MenuSwitcher _menuSwitcher;    
        
        [SerializeField] private PopUpsService _popUpsService;

        [SerializeField] private AppearanceViewContainer[] _appearanceContainers;
        [SerializeField] private RenderCamera _renderCamera;
        
        public override void InstallBindings()
        {
            BindPopUps();

            Container.Bind<ListOfUpgradesForHexagons>().FromInstance(_listOfUpgradesForHexagons).AsSingle();

            Container.Bind<FirstActionsChecker>().AsSingle().NonLazy();

            Container.Bind<MenuSwitcher>().FromInstance(_menuSwitcher).AsSingle();
            Container.Bind<MenuButtonsHandler>().AsSingle().NonLazy();
            Container.Bind<MenuTagsContainer>().FromInstance(_menuTagsContainer).AsSingle();

            Container.Bind<RenderCamera>().FromInstance(_renderCamera).AsSingle();
            Container.Bind<AppearanceViewContainer[]>().FromInstance(_appearanceContainers).AsSingle();
            Container.Bind<AppearanceController>().AsSingle().NonLazy();
        }

        private void BindPopUps()
        {
            var popUpFactoryContext = new PopUpFactoryContext();
            popUpFactoryContext.SpawnParent = _popUpsService.transform;

            Container.Bind<PopUpsService>().FromInstance(_popUpsService).AsSingle();
            Container.Bind<PopUpFactoryContext>().FromInstance(popUpFactoryContext).AsSingle();
            Container.Bind<PopUpsFactory>().AsSingle();
        }
    }
}