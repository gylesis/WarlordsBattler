
namespace Warlords.Board
{
    public class BattlefieldUnitMover : IBoardControlledClickedListener, IBoardUpdateListener
    {
        private readonly UnitsMoverService _unitsMoverService;

        private Battlefield _chosenBattlefield;

        private bool _allowToMove = true;
        
        public BattlefieldUnitMover(UnitsMoverService unitsMoverService)
        {
            _unitsMoverService = unitsMoverService;
        }

        public void BoardClicked(BoardInputContext context)
        {
            if (context.InputButton != InputButton.Left) return;

            if (context.Battlefield == null) return;

            if(_allowToMove == false) return;
            
            if (_chosenBattlefield == null)
            {
                if (context.Battlefield.BattlefieldUnitInfo.Unit != null)
                    _chosenBattlefield = context.Battlefield;
            }
            else
            {
                if (context.Battlefield.BattlefieldUnitInfo.Unit == null)
                {
                    _allowToMove = false;
                    _unitsMoverService.Move(_chosenBattlefield.BattlefieldUnitInfo.Unit, context.Battlefield);
                    _chosenBattlefield = null;
                }
            }
        }

        public void OnBoardUpdate(BoardUpdateContext context)
        {
            _allowToMove = true;
        }
    }
    
}