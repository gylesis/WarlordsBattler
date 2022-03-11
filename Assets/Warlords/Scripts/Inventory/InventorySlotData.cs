using System;
using Warlords.Utils;

namespace Warlords.Inventory
{
    [Serializable]
    public class InventorySlotData
    {
        public string Name;
        public IntStat Count = new IntStat();
    }
}