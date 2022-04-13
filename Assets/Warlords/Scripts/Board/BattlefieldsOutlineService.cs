using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BattlefieldsOutlineService : IDisposable, ITickable, IBoardClickedListener, IBoardHoveredListener
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        
        private BattlefieldView _hoveredBattlefield;
        private Battlefield _chosenBattlefield;
        private readonly BoardDataService _boardDataService;
        
        private List<int> _battlefieldsNeighbour = new List<int>(5);

        public BattlefieldsOutlineService(BoardDataService boardDataService)
        {
            _boardDataService = boardDataService;
        }
        
        public void Tick()
        {
            if(_chosenBattlefield == null) return;
        }
        
        public void BoardClicked(BoardInputContext context)
        {
            if(context.InputButton != InputButton.Left) return;
            
            ColorCell(context.Battlefield);
        }

        public void BoardHovered(BoardInputContext context)
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
            
            var battlefieldsNeighbour = _boardDataService.BattlefieldsNeighbours[battlefieldIndex];
            
            ColorNeighbours(battlefieldsNeighbour, Color.green);
            _battlefieldsNeighbour = battlefieldsNeighbour;
        }

        private void ColorNeighbours(List<int> neighboursIndexes, Color color)  
        {
            if (color == Color.black)
            {
                foreach (var index in neighboursIndexes)
                {
                    Battlefield battlefield = _boardDataService.Battlefields.First(battle => battle.BattlefieldData.Index == index);
                
                    battlefield.BattlefieldView.ColorDefault();
                } 
                
                return;
            }
            
            foreach (var index in neighboursIndexes)
            {
                Battlefield battlefield = _boardDataService.Battlefields.First(battle => battle.BattlefieldData.Index == index);
                
                battlefield.BattlefieldView.ColorMaterial(color);
            } 
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
 
    
    
    
}