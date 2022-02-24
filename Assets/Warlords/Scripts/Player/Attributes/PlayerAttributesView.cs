using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastracture;
using Warlords.Infrastracture.Factory;
using Warlords.Utils;
using Zenject;

namespace Warlords.Player.Attributes
{
    public class PlayerAttributesView : MonoBehaviour, IAsyncLoad
    {
        [SerializeField] private Transform _parent;

        private UIFactory _factory;
        private PlayerAttributesProvider _attributesProvider;
        private AttributesUpgradeButtonsHandler _upgradeButtonsHandler;
        private ISaveLoadDataService _saveLoadDataService;

        [Inject]
        private void Init(AsyncLoadingsRegister asyncLoadingsRegister, UIFactory factory,
            PlayerAttributesProvider attributesProvider,ISaveLoadDataService saveLoadDataService, AttributesUpgradeButtonsHandler upgradeButtonsHandler)
        {
            asyncLoadingsRegister.Register(this);
            
            _saveLoadDataService = saveLoadDataService;
            _upgradeButtonsHandler = upgradeButtonsHandler;
            _attributesProvider = attributesProvider;
            _factory = factory;
        }

        public async UniTask AsyncLoad()
        {
            var attributes = _saveLoadDataService.Data.PlayerInfo.PlayerAttributes.Attributes;

            foreach (PlayerAttribute attribute in attributes)
            {
                PlayerAttributeView attributeView = await _factory.CreatePlayerAttributeView(AssetsPath.PlayerAttributesPrefab, _parent);

                var playerAttribute = new PlayerAttribute();

                playerAttribute.Stat = new IntStat();
                
                playerAttribute.Name = attribute.Name;
                playerAttribute.Stat.Value = attribute.Stat.Value;
                
                attributeView.Init(playerAttribute);

                _upgradeButtonsHandler.Register(attributeView.MinusButton);
                _upgradeButtonsHandler.Register(attributeView.PlusButton);
            }
        }
    }
}