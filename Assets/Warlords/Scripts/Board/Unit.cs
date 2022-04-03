using UnityEngine;

namespace Warlords.Board
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private UnitView _unitView;
        
        public UnitView UnitView => _unitView;
        public IMovingCommand MovingCommand { get; set; }
    }
}