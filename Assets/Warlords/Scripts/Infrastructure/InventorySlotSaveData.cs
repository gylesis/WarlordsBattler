using System;
using Warlords.Inventory;

namespace Warlords.Infrastructure
{
    [Serializable]
    public class InventorySlotSaveData
    {
        public Item Item;
        public int Count;

        public InventorySlotSaveData() { }
        public InventorySlotSaveData(InventorySlotData slotData)
        {
            if (slotData.Item is Ingredient ingredient)
            {
                Item = ingredient;
            }

            Item = slotData.Item;
            Count = slotData.Count.Value.Value;
        }
        
    }
}