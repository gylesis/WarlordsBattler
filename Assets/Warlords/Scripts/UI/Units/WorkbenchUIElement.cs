using Warlords.Crafting;

namespace Warlords.UI.Units
{
    public class WorkbenchUIElement : UIElement<WorkbenchSlot>
    {
        private WorkbenchSlot _workbenchSlot;
        protected override WorkbenchSlot Sender => _workbenchSlot;

        public void Init(WorkbenchSlot workbenchSlot)
        {
            _workbenchSlot = workbenchSlot;
        }
    }
}