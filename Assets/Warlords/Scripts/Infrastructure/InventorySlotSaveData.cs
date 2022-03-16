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
            Item = slotData.Item;
            Count = slotData.Count.Value;
        }
        
    }
}