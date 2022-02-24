using UnityEngine;
using Warlords.Player;

namespace Warlords.Faction
{
    [CreateAssetMenu(fileName = "FactionsContainer", menuName = "FactionsContainer", order = 0)]
    public class FactionsContainer : ScriptableObject
    {
        public WarlordFaction[] WarlordFactions;
    }
}