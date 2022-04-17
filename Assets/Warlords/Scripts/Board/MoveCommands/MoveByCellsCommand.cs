using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Warlords.Board
{
    public class MoveByCellsCommand : IMovingCommand
    {
        private BoardDataService _boardGridService;
        private readonly BoardCellsTree _boardCellsTree;

        public MoveByCellsCommand(BoardCellsTree boardCellsTree)
        {
            _boardCellsTree = boardCellsTree;
        }   

        public async UniTask Move(MoveCommandContext context)
        {
            var startIndex = context.StartBattlefield.BattlefieldData.Index;
            var targetIndex = context.TargetBattlefield.BattlefieldData.Index;

            var path = _boardCellsTree.FindPath(startIndex,targetIndex);

            var battlefields = await path;

            foreach (Battlefield battlefield in battlefields)
            {
                await context.UnitTransform.DOLocalMove(battlefield.BattlefieldUnitInfo.Pivot.position,0.5f).AsyncWaitForCompletion();
            }
        }
    }

    
}