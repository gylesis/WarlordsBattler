using System;
using System.Collections.Generic;
using Warlords.Inventory;

namespace Warlords.Infrastructure
{
    [Serializable]
    public class InventorySaveData
    {
        public List<InventorySlotData> SlotsDatas = new List<InventorySlotData>();
    }
}