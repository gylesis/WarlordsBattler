using UnityEngine;

namespace Warlords.Factions
{
    [CreateAssetMenu(fileName = "FactionsContainer", menuName = "FactionsContainer", order = 0)]
    public class FactionsContainer : ScriptableObject
    {
        public WarlordFactionSO[] WarlordFactions;
    }
}