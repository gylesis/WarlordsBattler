using System;
using Warlords.Utils;

namespace Warlords.Inventory
{
    [Serializable]
    public class InventorySlotData
    {
        public Item Item = new Item();
        public IntStat Count = new IntStat();
    }

    [Serializable]
    public class Item
    {
        public string Name;
    }
    
    
}