using System;
using System.Collections.Generic;
using UniRx;

namespace Warlords.Board
{
    public class BoardInputDispatcher : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        private readonly List<IBoardHoveredListener> _hoveredListeners = new List<IBoardHoveredListener>();
        private readonly List<IBoardClickedListener> _clickedListeners = new List<IBoardClickedListener>();

        private readonly List<IBoardHoveredListener> _controlledHoveredListeners = new List<IBoardHoveredListener>();
        private readonly List<IBoardClickedListener> _controlledClickedListeners = new List<IBoardClickedListener>();

        private readonly BattlefieldInputAllowService _inputAllowService;

        public BoardInputDispatcher(IBoardInputService inputService, IBoardHoveredListener[] hoveredListeners,
            IBoardClickedListener[] clickedListeners, BattlefieldInputAllowService inputAllowService)
        {
            _inputAllowService = inputAllowService;
            
            foreach (IBoardHoveredListener listener in hoveredListeners)
            {
                if (listener is IBoardControlledHoveredListener)
                    _controlledHoveredListeners.Add(listener);
                else
                    _hoveredListeners.Add(listener);
            }

            foreach (IBoardClickedListener listener in clickedListeners)
            {
                if (listener is IBoardControlledClickedListener)
                    _controlledClickedListeners.Add(listener);
                else
                    _clickedListeners.Add(listener);
            }

            inputService.BoardClicked.Subscribe((OnBoardClicked)).AddTo(_compositeDisposable);
            inputService.BoardHover.Subscribe((OnBoardHovered)).AddTo(_compositeDisposable);
        }

        private void OnBoardHovered(BoardInputContext context)
        {
            foreach (IBoardHoveredListener listener in _hoveredListeners)
                listener.BoardHovered(context);

            if (_inputAllowService.Value == false) return;

            foreach (IBoardHoveredListener listener in _controlledHoveredListeners)
                listener.BoardHovered(context);
        }

        private void OnBoardClicked(BoardInputContext context)
        {
            foreach (IBoardClickedListener listener in _clickedListeners)
                listener.BoardClicked(context);

            if (_inputAllowService.Value == false) return;

            foreach (IBoardClickedListener listener in _controlledClickedListeners)
                listener.BoardClicked(context);
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }

    public interface IBoardClickedListener
    {
        void BoardClicked(BoardInputContext context);
    }

    public interface IBoardHoveredListener
    {
        void BoardHovered(BoardInputContext context);
    }

    public interface IBoardControlledClickedListener : IBoardClickedListener { }

    public interface IBoardControlledHoveredListener : IBoardHoveredListener { }
}