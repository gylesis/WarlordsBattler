using UniRx;

namespace Warlords.Board
{
    public interface IBoardInputService
    {
        public Subject<BoardInputContext> BoardClicked { get; }
        public Subject<BoardInputContext> BoardHover { get; }
    }
}