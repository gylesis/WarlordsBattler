using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class Workbench
    {
        private readonly WorkbenchSlotsService _workbenchSlotsService;
        private readonly Inventory.Inventory _inventory;

        public Workbench(WorkbenchSlotsService workbenchSlotsService, Inventory.Inventory inventory)
        {
            _inventory = inventory;
            _workbenchSlotsService = workbenchSlotsService;
        }
        
        public void TryPut(WorkbenchSlot workbenchSlot, Item item)
        {
            if (workbenchSlot.Item == null)
            {
                _inventory.RemoveItem(item);
                _workbenchSlotsService.Put(workbenchSlot, item);

                workbenchSlot.SetItem(item);
                return;    
            }

            Debug.Log("Busy already");
            
        }
    }
}