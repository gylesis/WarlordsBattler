using System.Collections.Generic;
using UnityEngine;

namespace Warlords
{
    [CreateAssetMenu(menuName = "ListOfUpgradesForHexagons", fileName = "ListOfUpgradesForHexagons", order = 0)]
    public class ListOfUpgradesForHexagons : ScriptableObject
    {
        public List<int> Upgrades = new List<int>();
    }
}