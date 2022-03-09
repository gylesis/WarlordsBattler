using System.Linq;
using UnityEngine;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.Player
{
    public class PlayerInfoInitializer : IPlayerInfoInitializer
    {
        private readonly PlayerInfoStaticData _staticData;

        public PlayerInfoInitializer(PlayerInfoStaticData staticData)
        {
            _staticData = staticData;
        }
        
        public PlayerInfo Initialize()
        {
            var playerInfo = new PlayerInfo();

            PlayerAttribute[] staticPlayerAttributes =
                _staticData.PlayerAttributes.AttributesPerFactions[0].PlayerStartAttributes;

            playerInfo.CopyAndSetAttributes(staticPlayerAttributes);

            playerInfo.Faction = _staticData.WarlordFaction._faction;
            playerInfo.AttributesData.LeftUpgrades = _staticData.PlayerAttributes.Upgrades.GetUpgradesAmount(1);

            return playerInfo;
        }
    }
}