using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastructure;
using Zenject;

namespace Warlords.Board
{
    public class BoardGridService : ITickable, IAsyncLoad
    {
        private int _battlefieldIndex = 0;

        private float _timer;
        private float _transitionCooldown = 0.1f;

        private readonly List<Battlefield> _battlefields;

        private Battlefield _currentBattlefield;

        private readonly Dictionary<int, List<int>> _battlefieldsNeighbours = new Dictionary<int, List<int>>();
        private List<int> _battlefieldsNeighbour = new List<int>(5);
        private BoardGridData _boardGridData;

        public BoardGridService(BattlefieldsContainer battlefieldsContainer, BoardGridData boardGridData)   
        {
            _boardGridData = boardGridData;
            _battlefields = new List<Battlefield>(36);

            _battlefields.AddRange(battlefieldsContainer.MyBattlefields);
            _battlefields.AddRange(battlefieldsContainer.EnemyBattlefields);
        }

        public async UniTask AsyncLoad()
        {
            foreach (BoardGridData.BattlefieldEditorData battlefieldData in _boardGridData.Datas)
            {
                _battlefieldsNeighbours.Add(battlefieldData.Index, battlefieldData.Neighbours.Select(x => x.Index).ToList());
            }


            /*foreach (Battlefield battlefield in _battlefields)
            {
                var dataIndex = battlefield.BattlefieldData.Index;

                int rowModifier = dataIndex;
                /*
                if (dataIndex > 0 && dataIndex < 5 || dataIndex > 8 && dataIndex < 15)
                {
                    rowModifier = 5;
                }
                else if (dataIndex > 4 && dataIndex < 10 || dataIndex > 12 && dataIndex < 20)
                {
                    rowModifier = 4;
                }#1#

                List<int> neighbours = new List<int>();

                Add(dataIndex - 1);
                Add(dataIndex + 1);
                Add(dataIndex + 3);
                Add(dataIndex - 3);
                Add(dataIndex + 4);
                Add(dataIndex - 4);
                
                void Add(int index)
                {
                    if(index < 1 || index > 36)
                        return;
                    
                    if(neighbours.Contains(index)) return;
                    
                    neighbours.Add(index);
                }

                _battlefieldsNeighbours.Add(dataIndex, neighbours);
            }*/
        }

        public void HighlightNeighbours(int battlefieldIndex)
        {
            ColorNeighbours(_battlefieldsNeighbour, Color.black);
            
            var battlefieldsNeighbour = _battlefieldsNeighbours[battlefieldIndex];
            
            ColorNeighbours(battlefieldsNeighbour, Color.green);
            _battlefieldsNeighbour = battlefieldsNeighbour;
        }

        private void ColorNeighbours(List<int> neighboursIndexes, Color color)  
        {
            if (color == Color.black)
            {
                foreach (var index in neighboursIndexes)
                {
                    Battlefield battlefield = _battlefields.First(battle => battle.BattlefieldData.Index == index);
                
                    battlefield.BattlefieldView.ColorDefault();
                } 
                
                return;
            }
            
            foreach (var index in neighboursIndexes)
            {
                Battlefield battlefield = _battlefields.First(battle => battle.BattlefieldData.Index == index);
                
                battlefield.BattlefieldView.ColorMaterial(color);
            } 
        }
        
        
        public bool TryGetUnitBattlefield(Unit unit, out Battlefield battlefield)
        {
            battlefield = null;

            foreach (Battlefield batlefield in _battlefields)
            {
                var b = batlefield.BattlefieldUnitInfo.Unit == unit;

                if (b)
                {
                    battlefield = batlefield;
                    return true;
                }
            }
            return false;
        }

        public void Tick()
        {
            NewMethod();
        }

        private void NewMethod()
        {
            _timer += Time.deltaTime;

            Vector2Int move = Vector2Int.zero;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                move.y = 1;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                move.y = -1;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move.x = -1;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                move.x = 1;
            }

            if (_timer > _transitionCooldown)
            {
                _timer = 0;

                _battlefieldIndex +=  move.x;
                _battlefieldIndex +=  move.y * 4; // sin

                if (_battlefieldIndex < 1 || _battlefieldIndex > 36)
                {
                    _currentBattlefield?.BattlefieldView.ColorDefault();
                    _currentBattlefield = null;
                    
                    _battlefieldIndex = Mathf.Clamp(_battlefieldIndex, 0, 37);
                    return;
                }
                
                _battlefieldIndex = Mathf.Clamp(_battlefieldIndex, 1, 36);

                _currentBattlefield?.BattlefieldView?.ColorDefault();

                _currentBattlefield = _battlefields[_battlefieldIndex - 1];

                _currentBattlefield.BattlefieldView.ColorMaterial(Color.yellow);
            }
        }
    }
}