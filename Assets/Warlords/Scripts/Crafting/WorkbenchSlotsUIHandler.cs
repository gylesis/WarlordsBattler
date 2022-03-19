using UniRx;
using UnityEngine.EventSystems;
using Warlords.UI.Units;

namespace Warlords.Crafting
{
    public class WorkbenchSlotsUIHandler
    {
        private readonly Workbench _workbench;

        public WorkbenchSlotsUIHandler(WorkbenchSlotsContainer workbenchSlotsContainer, Workbench workbench)
        {
            _workbench = workbench;

            foreach (WorkbenchSlot workbenchSlot in workbenchSlotsContainer.WorkbenchSlots)
            {
                workbenchSlot.UIElement.PointerClick.TakeUntilDestroy(workbenchSlot)
                    .Subscribe((OnWorkbenchSlotClicked));
            }
        }

        private void OnWorkbenchSlotClicked(UIElementContextData<WorkbenchSlot> context)
        {
            var isRightButton = context.PointerEventData.button == PointerEventData.InputButton.Right;

            if (isRightButton)
            {
                if(context.Sender.Item == null) return;
                
                _workbench.ReturnItemBackToInventory(context.Sender);
            }

        }
    }
}