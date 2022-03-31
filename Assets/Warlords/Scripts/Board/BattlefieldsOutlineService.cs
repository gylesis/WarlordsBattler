using System;
using UniRx;
using UnityEngine;

namespace Warlords.Board
{
    public class BattlefieldsOutlineService : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private BattlefieldView _hoveredBattlefield;

        public BattlefieldsOutlineService(IBoardInputService boardInputService)
        {
           // boardInputService.BoardClicked.Subscribe(OnBoardClicked).AddTo(_compositeDisposable);
            boardInputService.BoardHover.Subscribe(OnBoardHover).AddTo(_compositeDisposable);
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