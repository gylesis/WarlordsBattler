using System;
using UnityEngine;

namespace Warlords.Board
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private UnitView _unitView;
        
        private UnitData _data;

        public UnitView UnitView => _unitView;
        public IMovingCommand MovingCommand { get; set; }
        public UnitData Data => _data;

        public void Init(UnitData data)
        {
            _data = data;
            MovingCommand = data.MovingCommand;
        }
        
    }

    [Serializable]
    public class UnitData
    {
        public UnitStats Stats;
        public IMovingCommand MovingCommand;
    }

    public class UnitSkills
    {
        
    }
}