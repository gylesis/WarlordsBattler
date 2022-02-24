using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    public class AttributesUpgradeButtonsHandler
    {
        private readonly LeftAttributesUpgradesAmountView _leftAttributesUpgradesAmountView;
        private readonly PlayerInfoPreSaver _preSaver;

        private readonly List<PlayerAttribute> _attributes = new List<PlayerAttribute>();

        public AttributesUpgradeButtonsHandler(ISaveLoadDataService saveLoadDataService,
            LeftAttributesUpgradesAmountView leftAttributesUpgradesAmountView, PlayerInfoPreSaver preSaver)
        {
            _preSaver = preSaver;
            _leftAttributesUpgradesAmountView = leftAttributesUpgradesAmountView;

            _preSaver.PlayerInfoDiscarded
                .TakeUntilDestroy(_leftAttributesUpgradesAmountView)
                .Subscribe(PlayerInfoDiscarded);

            _leftAttributesUpgradesAmountView.UpdateView(saveLoadDataService.Data.PlayerInfo.PlayerAttributes
                .LeftUpgrades);
        }

        private void PlayerInfoDiscarded(PlayerInfo playerInfo)
        {
            var playerAttributes = playerInfo.PlayerAttributes.Attributes;

            foreach (PlayerAttribute playerAttribute in _attributes)
            {
                PlayerAttribute attribute = playerAttributes.Find(x => x.Name == playerAttribute.Name);

                playerAttribute.Stat.Set(attribute.Stat.Value);
            }

            _leftAttributesUpgradesAmountView.UpdateView(playerInfo.PlayerAttributes.LeftUpgrades);
        }

        public void Register(UpgradeAttributeButton attributeButton)
        {
            attributeButton.Clicked
                .TakeUntilDestroy(attributeButton)
                .Subscribe(HandleClick);
            
            PlayerAttribute attribute = attributeButton.Attribute;

            if (_attributes.Contains(attribute)) return;

            _attributes.Add(attribute);
        }

        private void HandleClick(ButtonContext<PlayerAttribute, bool> buttonContext)
        {
            int leftUpgrades = _preSaver.PlayerInfo.PlayerAttributes.LeftUpgrades;
            PlayerAttribute playerAttribute = buttonContext.Sender;
            bool buttonValue = buttonContext.Value;

            int addValue = buttonValue ? 1 : -1;


            if (leftUpgrades == 0)
            {
                Debug.Log("Left 0");
                if (Math.Sign(addValue) == 1)
                {
                    _leftAttributesUpgradesAmountView.NotEnoughColor();
                    return;
                }
            }


            if (Math.Sign(addValue) == -1)
            {
                if (playerAttribute.Stat.Value == 0)
                {
                    return;
                }
            }

            leftUpgrades += -addValue;
            
            _leftAttributesUpgradesAmountView.UpdateView(leftUpgrades);
            
            playerAttribute.Stat.Add(addValue);

            _preSaver.Overwrite(playerInfo =>
            {
                playerInfo.PlayerAttributes.LeftUpgrades =
                    leftUpgrades;

                var playerAttributes = playerInfo.PlayerAttributes.Attributes;

                PlayerAttribute attribute = playerAttributes.Find(x => x.Name == playerAttribute.Name);
                
                attribute.Stat.Set(playerAttribute.Stat.Value);

            });
        }
    }
}