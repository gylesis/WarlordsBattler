using System;
using UnityEngine;
using Warlords.Factions;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    [CreateAssetMenu(menuName = "StaticData/PlayerAttributes", fileName = "PlayerAttributesStaticData", order = 0)]
    public class PlayerAttributesStaticData : ScriptableObject
    {
#if UNITY_EDITOR
        
        [SerializeField] private FactionsContainer _factionsContainer;
        [SerializeField] private PlayerAttributeSO[] _playerAttributes;
#endif
        public PlayerAttributesAmountPerLevelContainer Upgrades;
        public AttributesPerFaction[] AttributesPerFactions;
        
#if UNITY_EDITOR
        
        [ContextMenu(nameof(FillFactionStats))]
        private void FillFactionStats()
        {
            var attributesPerFactions = new AttributesPerFaction[_factionsContainer.WarlordFactions.Length];

            for (var index = 0; index < attributesPerFactions.Length; index++)
            {
                WarlordFactionSO faction = _factionsContainer.WarlordFactions[index];

                AttributesPerFaction attributesPerFaction = new AttributesPerFaction();
               // attributesPerFaction.PlayerAttributes = new PlayerAttribute[8];
                
                attributesPerFaction.Faction = faction;

                var newPlayerAttributes = new PlayerAttribute[8];
                
                for (var i = 0; i < newPlayerAttributes.Length; i++)
                {
                    PlayerAttributeSO playerAttributesData = _playerAttributes[i]; 

                    PlayerAttribute playerAttribute = new PlayerAttribute();
                    
                    playerAttribute.Name = playerAttributesData.Value.Name;
                    playerAttribute.Stat = new IntStat();
                    //playerAttribute.Stat.Value = playerAttributesData.Value.Stat.Value; // need to uncomment this string later
                    playerAttribute.Stat.Value = index;

                    newPlayerAttributes[i] = playerAttribute;
                }

                attributesPerFactions[index] = attributesPerFaction;
                attributesPerFaction.PlayerStartAttributes = newPlayerAttributes;
            }

            AttributesPerFactions = attributesPerFactions;
        }

        private void OnValidate()
        {
            foreach (AttributesPerFaction attributesPerFaction in AttributesPerFactions)
            {
                attributesPerFaction.name = attributesPerFaction.Faction.Value.Name;
            }
        }
        
#endif
    }

    [Serializable]
    public class AttributesPerFaction
    {
        [HideInInspector] public string name;
        public WarlordFactionSO Faction;
        public PlayerAttribute[] PlayerStartAttributes;
    }
}