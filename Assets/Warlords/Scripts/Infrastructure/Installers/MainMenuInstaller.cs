using UnityEngine;
using Warlords.Battle;
using Warlords.Crafting;
using Warlords.Infrastructure.Factory;
using Warlords.Inventory;
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

        [SerializeField] private InventorySlotViewsContainer _inventorySlotViewsContainer;
        [SerializeField] private ItemsInfoContainer _itemsInfoContainer;
        [SerializeField] private RecipesContainer _recipesContainer;
        [SerializeField] private WorkbenchSlotsContainer _workbenchSlotsContainer;
        [SerializeField] private AcceptButtonsPopUp _acceptButtonsPopUp;
        [SerializeField] private GameModeButtonsContainer _gameModeButtonsContainer;    
            
        public override void InstallBindings()
        {
            BindPopUps();
            
            BindWorkbenchAndInventory();

            Container.Bind<GameModeButtonsHandler>().AsSingle().NonLazy();
            Container.Bind<GameModeButtonsContainer>().FromInstance(_gameModeButtonsContainer);
            
            Container.Bind<RedirectionService>().AsSingle();
            
            Container.Bind<BattleGameStarter>().AsSingle().NonLazy();
            Container.Bind<BattleGamePoller>().AsSingle().NonLazy();
            Container.Bind<BattleGameFinder>().AsSingle().NonLazy();
            Container.Bind<AcceptButtonsPopUp>().FromInstance(_acceptButtonsPopUp).AsSingle();
            
            Container
                .Bind<ListOfUpgradesForHexagons>()
                .FromInstance(_listOfUpgradesForHexagons)
                .AsSingle();

            Container
                .Bind<FirstActionsChecker>()
                .AsSingle()
                .NonLazy();

            BindMenus();

            Container
                .Bind<RenderCamera>()
                .FromInstance(_renderCamera)
                .AsSingle();
            Container
                .Bind<AppearanceViewContainer[]>()
                .FromInstance(_appearanceContainers)
                .AsSingle();
            Container
                .Bind<AppearanceController>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMenus()
        {
            Container
                .Bind<MenuSwitcher>()
                .FromInstance(_menuSwitcher)
                .AsSingle();
            Container
                .Bind<MenuButtonsHandler>()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<MenuTagsContainer>()
                .FromInstance(_menuTagsContainer)
                .AsSingle();
        }

        private void BindWorkbenchAndInventory()
        {
            Container.Bind<WorkbenchSlotsContainer>().FromInstance(_workbenchSlotsContainer).AsSingle();
            Container.Bind<WorkbenchSlotsUIHandler>().AsSingle().NonLazy();
            Container.Bind<ItemsRecipesDictionary>().AsSingle().NonLazy();
            Container.Bind<RecipesContainer>().FromInstance(_recipesContainer).AsSingle();
            Container.Bind<InventorySlotsDataBinder>().AsSingle();
            Container.Bind<WorkbenchSlotsService>().AsSingle().NonLazy();
            Container.Bind<Workbench>().AsSingle().NonLazy();
            Container.Bind<ItemsInfoContainer>().FromInstance(_itemsInfoContainer).AsSingle();
            Container.Bind<ItemsInfoService>().AsSingle().NonLazy();
            Container.Bind<Inventory.Inventory>().AsSingle().NonLazy();
            Container.Bind<InventorySlotsDragHandler>().AsSingle().NonLazy();
            Container
                .Bind<InventorySlotViewsContainer>()
                .FromInstance(_inventorySlotViewsContainer);
        }

        private void BindPopUps()
        {
            var popUpFactoryContext = new PopUpFactoryContext();
            popUpFactoryContext.SpawnParent = _popUpsService.transform;

            Container
                .Bind<PopUpsService>()
                .FromInstance(_popUpsService)
                .AsSingle();
            Container
                .Bind<PopUpFactoryContext>()
                .FromInstance(popUpFactoryContext)
                .AsSingle();
            Container
                .Bind<MainMenuPopUpsFactory>()
                .AsSingle();
        }
    }
}