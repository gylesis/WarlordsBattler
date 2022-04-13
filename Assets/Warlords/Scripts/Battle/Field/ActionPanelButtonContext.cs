using System;
using Warlords.Board;

namespace Warlords.Battle.Field
{
    [Serializable]
    public struct ActionPanelButtonContext
    {
        public ActionType ActionType;
        public IActionCommand ActionCommand;
    }

    public interface IActionCommand
    {
        void Act();
    }
    
    public class MoveActionCommand : IActionCommand
    {
        
        public MoveActionCommand(UnitsMoverService unitsMoverService) 
        {
            
        }

        public void Act()
        {
            
        }
    }
    

}