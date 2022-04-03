
using Cysharp.Threading.Tasks;

namespace Warlords.Board
{
    public interface IMovingCommand
    {
        UniTask Move(MoveCommandContext context);
    }
}