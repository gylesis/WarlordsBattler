using System;
using UniRx;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class Workbench
    {
        private readonly WorkbenchSlotsService _workbenchSlotsService;
        private readonly Inventory.Inventory _inventory;

        public Subject<Unit> OnWorkbenchFull = new Subject<Unit>();

        public Workbench(WorkbenchSlotsService workbenchSlotsService, Inventory.Inventory inventory)
        {
            _inventory = inventory;
            _workbenchSlotsService = workbenchSlotsService;
        }

        public void Craft()
        {
            var tryCraft = _workbenchSlotsService.TryCraft(out var craftedItem);

            if (tryCraft)
            {
                _inventory.AddItem(craftedItem);
            }
        }

        public void Reset()
        {
            _workbenchSlotsService.ResetWorkbenchSlots();
        }

        public void ReturnItemsToInventory()
        {
            // TODO
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

            if (_workbenchSlotsService.IsWorkbenchFull)
                OnWorkbenchFull.OnNext(Unit.Default);
        }
    }
}