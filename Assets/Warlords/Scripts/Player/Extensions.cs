using UnityEngine;
using Warlords.Utils;

namespace Warlords.Player
{
    public static class Extensions
    {
        public static PlayerInfo Copy(this PlayerInfo playerInfo)
        {
            var newPlayerInfo = new PlayerInfo();

            Color factionColor = playerInfo.Faction.Color;
            string factionName = playerInfo.Faction.Name;

            int levelValue = playerInfo.Level.Value;

            newPlayerInfo.Faction.Color = factionColor;
            newPlayerInfo.Faction.Name = factionName;
            newPlayerInfo.Level.Value = levelValue;
            
            for (var i = 0; i < playerInfo.PlayerAttributes.Attributes.Count; i++)
            {
                PlayerAttribute playerAttribute = playerInfo.PlayerAttributes.Attributes[i];
                
                PlayerAttribute newPlayerAttribute = new PlayerAttribute();

                int statValue = playerAttribute.Stat.Value;
                string playerAttributeName = playerAttribute.Name;

                newPlayerAttribute.Stat.Value = statValue;
                newPlayerAttribute.Name = playerAttributeName;
                
                newPlayerInfo.PlayerAttributes.Attributes.Add(newPlayerAttribute);
            }

            int leftUpgrades = playerInfo.PlayerAttributes.LeftUpgrades;

            newPlayerInfo.PlayerAttributes.LeftUpgrades = leftUpgrades;


            return newPlayerInfo;
        }
        
        
    }
}