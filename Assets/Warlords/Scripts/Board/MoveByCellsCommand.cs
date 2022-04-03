using Cysharp.Threading.Tasks;

namespace Warlords.Board
{
    public class MoveByCellsCommand : IMovingCommand
    {
        private BoardGridService _boardGridService;

        public MoveByCellsCommand(BoardGridService boardGridService)
        {
            _boardGridService = boardGridService;
        }
        
        public async UniTask Move(MoveCommandContext context)
        {
            
        }
    }
}