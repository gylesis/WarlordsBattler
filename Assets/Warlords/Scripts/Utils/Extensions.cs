using System.Collections.Generic;
using UnityEngine;
using Warlords.Player;
using Warlords.Player.Attributes;
using Warlords.Player.Spells;

namespace Warlords.Utils
{
    public static class Extensions
    {
        public static PlayerInfo Copy(this PlayerInfo playerInfo)
        {
            var newPlayerInfo = new PlayerInfo();

            newPlayerInfo.Name = playerInfo.Name;
            
            Color factionColor = playerInfo.Faction.Color;
            string factionName = playerInfo.Faction.Name;

            int levelValue = playerInfo.Level.Value;

            newPlayerInfo.Faction.Color = factionColor;
            newPlayerInfo.Faction.Name = factionName;
            newPlayerInfo.Level.Value = levelValue;

            newPlayerInfo.SpellInfo = new PlayerSpellInfo();
            
            for (var i = 0; i < newPlayerInfo.SpellInfo.SpellDatas.Length; i++)
            {
                SpellData newSpellData = newPlayerInfo.SpellInfo.SpellDatas[i];
                SpellData oldSpellData = playerInfo.SpellInfo.SpellDatas[i];

                newSpellData.Index = oldSpellData.Index;
                newSpellData.Type = oldSpellData.Type;
            }
            
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
        public static void CopyAndSetAttributes(this PlayerInfo playerInfo, PlayerAttribute[] playerAttributes)
        {
            var newPlayerAttributes = new List<PlayerAttribute>(playerAttributes.Length);
            
            for (var i = 0; i < playerAttributes.Length; i++)
            {
                PlayerAttribute inputAttribute = playerAttributes[i];
                
                PlayerAttribute newPlayerAttribute = new PlayerAttribute();

                int statValue = inputAttribute.Stat.Value;
                string playerAttributeName = inputAttribute.Name;

                newPlayerAttribute.Stat.Value = statValue;
                newPlayerAttribute.Name = playerAttributeName;
                
                newPlayerAttributes.Add(newPlayerAttribute);
            }

            playerInfo.PlayerAttributes.Attributes = newPlayerAttributes;
        }

    }
}