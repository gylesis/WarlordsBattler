using UniRx;

namespace Warlords.Board
{
    public interface IBoardUpdateNotifier
    {
        public Subject<BoardUpdateContext> BoardUpdate { get; }
    }
    public struct BoardUpdateContext { }
}