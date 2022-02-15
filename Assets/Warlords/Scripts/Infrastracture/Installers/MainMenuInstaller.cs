using UnityEngine;
using Warlords.Faction;
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
        [SerializeField] private FactionsContainer _factionsContainer;
        [SerializeField] private FactionView _factionViewPrefab;
        [SerializeField] private ListOfUpgradesForHexagons _listOfUpgradesForHexagons;
        [SerializeField] private MenuTagsContainer _menuTagsContainer;
        [SerializeField] private PopUpsService _popUpsService;
        [SerializeField] private LeftAttributesUpgradesAmountView _leftAttributesUpgradesAmountView;
        [SerializeField] private SaveCancelPlayerInfoService _saveCancelPlayerInfoService;
        
        public override void InstallBindings()
        {
            Container.Bind<LeftAttributesUpgradesAmountView>().FromInstance(_leftAttributesUpgradesAmountView).AsSingle();

            Container.Bind<FactionsContainer>().FromInstance(_factionsContainer).AsSingle();

            Container.Bind<FactionsViewFactory>().AsSingle();

            Container.Bind<FactionView>().FromInstance(_factionViewPrefab).AsSingle();

            Container.Bind<AvailableFactions>().AsSingle();

            Container.Bind<ListOfUpgradesForHexagons>().FromInstance(_listOfUpgradesForHexagons).AsSingle();

            Container.Bind<PlayerInfoChangedDispatcher>().AsSingle().NonLazy();
            Container.Bind<PlayerInfoChangeRegister>().AsSingle().NonLazy();
            Container.Bind<PlayerNameSetter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerNameFilter>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerInfoSetter>().AsSingle().NonLazy();
            Container.Bind<UIFactory>().AsSingle();

            Container.Bind<PlayerAttributesProvider>().AsSingle().NonLazy();

            Container.Bind<FirstActionsChecker>().AsSingle().NonLazy();

            Container.Bind<MenuTagsContainer>().FromInstance(_menuTagsContainer).AsSingle();

            Container.Bind<AttributesUpgradeButtonsHandler>().AsSingle().NonLazy();

            Container.Bind<PopUpsService>().FromInstance(_popUpsService).AsSingle();

            Container.Bind<PlayerInfoPreSaver>().AsSingle().NonLazy();

            Container.Bind<SaveCancelPlayerInfoService>().FromInstance(_saveCancelPlayerInfoService).AsSingle();

        }

    }
    
}