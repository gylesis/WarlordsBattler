using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BattlefieldsOutlineService : IDisposable, ITickable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        
        private BattlefieldView _hoveredBattlefield;
        private Battlefield _chosenBattlefield;
        private readonly BoardGridService _boardGridService;
        
        private List<int> _battlefieldsNeighbour = new List<int>(5);

        public BattlefieldsOutlineService(IBoardInputService boardInputService, BoardGridService boardGridService)
        {
            _boardGridService = boardGridService;
            // boardInputService.BoardHover.Subscribe(OnBoardHover).AddTo(_compositeDisposable);
            boardInputService.BoardClicked.Subscribe((OnBoardClicked)).AddTo(_compositeDisposable);
        }

        public void Tick()
        {
            if(_chosenBattlefield == null) return;
        }

        private void OnBoardClicked(BoardInputContext context)
        {
            if(context.InputButton != InputButton.Left) return;
            
            ColorCell(context.Battlefield);
        }

        private void ColorCell(Battlefield battlefield)
        {
            if(battlefield == null)
            {
                _chosenBattlefield?.BattlefieldView.ColorDefault();
                _chosenBattlefield = null;
                return;
            }

            if (battlefield == _chosenBattlefield)
            {
                battlefield.BattlefieldView.ColorDefault();
                _chosenBattlefield = null;
                return;
            }
            
            _chosenBattlefield?.BattlefieldView.ColorDefault();
            
            HighlightNeighbours(battlefield.BattlefieldData.Index);
            
            battlefield.BattlefieldView.ColorMaterial(Color.yellow);

            _chosenBattlefield = battlefield;
        }

        private void HighlightNeighbours(int battlefieldIndex)
        {
            ColorNeighbours(_battlefieldsNeighbour, Color.black);
            
            var battlefieldsNeighbour = _boardGridService.BattlefieldsNeighbours[battlefieldIndex];
            
            ColorNeighbours(battlefieldsNeighbour, Color.green);
            _battlefieldsNeighbour = battlefieldsNeighbour;
        }

        private void ColorNeighbours(List<int> neighboursIndexes, Color color)  
        {
            if (color == Color.black)
            {
                foreach (var index in neighboursIndexes)
                {
                    Battlefield battlefield = _boardGridService.Battlefields.First(battle => battle.BattlefieldData.Index == index);
                
                    battlefield.BattlefieldView.ColorDefault();
                } 
                
                return;
            }
            
            foreach (var index in neighboursIndexes)
            {
                Battlefield battlefield = _boardGridService.Battlefields.First(battle => battle.BattlefieldData.Index == index);
                
                battlefield.BattlefieldView.ColorMaterial(color);
            } 
        }
        

        private void OnBoardHover(BoardInputContext context)
        {
            Battlefield battlefield = context.Battlefield;

            if(battlefield == null)
            {
                _hoveredBattlefield?.ColorDefault();
                _hoveredBattlefield = null;
                return;
            }

            _hoveredBattlefield?.ColorDefault();
            
            _hoveredBattlefield = battlefield.BattlefieldView;
            
            _hoveredBattlefield.ColorMaterial(Color.red);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}