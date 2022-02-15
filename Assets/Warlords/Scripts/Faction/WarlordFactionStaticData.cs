using UnityEngine;

namespace Warlords.Faction
{
    [CreateAssetMenu(menuName = "StaticData/Faction", fileName = "WarlordFactionStaticData", order = 0)]
    public class WarlordFactionStaticData : ScriptableObject
    {
        public WarlordFaction WarlordFaction;
    }
}