using UnityEngine;
using Warlords.Factions;
using Warlords.Player.Attributes;

namespace Warlords.Player
{
    [CreateAssetMenu(menuName = "StaticData/PlayerInfoStaticData", fileName = "PlayerInfoStaticData", order = 0)]
    public class PlayerInfoStaticData : ScriptableObject
    {
        public WarlordFactionStaticData WarlordFaction;
        public PlayerAttributesStaticData PlayerAttributes;
    }
}