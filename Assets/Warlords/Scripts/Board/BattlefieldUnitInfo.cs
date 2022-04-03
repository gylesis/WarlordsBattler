using UnityEngine;

namespace Warlords.Board
{
    public class BattlefieldUnitInfo : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;
        public Transform Pivot => _pivot;

        public Unit Unit { get; set; }
    }
    
}