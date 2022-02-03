using UnityEngine;

namespace Warlords
{
    [CreateAssetMenu(fileName = "FractionsContainer", menuName = "FractionsContainer", order = 0)]
    public class FractionsContainer : ScriptableObject
    {
        public WarlordFraction[] WarlordFractions;
    }
}