using System;
using UniRx;
using UnityEngine;

namespace Warlords.Board
{
    public class BoardUpdateService : IDisposable
    {
        private readonly IBoardUpdateListener[] _boardUpdateListeners;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public BoardUpdateService(IBoardUpdateListener[] boardUpdateListeners,
            IBoardUpdateNotifier[] boardUpdateNotifiers)
        {
            _boardUpdateListeners = boardUpdateListeners;

            foreach (IBoardUpdateNotifier updateNotifier in boardUpdateNotifiers)
                updateNotifier.BoardUpdate.Subscribe((OnBoardUpdate)).AddTo(_disposable);
        }

        private void OnBoardUpdate(BoardUpdateContext context)
        {
            foreach (IBoardUpdateListener listener in _boardUpdateListeners)
                listener.OnBoardUpdate(context);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }

    public interface IBoardUpdateListener
    {
        void OnBoardUpdate(BoardUpdateContext context);
    }
}