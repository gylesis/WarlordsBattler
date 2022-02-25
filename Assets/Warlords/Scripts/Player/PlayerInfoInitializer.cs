using System.Collections.Generic;
using Warlords.Player.Spells;
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

            var staticPlayerAttributes = _staticData.PlayerAttributes.PlayerAttributes;
            playerInfo.CopyAndSetAttributes(staticPlayerAttributes);

            playerInfo.Faction = _staticData.WarlordFaction.WarlordFaction;
            playerInfo.PlayerAttributes.LeftUpgrades = _staticData.PlayerAttributes.Upgrades.GetUpgradesAmount(1);

            return playerInfo;
        }
    }
}