using System.Collections.Generic;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class WorkbenchSlotsService
    {
        private readonly Dictionary<WorkbenchSlot, Item> _workbenchSlots = new Dictionary<WorkbenchSlot, Item>();

        public void Put(WorkbenchSlot workbenchSlot, Item item)
        {
            _workbenchSlots[workbenchSlot] = item;
        }

        public void ResetWorkbenchSlots()
        {
            foreach (var keyValuePair in _workbenchSlots)
            {
                _workbenchSlots[keyValuePair.Key] = null;
            }
        }
        
    }
}