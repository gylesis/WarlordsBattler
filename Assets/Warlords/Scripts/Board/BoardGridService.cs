using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BoardGridService : ITickable
    {
        private int _battlefieldIndex = 0;

        private float _timer;
        private float _transitionCooldown = 0.1f;

        private readonly List<Battlefield> _battlefields;

        private Battlefield _currentBattlefield;

        public BoardGridService(BattlefieldsContainer battlefieldsContainer)
        {
            _battlefields = new List<Battlefield>(36);

            _battlefields.AddRange(battlefieldsContainer.MyBattlefields);
            _battlefields.AddRange(battlefieldsContainer.EnemyBattlefields);

            /*int temp = 0;

            foreach (Battlefield battlefield in battlefields)
            {
                temp++;
                battlefield.BattlefieldView.SetId(temp);
            }*/
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