using System;
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
        private BoardGridService _boardGridService;

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
            
            _boardGridService.HighlightNeighbours(battlefield.BattlefieldData.Index);
            
            battlefield.BattlefieldView.ColorMaterial(Color.yellow);

            _chosenBattlefield = battlefield;
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