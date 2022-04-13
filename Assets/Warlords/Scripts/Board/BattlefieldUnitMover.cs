
namespace Warlords.Board
{
    public class BattlefieldUnitMover : IBoardControlledClickedListener
    {
        private readonly UnitsMoverService _unitsMoverService;

        private Battlefield _chosenBattlefield;

        public BattlefieldUnitMover(UnitsMoverService unitsMoverService)
        {   
            _unitsMoverService = unitsMoverService;
        }
        
        public void BoardClicked(BoardInputContext context)
        {
            if (context.InputButton != InputButton.Left) return;

            if (context.Battlefield == null) return;

            if (_chosenBattlefield == null)
            {
                if (context.Battlefield.BattlefieldUnitInfo.Unit != null)
                    _chosenBattlefield = context.Battlefield;
            }
            else
            {
                if (context.Battlefield.BattlefieldUnitInfo.Unit == null)
                {
                    _unitsMoverService.Move(_chosenBattlefield.BattlefieldUnitInfo.Unit, context.Battlefield);
                    _chosenBattlefield = null;
                }
            }
        }

    }
    
    
    
    
}