using UniRx;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class Workbench
    {
        private readonly WorkbenchSlotsService _workbenchSlotsService;
        private readonly Inventory.Inventory _inventory;

        public Subject<Item> WorkbenchRecipeAvailable => _workbenchSlotsService.WorkbenchRecipeAvailable;

        public Workbench(WorkbenchSlotsService workbenchSlotsService, Inventory.Inventory inventory)
        {
            _inventory = inventory;
            _workbenchSlotsService = workbenchSlotsService;
        }

        public void Craft()
        {
            var craftSucceed = _workbenchSlotsService.TryCraft(out var craftedItem);

            if (craftSucceed)
            {
                _inventory.AddItem(craftedItem);
            }
        }

        public void ReturnItemBackToInventory(WorkbenchSlot workbenchSlot)
        {
            _inventory.AddItem(workbenchSlot.Item);
            _workbenchSlotsService.RemoveItemFromSlot(workbenchSlot);
        }
        
        public void TryPut(WorkbenchSlot workbenchSlot, Ingredient ingredient)
        {
            if (workbenchSlot.Item == null)
            {
                _inventory.RemoveItem(ingredient);
                _workbenchSlotsService.Put(workbenchSlot, ingredient);

                workbenchSlot.SetItem(ingredient);
            }
            else
            {
                Debug.Log("Busy already");
            }

        }
        
    }
}