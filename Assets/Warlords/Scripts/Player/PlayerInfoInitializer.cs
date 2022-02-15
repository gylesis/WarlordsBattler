using System.Collections.Generic;
using System.Linq;
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

            var playerAttributes = new List<PlayerAttribute>(_staticData.PlayerAttributes.PlayerAttributes);

            playerInfo.PlayerAttributes.Attributes = playerAttributes;
            playerInfo.Faction = _staticData.WarlordFaction.WarlordFaction;
            playerInfo.PlayerAttributes.LeftUpgrades = _staticData.PlayerAttributes.Upgrades.GetUpgradesAmount(1);
            
            return playerInfo;
        }
    }
}