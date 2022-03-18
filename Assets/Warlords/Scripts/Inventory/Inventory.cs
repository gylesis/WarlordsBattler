using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Utils;

namespace Warlords.Inventory
{
    public class Inventory : IAsyncLoad
    {
        private List<InventorySlotData> _inventorySlotDatas = new List<InventorySlotData>();
        private readonly Dictionary<InventorySlot, InventorySlotData> _inventorySlots = new Dictionary<InventorySlot, InventorySlotData>();
        
        private readonly InventorySlotViewsContainer _inventorySlotViewsContainer;

        public Inventory(InventorySlotViewsContainer inventorySlotViewsContainer, AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);
            
            _inventorySlotViewsContainer = inventorySlotViewsContainer; 
        }

        public async UniTask AsyncLoad()
        {
            foreach (InventorySlot inventorySlot in _inventorySlotViewsContainer.InventorySlotViews)
            {
                Item item = inventorySlot.SlotData.Item;

                inventorySlot.SlotChanged.TakeUntilDestroy(inventorySlot).Subscribe(OnInventorySlotItemChanged); 
                
                _inventorySlots.Add(inventorySlot, inventorySlot.SlotData);   
            }

            await UniTask.CompletedTask;
        }

        private void OnInventorySlotItemChanged(EventContext<InventorySlot, InventorySlotData> context)
        {
            Item item = context.Value.Item;
            InventorySlot inventorySlot = context.Sender;
            
            _inventorySlots[inventorySlot] = context.Value;
        }

        public void RemoveItem(Item item)
        {
            InventorySlot inventorySlot = _inventorySlots.First(x => x.Value.Item.Name == item.Name).Key;

            var itemCount = inventorySlot.SlotData.Count.Value;
            
            if (itemCount - 1 <= 0)
            {
                _inventorySlots[inventorySlot] = null;
            }
 
            inventorySlot.SlotData.Count.Value--;
        }

        public void AddItem(Item itemToAdd, int count = 1)
        {
            Item item = _inventorySlots.Values.FirstOrDefault(x => x.Item.Name == itemToAdd.Name)?.Item;

            if (item == null)
            {
                InventorySlot freeSlot = _inventorySlots.Keys.FirstOrDefault(x => x.SlotData.Item.Name == String.Empty);

                if (freeSlot == null)
                {
                    Debug.LogError("Not enough space in inventory!");
                    return;
                }

                for (int i = 0; i < count; i++) 
                    freeSlot.AddItem(itemToAdd);
            }
            else
            {
                InventorySlot inventorySlot = _inventorySlots.FirstOrDefault(x => x.Value.Item.Name == item.Name).Key;
                inventorySlot.AddItem(itemToAdd);
            }
        }
    }

    public class InventoryState
    {
        public List<InventorySlotData> InventorySlotDatas = new List<InventorySlotData>();
    }
}