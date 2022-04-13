using Cysharp.Threading.Tasks;

namespace Warlords.Board
{
    public class MoveByCellsCommand : IMovingCommand
    {
        private BoardDataService _boardGridService;

        public MoveByCellsCommand(BoardDataService boardGridService)
        {
            _boardGridService = boardGridService;
        }
        
        public async UniTask Move(MoveCommandContext context)
        {
            
        }
    }
}