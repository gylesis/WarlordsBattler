using Cysharp.Threading.Tasks;
using Warlords.Infrastructure;
using Warlords.Infrastructure.Factory;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    public class PlayerAttributesViewSpawner : IAsyncLoad
    {
        private readonly PlayerAttributeViewFactory _factory;
        private readonly AttributesUpgradeButtonsHandler _upgradeButtonsHandler;
        private readonly ISaveLoadDataService _saveLoadDataService;
        private readonly PlayerAttributesViewService _viewService;

        public PlayerAttributesViewSpawner(AsyncLoadingsRegister asyncLoadingsRegister,
            PlayerAttributeViewFactory factory,
            ISaveLoadDataService saveLoadDataService,
            AttributesUpgradeButtonsHandler upgradeButtonsHandler,
            PlayerAttributesViewService viewService)
        {
            asyncLoadingsRegister.Register(this);
            
            _viewService = viewService;
            _saveLoadDataService = saveLoadDataService;
            _upgradeButtonsHandler = upgradeButtonsHandler;
            _factory = factory;
        }

        public async UniTask AsyncLoad()
        {
            var attributes = _saveLoadDataService.Data.PlayerInfo.AttributesData.Attributes;

            var playerAttributeViews = new PlayerAttributeView[8];

            for (var i = 0; i < attributes.Length; i++)
            {
                PlayerAttribute attribute = attributes[i];
                
                PlayerAttributeView attributeView =
                    await _factory.CreatePlayerAttributeView();       
    
                var playerAttribute = new PlayerAttribute();

                playerAttribute.Stat = new IntStat();

                playerAttribute.Name = attribute.Name;
                playerAttribute.Stat.Value.Value = attribute.Stat.Value.Value;

                attributeView.Init(playerAttribute);

                _upgradeButtonsHandler.RegisterButton(attributeView.MinusButton);
                _upgradeButtonsHandler.RegisterButton(attributeView.PlusButton);

                playerAttributeViews[i] = attributeView;
            }

            _viewService.RegisterViews(playerAttributeViews);
        }
    }
}