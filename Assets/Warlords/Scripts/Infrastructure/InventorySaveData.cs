using System;
using System.Collections.Generic;

namespace Warlords.Infrastructure
{
    [Serializable]
    public class InventorySaveData
    {
        public List<InventorySlotSaveData> SlotsDatas = new List<InventorySlotSaveData>();
    }
}