using UnityEngine;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    [CreateAssetMenu(menuName = "StaticData/PlayerAttributes", fileName = "PlayerAttributesStaticData", order = 0)]
    public class PlayerAttributesStaticData : ScriptableObject
    {
        public PlayerAttributesAmountPerLevelContainer Upgrades;
        public PlayerAttribute[] PlayerAttributes;
    }
}