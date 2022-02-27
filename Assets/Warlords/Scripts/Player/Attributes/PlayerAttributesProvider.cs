using System.Collections.Generic;
using Warlords.Infrastracture;

namespace Warlords.Player.Attributes
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