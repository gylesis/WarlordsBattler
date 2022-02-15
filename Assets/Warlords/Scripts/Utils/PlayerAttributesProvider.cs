using System.Collections.Generic;
using Warlords.Player;
using Warlords.Player.Attributes;

namespace Warlords.Utils
{
    public class PlayerAttributesProvider
    {
        public List<PlayerAttribute> PlayerInfoAttributes { get; }

        public PlayerAttributesProvider(ISaveLoadDataService saveLoadDataService, PlayerInfoStaticData staticData)
        {
            /*PlayerInfo playerInfo = saveLoadDataService.Data.PlayerInfo;
            PlayerAttributes playerInfoPlayerAttributes = playerInfo.PlayerAttributes;*/

            PlayerInfoAttributes = new List<PlayerAttribute>();
         
        }
    }
}