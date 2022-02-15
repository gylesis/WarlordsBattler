using System;
using System.Collections.Generic;
using UnityEngine;

namespace Warlords.Player.Attributes
{
    [CreateAssetMenu(menuName = "StaticData/PlayerAttributesAmountPerLevelContainer", fileName = "PlayerAttributesAmountPerLevelContainer", order = 0)]
    public class PlayerAttributesAmountPerLevelContainer : ScriptableObject
    {
        [SerializeField] private List<AttributeLevel> _attributesAmountPerLevel;

        private void OnValidate()
        {
            for (var i = 0; i < _attributesAmountPerLevel.Count; i++)
            {
                var counter = i;
                _attributesAmountPerLevel[i].Name = $"Level {++counter}";
            }
        }

        public int GetUpgradesAmount(int level)
        {
            return _attributesAmountPerLevel[level - 1];
        }
        
    }

    [Serializable]
    public class AttributeLevel
    {
        [HideInInspector] public string Name;
        public int Amount;

        public static implicit operator int(AttributeLevel attributeLevel)
        {
            return attributeLevel.Amount;
        }
        
    }
    
}