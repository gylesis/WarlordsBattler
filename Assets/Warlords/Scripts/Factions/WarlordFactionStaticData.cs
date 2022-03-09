using UnityEngine;

namespace Warlords.Factions
{
    [CreateAssetMenu(menuName = "StaticData/Faction", fileName = "WarlordFactionStaticData", order = 0)]
    public class WarlordFactionStaticData : ScriptableObject
    {
        public Faction _faction;
    }
}